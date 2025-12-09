using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace iSave_FrontEnd
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public  HtmlControl getHomeID
        {
            get { return homeId; }
        }

        public HtmlControl getProductID
        {
            get { return productsID; }
        }

        public HtmlControl getAboutID
        {
            get { return aboutId; }
        }

        public HtmlControl getContactID
        {
            get { return contactId; }
        }

        public HtmlControl getCalculatorID
        {
            get { return calculatorID; }
        }

        public HtmlControl getSigninID
        {
            get { return singinID; }
        }

        public HtmlControl getShopID
        {
            get { return shopnowId; }
        }

        public HtmlControl getAdminID
        {
            get { return adminID; }
        }

        public HtmlControl getSignOutID
        {
            get { return signoutID; }
        }

       public HtmlControl getCartId
        {
            get
            {
                return CartId;
            }
        }
        public HtmlControl getDashId
        {
            get
            {
                return dashboardID;
            }
        }
        public HtmlControl getAdminDash
        {
            get
            {
                return AdminDashID;
            }
        }
        public HtmlControl getViewProd
        {
            get
            {
                return AdminProductID;
            }
        }
    }
}