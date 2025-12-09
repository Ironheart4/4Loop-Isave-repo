using iSave_FrontEnd.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSave_FrontEnd
{
    public partial class ProductDelete : System.Web.UI.Page
    {
        protected int productId;
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
                if (Request.QueryString["Id"] != null)
                {
                    productId = Convert.ToInt32(Request.QueryString["Id"]);

                    Service1Client client = new Service1Client();
                    var product = client.GetProduct(productId);
                    

                    if (product != null)
                    {
                        lblProductId.Text = productId.ToString();
                        lblProductName.Text = product.Name;
                        lblProductPrice.Text = product.Price.ToString("N2");
                        imgProduct.ImageUrl = product.Image;

                        lblMessage.Text = "Are you sure you want to delete this product?";
                    }
                    else
                    {
                        lblMessage.Text = "⚠️ Product not found.";
                        btnConfirmDelete.Visible = false;
                    }
                    client.Close();
                }
                else
                {
                    lblMessage.Text = "Invalid product ID.";
                    btnConfirmDelete.Visible = false;
                }

            }
        }

        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            productId = Convert.ToInt32(Request.QueryString["Id"]);

            Service1Client client = new Service1Client();
            int result = client.DeleteProduct(productId);
            

            if (result == 0)
            {
                string script = "alert('✅ Product deleted successfully!'); window.location='AdminProduct.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(), "redirect", script, true);

            }
            else if (result == 1)
            {
                lblMessage.Text = "⚠️ Product not found.";
            }
            else
            {
                lblMessage.Text = "❌ An error occurred while deleting the product.";
            }
            client.Close();
        }
    }
}