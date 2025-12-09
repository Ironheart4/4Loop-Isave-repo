using iSave_FrontEnd.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSave_FrontEnd
{
    public partial class Checkout : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();// your WCF service client

       
        protected void Page_Load(object sender, EventArgs e)
        {
            var master = Master as Main;
            char type = Convert.ToChar(Session["Logged"]);

            if (type == 'A')
            {
                master.getSignOutID.Visible = true;
                master.getAdminID.Visible = true;
                master.getSigninID.Visible = false;
                master.getShopID.Visible = false;
                master.getCalculatorID.Visible = false;
                master.getContactID.Visible = false;
                master.getAboutID.Visible = false;
                master.getProductID.Visible = false;
                master.getHomeID.Visible = false;
                master.getCartId.Visible = false;
                master.getDashId.Visible = false;
                master.getAdminDash.Visible = true;
                master.getViewProd.Visible = true;

            }
            else if (type == 'C')
            {
                master.getSignOutID.Visible = true;
                master.getAdminID.Visible = false;
                master.getSigninID.Visible = false;
                master.getCartId.Visible = true;
                master.getShopID.Visible = false;
                master.getDashId.Visible = true;
                master.getAdminDash.Visible = false;
                master.getViewProd.Visible = false;

            }
            else
            {
                master.getAdminID.Visible = false;
                master.getShopID.Visible = false;
                master.getCalculatorID.Visible = false;
                master.getCartId.Visible = false;
                master.getDashId.Visible = false;
                master.getAdminDash.Visible = false;
                master.getViewProd.Visible = false;
            }
            if (!IsPostBack)
            {
                LoadCartItems();
            }
        }
        private void LoadCartItems()
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            var cartArray = client.GetUserCart(userId);
            List<ServiceReference1.CartItemDTO> cart = cartArray.ToList();

            rptCartItems.DataSource = cart;
            rptCartItems.DataBind();

            decimal subtotal = cart.Sum(x => x.ItemTotal);

            // Shipping rules
            decimal shipping = 0;
            if (subtotal < 500) shipping = 75;
            else if (subtotal < 5000) shipping = 50;
            else shipping = 0;

            decimal tax = subtotal * 0.08m; // 8% tax
            decimal total = subtotal + shipping + tax;

            lblSubtotal.InnerText = $"R{subtotal:F2}";
            lblTax.InnerText = $"R{tax:F2}";
            lblShipping.InnerText = $"R{shipping:F2}";
            lblTotal.InnerText = $"R{total:F2}";
            btnPlaceOrder.Text = $"Pay Now - R{total:F2}";
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            string cardNumber = cardNo.Value.Replace(" ", "").Replace("-", "");
            string expiry = ExpiryDate.Value;
            string cvc = CVC.Value;

            // Validate Card Number (16 digits)
            if (!System.Text.RegularExpressions.Regex.IsMatch(cardNumber, @"^\d{16}$"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('⚠️ Invalid Card Number.');", true);
                return;
            }

            // Validate Expiry (MM/YY)
            if (!System.Text.RegularExpressions.Regex.IsMatch(expiry, @"^(0[1-9]|1[0-2])\/\d{2}$"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('⚠️ Invalid Expiry Date. Use MM/YY format.');", true);
                return;
            }

            // Validate CVC (3-4 digits)
            if (!System.Text.RegularExpressions.Regex.IsMatch(cvc, @"^\d{3}$"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('⚠️ Invalid CVC code.');", true);
                return;
            }
            int userId = Convert.ToInt32(Session["UserID"]);
            string fullName = txtfullName.Value;
            string email = txtemail.Value;
            string address = txtshippingAddress.Value;

            int orderId = client.PlaceOrder(userId, fullName, email, address);

            if (orderId > 0)
            {
                // Mark order as paid
                bool paymentSuccess = client.MarkOrderAsPaid(orderId);

                if (paymentSuccess)
                {
        
                    string script = $"alert('✅ Payment successful! Your invoice number is: {client.GetInvoiceNumber(orderId)}'); window.location='Dashboard.aspx';";
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", script, true);
                }
                else
                {
  
                    string script = $"alert('Payment failed. Please try again.'); window.location='Checkout.aspx';";
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", script, true);

                }

                // Reload cart items to show empty
                LoadCartItems();
                // Clear cart labels or inputs if needed
                rptCartItems.DataSource = null;
                rptCartItems.DataBind();
                lblSubtotal.InnerText = "R0.00";
                lblTax.InnerText = "R0.00";
                lblShipping.InnerText = "R0.00";
                lblTotal.InnerText = "R0.00";
                btnPlaceOrder.Enabled = false;
            }
            else
            {
                string script = $"alert('Payment failed. Please try again.'); window.location='Checkout.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(), "redirect", script, true);

            }
        }
    }
}