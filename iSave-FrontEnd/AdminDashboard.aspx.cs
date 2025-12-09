using iSave_FrontEnd.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSave_FrontEnd
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadAnalytics();
                LoadCharts();
              
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
        private void LoadAnalytics()
        {
            Service1Client client = new Service1Client();

            try
            {
                // Assuming you have these methods in your service

                totalCustomers.InnerText = client.GetTotalCustomers().ToString();
                totalProducts.InnerText = client.GetTotalProducts().ToString();
                totalOrders.InnerText = client.GetTotalOrders().ToString();
                totalSales.InnerText = client.GetTotalSales().ToString("N2");
            }
            catch (Exception ex)
            {
                // Log or handle exceptions
                totalCustomers.InnerText = client.GetTotalCustomers().ToString();
                totalProducts.InnerText = client.GetTotalProducts().ToString();
                totalOrders.InnerText = client.GetTotalOrders().ToString();
                totalSales.InnerText = client.GetTotalSales().ToString("N2");
            }
            finally
            {
                client.Close();
            }
        }
        private void LoadCharts()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Service1Client client = new Service1Client();
            try
            {
                var salesTrend = client.GetSalesTrend();
                SalesLabelsJson = js.Serialize(salesTrend.Select(x => x.Day));
                SalesDataJson = js.Serialize(salesTrend.Select(x => x.Total));

                var topProducts = client.GetTopProducts(5);
                ProductLabelsJson = js.Serialize(topProducts.Select(x => x.Name));
                ProductDataJson = js.Serialize(topProducts.Select(x => x.Quantity));

                var allUserPurchases = client.GetAllUserPurchases();
                UserPurchaseLabelsJson = js.Serialize(allUserPurchases.Select(x => x.FullName));
                UserPurchaseDataJson = js.Serialize(allUserPurchases.Select(x => x.TotalPurchases));

                var revenuePerProduct = client.GetRevenuePerProduct();
                RevenueLabelsJson = js.Serialize(revenuePerProduct.Select(x => x.ProductName));
                RevenueDataJson = js.Serialize(revenuePerProduct.Select(x => x.Revenue));
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            finally
            {
                client.Close();
            }
        }

        // Add these properties
        public string UserPurchaseLabelsJson { get; set; }
        public string UserPurchaseDataJson { get; set; }

        public string SalesLabelsJson { get; set; }
        public string SalesDataJson { get; set; }
       
        public string ProductLabelsJson { get; set; }
        public string ProductDataJson { get; set; }

        public string RevenueLabelsJson { get; set; }
        public string RevenueDataJson { get; set; }
    }
}