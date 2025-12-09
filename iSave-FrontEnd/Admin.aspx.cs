using iSave_FrontEnd.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace iSave_FrontEnd
{
    public partial class Admin : System.Web.UI.Page
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
                master.getAdminDash.Visible = false;
                master.getViewProd.Visible = false;

            }
            else
            {
                master.getAdminID.Visible = false;
                master.getShopID.Visible = false;
                master.getCalculatorID.Visible = false;
                master.getCartId.Visible = true;
                master.getDashId.Visible = false;
                 master.getAdminDash.Visible = false;
                master.getViewProd.Visible = false;

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();

            string strName = productName.Text;
            string strDescription = productDescription.Value;
            int intPrice = Convert.ToInt32(productPrice.Text);
            char in_stock = Convert.ToChar(inStock.Text);
            decimal energy_saved_watts = Convert.ToDecimal(energySaved.Text);
            decimal carbon_reductionKG = Convert.ToDecimal(carbonReduced.Text);
            string image = productImage.Text;
            string link = productLink.Text;

            var response = client.AddProduct(strName, strDescription, intPrice, in_stock, energy_saved_watts, carbon_reductionKG, image, link);

            if (response == 0)
            {
                ProductAdded.ForeColor = System.Drawing.Color.Green;
                ProductAdded.Text = "Product Added Succesfully ";
            }
            else if (response == 1)
            {
                ProductAdded.ForeColor = System.Drawing.Color.Red;
                ProductAdded.Text = "Productalready exist";
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