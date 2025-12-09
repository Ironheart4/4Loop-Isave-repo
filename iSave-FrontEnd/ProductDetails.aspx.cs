using iSave_FrontEnd.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSave_FrontEnd
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();

            int productID = Convert.ToInt32(Request.QueryString["Id"]);

            Product product = client.GetProduct(productID);



            image.InnerHtml = "<img src='" + product.Image + "' alt='" + product.Name + "' style='max-width:100%; height:auto;' />";
            productName.InnerText = product.Name;
            productDescription.InnerText = product.Description;
            productPrice.InnerText = "R" + Convert.ToString(product.Price);
            BtnCart.InnerHtml = "<a href='Cart.aspx?Id=" + productID + @"' class='btn btn-success w-100 mb-2'>Add to Cart</a>";
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




            client.Close();
        }

        protected void addToCartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
    }
}