using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iSave_FrontEnd.ServiceReference1;

namespace iSave_FrontEnd
{
    public partial class Register : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            var master = Master as Main;

            master.getShopID.Visible = false;
            master.getSigninID.Visible = false;
            master.getCalculatorID.Visible = false;
            master.getAdminID.Visible = false;
            master.getContactID.Visible = false;
            master.getAboutID.Visible = false;
            master.getProductID.Visible = false;
            master.getHomeID.Visible = true;
            master.getDashId.Visible = false;
            master.getAdminDash.Visible = false;
            master.getViewProd.Visible = false;
            master.getCartId.Visible = false;

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
         

            String strName = txtFirstName.Text;
            String strSurname = txtLaastName.Text;
            String strPhone = txtPhone.Text;
            String strEmail = txtEmail.Text;
            String strPassword = txtPassword.Text;
            char crTypeUser = Convert.ToChar(UserType.SelectedValue);

            var response = client.RegisterUser(strName, strSurname, strEmail, strPassword, strPhone, crTypeUser);

            if (response == 0)
            {
                Response.Redirect("Login.aspx");
            }
            else if (response == 1)
            {
                RegisterText.ForeColor = System.Drawing.Color.Red;
                RegisterText.Text = "User already exist, please try to log in ";
            }
            else if (response == -1)
            {
                RegisterText.ForeColor = System.Drawing.Color.Red;
                RegisterText.Text = "Some internal error has occured please try again later ";
            }


            // Always close the client.
            client.Close();

        }
    }
}