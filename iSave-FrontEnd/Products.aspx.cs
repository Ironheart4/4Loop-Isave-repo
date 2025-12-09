using iSave_FrontEnd.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSave_FrontEnd
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();
            var products = client.GetProducts().ToList();
            string sort = Request.QueryString["sort"];

            switch (sort)
            {
                case "name":
                    products = products.OrderBy(p => p.Name).ToList();
                    break;
                case "price-low":
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case "price-high":
                    products = products.OrderByDescending(p => p.Price).ToList();
                    break;
                default:
                    // Default sort: by name
                    products = products.OrderBy(p => p.Name).ToList();
                    break;
            }

            StringBuilder stream = new StringBuilder();

            foreach (Product product in products)
            {
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
            DisplayProducts.InnerHtml = stream.ToString();

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
        protected string GetSelectedSort(string value)
        {
            string sort = Request.QueryString["sort"] ?? "name"; // default
            return sort == value ? "selected" : "";
        }
    }
}