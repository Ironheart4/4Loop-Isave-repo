using iSave_FrontEnd.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSave_FrontEnd
{
    public partial class ProductEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Service1Client client = new Service1Client();

                int productID = Convert.ToInt32(Request.QueryString["Id"]);

                Product product = client.GetProduct(productID);

                productName.Text = product.Name;
                productDescription.Value = product.Description;
                productPrice.Text = Convert.ToString(product.Price);
                inStock.Text = "Y";
                energySaved.Text = Convert.ToString(product.EnergySavedWatts);
                carbonReduced.Text = Convert.ToString(product.CarbonReductionKg);
                productImage.Text = product.Image;

               

                client.Close();
            }

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
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32(Request.QueryString["Id"]);
            Service1Client client = new Service1Client();

            string strName = productName.Text.Trim();
            string strDescription = productDescription.Value.Trim();
            decimal decPrice = Convert.ToDecimal(productPrice.Text.Trim());
            char in_stock = Convert.ToChar(inStock.Text.Trim());
            decimal energy_saved_watts = Convert.ToDecimal(energySaved.Text.Trim());
            decimal carbon_reductionKG = Convert.ToDecimal(carbonReduced.Text.Trim());
            string image = productImage.Text.Trim();


            var response = client.UpdateProduct(strName, strDescription, decPrice, in_stock, energy_saved_watts, carbon_reductionKG, image, productID);

            if (response == 0)
            {
                ProductAdded.ForeColor = System.Drawing.Color.Green;
                ProductAdded.Text = "Product Updated Succesfully ";
            }
            else if (response == 1)
            {
                ProductAdded.ForeColor = System.Drawing.Color.Red;
                ProductAdded.Text = "faile to update product ";
            }
            else if (response == -1)
            {
                ProductAdded.ForeColor = System.Drawing.Color.Red;
                ProductAdded.Text = "Some internal error has occured please try again later ";
            }

            client.Close();
        }
    }
}