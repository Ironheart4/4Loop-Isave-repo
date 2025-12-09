using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iSave_FrontEnd.ServiceReference1;

namespace iSave_FrontEnd
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var master = Master as Main;

            master.getShopID.Visible = false;
            master.getCartId.Visible = false;
            master.getSigninID.Visible = false;
            master.getCalculatorID.Visible = false;
            master.getAdminID.Visible = false;
            master.getContactID.Visible = false;
            master.getAboutID.Visible = false;
            master.getProductID.Visible = false;
            master.getHomeID.Visible = true;
            master.getDashId.Visible = false;
            master.getViewProd.Visible = false;
            master.getAdminDash.Visible = false;
        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();

            String strEmail = txtEmail.Text;
            String strPassword = txtPassword.Text;

            var LoggedIn = client.Login(strEmail, strPassword);

            if (LoggedIn == null)
            {

                LoginText.ForeColor = System.Drawing.Color.Red;
                LoginText.Text = "Wrong Email Or Password";
            }
            else
            {
                // Store session
                Session["Logged"] = LoggedIn.UserType;
                Session["UserID"] = LoggedIn.Id;

                LoginText.ForeColor = System.Drawing.Color.Green;
                LoginText.Text = "Login Successful";

                // Redirect based on user type
                if (LoggedIn.UserType == 'C')
                {
                    Response.Redirect("Home.aspx"); // Customer goes to Home
                }
                else if (LoggedIn.UserType == 'A')
                {
                    Response.Redirect("AdminDashboard.aspx"); // Manager goes to Manager page
                }
               
            }
            client.Close();
        }
    }
}