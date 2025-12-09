using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iSave_FrontEnd.ServiceReference1; // Adjust to your WCF service reference namespace

namespace iSave_FrontEnd
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();
            if (!IsPostBack)
            {
                // Set master page navigation visibility
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

                // Get user ID from session
                int userId = Convert.ToInt32(Session["UserID"]);

                try
                {
                    //Add seeders

                    // Get user name
                    var user = client.GetUser(userId);
                    lblUserName.Text = user != null ? $"{user.FirstName} {user.LastName}".Trim() : "Demo";

                    // Get dashboard stats
                    var stats = client.GetDashboardStats(userId);
                    if (stats != null)
                    {
                        lblEnergySaved.Text = $"{stats.EnergySavedW:0.#}W";
                        lblMoneySaved.Text = $"R{stats.MoneySavedMonthly:0}";
                        lblCO2Reduced.Text = $"{stats.Co2ReducedKg:0.#}kg";
                        lblYearlyProjection.Text = $"R{stats.YearlyProjection:0}";

                        // Milestone
                        decimal targetMonthly = 200m;
                        decimal progressPercent = stats.MoneySavedMonthly > 0 ? (stats.MoneySavedMonthly / targetMonthly) * 100m : 0;
                        litProgressPercent.Text = (100 - progressPercent).ToString("0");
                        lblMilestoneProgress.Text = $"R{stats.MoneySavedMonthly:0.00} / ${targetMonthly}";
                        lblMilestoneRemaining.Text = $"R{targetMonthly - stats.MoneySavedMonthly:0.00} more to reach your goal!";
                    }

                    // Achievements (hardcoded for now; replace with client.GetAchievements(userId) when database table is added)
                    bool hasPurchases = client.GetRecentPurchases(userId).Any();
                    bool isEnergySaver = stats?.EnergySavedW > 500;
                    bool isCarbonReducer = stats?.Co2ReducedKg > 100;

                    var achieved = new List<object>();
                    if (hasPurchases)
                        achieved.Add(new { Title = "First Purchase", Description = "Made your first energy-saving purchase!", Category = "savings", EarnedDate = DateTime.Now });
                    if (isEnergySaver)
                        achieved.Add(new { Title = "Energy Saver", Description = "Saved over 500W of energy consumption", Category = "savings", EarnedDate = DateTime.Now });
                    if (isCarbonReducer)
                        achieved.Add(new { Title = "Carbon Reducer", Description = "Reduced CO₂ emissions by over 100kg annually", Category = "environmental", EarnedDate = DateTime.Now });

                    rptAchievements.DataSource = achieved;
                    rptAchievements.DataBind();

                    // Upcoming achievements
                    var upcoming = new List<object>
                        {
                            new { Title = "Energy Master", Description = "Save R200+ monthly" },
                            new { Title = "Solar Pioneer", Description = "Install solar panels" }
                        };
                    rptUpcomingAchievements.DataSource = upcoming;
                    rptUpcomingAchievements.DataBind();

                    // Recent Purchases
                    var recentPurchases = client.GetRecentPurchases(userId);
                    rptPurchases.DataSource = recentPurchases;
                    rptPurchases.DataBind();

                    // Show/hide "No Purchases" panel
                    var pnlNoPurchases = rptPurchases.Controls
                        .OfType<RepeaterItem>()
                        .Select(item => item.FindControl("pnlNoPurchases") as Panel)
                        .FirstOrDefault(p => p != null);
                    if (pnlNoPurchases != null)
                    {
                        pnlNoPurchases.Visible = !recentPurchases.Any();
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("pnlNoPurchases not found in rptPurchases.");
                    }

                    // Recent Invoices
                    var recentInvoices = client.GetRecentInvoices(userId)
                    .Select(o => new
                     {
                         o.OrderId,
                         InvoiceNumber = client.GetInvoiceNumber(o.OrderId), // fetch the real invoice number
                         o.IssuedDate,
                         o.TotalAmount,
                         o.Status
                     }).ToList();
                    rptInvoices.DataSource = recentInvoices;
                    rptInvoices.DataBind();

                    // Chart data
                    var trends = client.GetSavingsTrends(userId);
                    if (trends != null)
                    {
                        var chartData = new
                        {
                            labels = trends.Labels,
                            money = trends.Money,
                            energy = trends.Energy,
                            co2 = trends.Co2
                        };
                        string chartJson = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(chartData);
                        ScriptManager.RegisterStartupScript(this, GetType(), "initChart", $"initChart({chartJson});", true);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in Page_Load: {ex.GetBaseException().Message}");
                    // Display user-friendly error message
                    lblUserName.Text = "Error loading dashboard. Please try again later.";
                }
            }
        }
    }
}