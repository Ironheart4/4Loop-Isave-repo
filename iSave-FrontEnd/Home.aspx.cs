using iSave_FrontEnd.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace iSave_FrontEnd
{
    public partial class Home : System.Web.UI.Page
    {
        public HtmlControl getHomeSignInID
        {
            get
            {
                return HomeSignIn;
            }
        }
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
                HomeSignIn.Visible = false;

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


                HomeSignIn.Visible = false;
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


            Service1Client client = new Service1Client();
            var products = client.GetProducts();

            StringBuilder stream = new StringBuilder();

           for(int i=0;i<products.Length && i<3;i++)
            {
                Product product = products[i];
                stream.Append(@"
                    <div class='col-md-4'>
                      <div class='card shadow-lg border-0 h-100 rounded-3'>
                        <div class='text-center mt-4'>
                          <img src='" + product.Image + @"' alt='" + product.Name + @"' class='img-fluid' style='max-height:120px;' />
                        </div>
                        <div class='card-body'>
                          <h5 class='card-title fw-bold'>" + product.Name + @"</h5>

                          <div class='d-flex justify-content-between mb-3'>
                            <span class='badge bg-light text-success'>
                              ⚡ Energy Saved: <strong>" + product.EnergySavedWatts + @"W</strong>
                            </span>
                            <span class='badge bg-light text-warning'>
                              🌱 CO₂ Saved: <strong>" + product.CarbonReductionKg + @"kg/yr</strong>
                            </span>
                          </div>
                          <div class='d-flex justify-content-between align-items-center'>
                            <h4 class='fw-bold mb-0'>R" + product.Price.ToString("N2") + @"</h4>
                            <a href='ProductDetails.aspx?Id=" + product.Id + @"' class='btn btn-success'>View Details</a>

                          </div>
                        </div>
                      </div>
                    </div>
                ");
            }
            // inject into your div
            featuredProductsContainer.InnerHtml = stream.ToString();
        }
    }
}