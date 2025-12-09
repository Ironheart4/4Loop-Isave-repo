using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSave_FrontEnd
{
    public partial class Calculator : System.Web.UI.Page
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
                master.getDashId.Visible = false;
                master.getAdminDash.Visible = true;
                master.getViewProd.Visible = true;

            }
            else if (type == 'C')
            {
                master.getSignOutID.Visible = true;
                master.getAdminID.Visible = false;
                master.getSigninID.Visible = false;
                master.getShopID.Visible = false;
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

            resultsContainer.InnerHtml = "<div id='resultsPlaceholder' class='text-center text-muted'>";
            resultsContainer.InnerHtml += "<i class='bi bi-calculator display-4 d-block mb-3'></i>";
            resultsContainer.InnerHtml += "<p class='mb-0'>Enter your details to see potential savings.</p>";
            resultsContainer.InnerHtml += "</div>";
        }

        protected void calculateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentWatts.Value) ||
               string.IsNullOrWhiteSpace(txtNewWatts.Value) ||
               string.IsNullOrWhiteSpace(txtHoursPerDay.Value) ||
               string.IsNullOrWhiteSpace(txtDaysPerWeek.Value) ||
               string.IsNullOrWhiteSpace(txtElectricity.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill in all fields.');", true);
                return;
            }


            double currentWatts = Convert.ToDouble(txtCurrentWatts.Value);   // User input
            double newWatts = Convert.ToDouble(txtNewWatts.Value);        // User input
            double hoursPerDay = Convert.ToDouble(txtHoursPerDay.Value);      // User input
            double daysPerWeek = Convert.ToDouble(txtDaysPerWeek.Value);      // User input
            double electricityRate = Convert.ToDouble(txtElectricity.Value); // User input (R/kWh)


            if (!double.TryParse(txtCurrentWatts.Value, out currentWatts) || currentWatts <= 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Current watts must be a positive number.');", true);
                return;
            }

            if (!double.TryParse(txtNewWatts.Value, out newWatts) || newWatts <= 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('New watts must be a positive number.');", true);
                return;
            }

            if (!double.TryParse(txtHoursPerDay.Value, out hoursPerDay) || hoursPerDay <= 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Hours per day must be a positive number.');", true);
                return;
            }

            if (!double.TryParse(txtDaysPerWeek.Value, out daysPerWeek) || daysPerWeek <= 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Days per week must be a positive number.');", true);
                return;
            }

            if (!double.TryParse(txtElectricity.Value, out electricityRate) || electricityRate <= 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Electricity rate must be a positive number.');", true);
                return;
            }

            // --- Logical validations ---
            if (currentWatts < newWatts)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Current watts cannot be less than new watts.');", true);
                return;
            }

            if (hoursPerDay > 24)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Hours per day cannot be greater than 24.');", true);
                return;
            }

            if (daysPerWeek > 7)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Days per week cannot be greater than 7.');", true);
                return;
            }



            // --- Calculations ---
            // Weekly energy saved in Wh
            double energySavedWh = (currentWatts - newWatts) * hoursPerDay * daysPerWeek;

            // Annual savings in kWh
            double energySavedKWh = (energySavedWh * 52) / 1000;

            // Cost savings
            double yearlyCostSaved = energySavedKWh * electricityRate;
            double monthlyCostSaved = yearlyCostSaved / 12;
            double weeklyCostSaved = yearlyCostSaved / 52;

            // Carbon reduced (kg CO₂)
            double carbonReduced = energySavedKWh * 0.9;



            resultsContainer.InnerHtml = $@"
        <!-- Energy Savings (big green) -->
        <div class='energy-card'>
            <div class='title'>
                <span class='icon'><i class='bi bi-lightning-charge-fill'></i></span>
                <span>Energy Savings</span>
            </div>
            <div class='row align-items-center'>
                <div class='col-8'>
                    <div class='big-value'>{energySavedWh:N0} Wh/week</div>
                    <div class='subtitle'>{energySavedKWh:N2} kWh per year</div>
                </div>
                <div class='col-4 text-end'>
                    <i class='bi bi-graph-up' style='font-size:28px;color:var(--accent-green);opacity:0.9'></i>
                </div>
            </div>
        </div>

        <!-- Cost Savings (three yellow boxes) -->
        <div class='cost-card'>
            <div class='heading'>Cost Savings</div>
            <div class='cost-grid'>
                <div class='cost-box'>
                    <span class='amount'>R{weeklyCostSaved:N2}</span>
                    <span class='label'>Weekly</span>
                </div>
                <div class='cost-box'>
                    <span class='amount'>R{monthlyCostSaved:N2}</span>
                    <span class='label'>Monthly</span>
                </div>
                <div class='cost-box'>
                    <span class='amount'>R{yearlyCostSaved:N2}</span>
                    <span class='label'>Yearly</span>
                </div>
            </div>
        </div>

        <!-- Environmental Impact -->
        <div class='env-card'>
            <div class='heading'><i class='bi bi-leaf-fill' style='margin-right:8px;color:var(--accent-green)'></i> Environmental Impact</div>
            <div class='value'>{carbonReduced:N1} kg CO₂</div>
            <div class='muted small'>Reduced annually - equivalent to planting trees!</div>
        </div>

        <!-- Summary (blue box) -->
        <div class='summary-box'>
            <div class='title'>Summary</div>
            <div class='text'>
                By making this switch, you'll save <span class='fw-bold'>R{yearlyCostSaved:N2}</span> per year 
                and reduce your carbon footprint by <span class='fw-bold'>{carbonReduced:N1} kg CO₂</span> annually.
            </div>
        </div>";

        }
    }
}