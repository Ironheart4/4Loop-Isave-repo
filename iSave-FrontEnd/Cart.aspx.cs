using iSave_FrontEnd.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSave_FrontEnd
{
    public partial class Cart : System.Web.UI.Page
    {
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
            }

            if (!IsPostBack)
            {
                Service1Client client = new Service1Client();
                int userId = Convert.ToInt32(Session["UserID"]);

                // Add product from query string if present
                if (Request.QueryString["Id"] != null)
                {
                    int productID = Convert.ToInt32(Request.QueryString["Id"]);
                    int quantity = 1; // default quantity
                    Product product = client.GetProduct(productID);

                    client.AddOrder(userId, productID, quantity, product.Price);
                }
                if (Request.QueryString["remove"] != null)
                {
                    int productIdToRemove = Convert.ToInt32(Request.QueryString["remove"]);
                    client.deletOrder(userId, productIdToRemove);
                    Response.Redirect("Cart.aspx"); // reload page after removal
                }

                // Get all cart items
                var cartItems = client.GetUserCart(userId);
                decimal total = 0;
                cartItemsContainer.Controls.Clear();

                foreach (var item in cartItems)
                {
                    total += item.ItemTotal;

                    string html = $@"
<div class='col-md-6 mb-3'>
    <div class='card h-100 shadow-sm p-2'>
        <img src='{item.Image}' class='card-img-top' style='max-width:100%; object-fit:cover;' />
        <h5 class='card-title'>{item.ProductName}</h5>
        <div class='d-flex align-items-center mb-2'>
            <input type='number' value='{item.Quantity}' min='1' 
                   class='form-control quantityInput' 
                   data-price='{item.Price}' 
                   onchange='updateItemTotal(this, {item.Price})' />
        </div>
        <p class='fw-bold item-total'>R{item.ItemTotal:0.00}</p>
        <a href='Cart.aspx?remove={item.ProductId}' class='btn btn-sm btn-danger'>Remove</a>
    </div>
</div>";

                    cartItemsContainer.Controls.Add(new LiteralControl(html));
                }

                totalDiv.InnerText = "R" + total.ToString("0.00");
                client.Close();
            }
        }


        protected void clearCart_Click1(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            Service1Client client = new Service1Client();

            var cartItems = client.GetUserCart(userId);

            foreach (var item in cartItems)
            {
                client.deletOrder(userId, item.ProductId);
            }

            client.Close();

            // Reload the page to reflect empty cart
            Response.Redirect("Cart.aspx");
        }
    }
}