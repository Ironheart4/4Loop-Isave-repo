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
    public partial class AdminProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
      

            Service1Client client = new Service1Client();
            var products = client.GetProducts();

            StringBuilder stream = new StringBuilder();

            foreach (Product product in products)
            {
                stream.Append(@"
  <div class='product-card d-flex align-items-center p-3 mb-3 border rounded shadow-sm'>
      <img src='" + product.Image + @"' alt='" + product.Name + @"' 
           style='width:120px; height:80px; object-fit:cover; border-radius:6px; margin-right:15px;' />
      
      <div class='product-info flex-grow-1'>
          <h4 class='mb-1'>" + product.Name + @"</h4>
          <p class='mb-1 text-muted'>Product ID: " + product.Id + @"</p>
          <p class='price fw-bold text-success'>R " + product.Price.ToString("N2") + @"</p>
      </div>

      <div class='actions d-flex flex-column gap-2'>
          <a href='ProductEdit.aspx?Id=" + product.Id + @"' class='btn btn-sm btn-primary'>Update</a>
          <a href='ProductDelete.aspx?Id=" + product.Id + @"' class='btn btn-sm btn-danger'>Delete</a>
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

            client.Close();

        }
    }
}