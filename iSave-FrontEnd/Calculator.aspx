<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="iSave_FrontEnd.Calculator" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        :root{
            --accent-green: #16a34a;      /* text green */
            --accent-green-soft: #ecfdf3; /* light green background */
            --accent-yellow: #fff6e5;     /* pale yellow */
            --accent-yellow-accent: #c76b00; /* yellow text */
            --accent-blue-soft: #eaf4ff;  /* pale blue */
            --muted: #6c757d;
        }

        /* Container */
        .savings-panel {
            display: flex;
            flex-direction: column;
            gap: 18px;
        }

        /* ENERGY card (large green box) */
        .energy-card {
            background: var(--accent-green-soft);
            border-radius: 14px;
            padding: 18px;
            border: 1px solid rgba(22,163,74,0.06);
            box-shadow: 0 6px 18px rgba(16,24,40,0.03);
        }
        .energy-card .title {
            display:flex;
            align-items:center;
            gap:10px;
            color: var(--accent-green);
            font-weight:700;
            font-size: 14px;
        }
        .energy-card .title .icon {
            background: rgba(22,163,74,0.12);
            padding: 8px;
            border-radius: 8px;
            display:inline-flex;
            align-items:center;
            justify-content:center;
            font-size: 16px;
            color: var(--accent-green);
        }
        .energy-card .big-value {
            font-size: 34px;
            font-weight: 800;
            margin-top: 8px;
            color: var(--accent-green);
            letter-spacing: -0.02em;
        }
        .energy-card .subtitle {
            margin-top:6px;
            font-weight:600;
            color: rgba(0,0,0,0.65);
        }

        /* Cost savings block with three small boxes */
        .cost-card {
            background: #ffffff;
            border-radius: 12px;
            padding: 14px;
            border: 1px solid rgba(0,0,0,0.04);
            box-shadow: 0 6px 18px rgba(16,24,40,0.03);
        }
        .cost-card .heading {
            font-weight:700;
            margin-bottom: 8px;
        }
        .cost-grid {
            display:flex;
            gap: 12px;
        }
        .cost-box {
            flex:1;
            background: var(--accent-yellow);
            border-radius: 10px;
            padding: 12px 10px;
            text-align:center;
            border: 1px solid rgba(0,0,0,0.03);
            min-width: 0;
        }
        .cost-box .amount {
            font-weight: 800;
            font-size: 18px;
            color: var(--accent-yellow-accent);
        }
        .cost-box .label {
            display:block;
            margin-top:6px;
            font-size: 12px;
            color: var(--muted);
        }

        /* Environmental impact */
        .env-card {
            background: var(--accent-green-soft);
            border-radius: 12px;
            padding: 14px;
            border: 1px solid rgba(22,163,74,0.06);
            box-shadow: 0 6px 18px rgba(16,24,40,0.03);
        }
        .env-card .heading {
            color: var(--accent-green);
            font-weight:700;
        }
        .env-card .value {
            margin-top:8px;
            font-size: 22px;
            font-weight:800;
            color: var(--accent-green);
        }
        .env-card .muted {
            margin-top:6px;
            color: rgba(0,0,0,0.6);
        }

        /* Summary */
        .summary-box {
            background: var(--accent-blue-soft);
            border-radius: 12px;
            padding: 12px;
            border: 1px solid rgba(37,99,235,0.06);
            box-shadow: 0 6px 18px rgba(16,24,40,0.03);
            color: #0f172a;
        }
        .summary-box .title {
            font-weight:700;
            margin-bottom:6px;
        }
        .summary-box .text {
            color: rgba(0,0,0,0.7);
            font-size: 13px;
        }

        /* Responsive: stack cost boxes on small screens */
        @media (max-width: 576px) {
            .cost-grid { flex-direction: column; }
        }

        /* Keep previous small result element styles from before (if used) */
        .calculation-formula p { margin:0 0 6px 0; }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="p-5">
        <div class="d-flex justify-content-center align-items-center">
            <div class="logo-box me-2">
                <i class="bi bi-calculator"></i>
            </div>
        </div>
        <h4 class="fw-bold text-center">Energy Savings Calculator</h4>
        <p class="fw-lighter text-center">Calculate exactly how much energy and money you'll save by switching to energy-efficient products.</p>
        
        <div class="container my-5">
            <div class="row justify-content-center">
                <!-- Left Column (unchanged) -->
                <div class="col-md-6 col-lg-5">
                    <div class="shadow p-4 mb-5 bg-body rounded savings-card">
                        <h4 class="fw-bold mb-3">Energy Usage Details</h4>

                        <!-- Row 1 -->
                        <div class="row g-3">
                            <div class="col-md-6">
                                <label for="watts" class="form-label fw-bold">Current Watts</label>
                                <input type="number" class="form-control" placeholder="e.g 60" runat="server" id="txtCurrentWatts" min="1">
                                <p class="fw-lighter small">Power consumption of your current device</p>
                            </div>
                            <div class="col-md-6">
                                <label for="newWatts" class="form-label fw-bold">New Watts</label>
                                <input type="number" class="form-control" placeholder="e.g 12" runat="server" id="txtNewWatts" min="1">
                                <p class="fw-lighter small">Power consumption of the energy-efficient alternative</p>
                            </div>
                        </div>

                        <!-- Row 2 -->
                        <div class="row g-3 mt-2">
                            <div class="col-md-6">
                                <label for="hr" class="form-label fw-bold">Hours per Day</label>
                                <input type="number" class="form-control" placeholder="e.g 8" runat="server" id="txtHoursPerDay" min="1" max="24">
                                <p class="fw-lighter small">How many hours per day is it used?</p>
                            </div>
                            <div class="col-md-6">
                                <label for="day" class="form-label fw-bold">Days per Week</label>
                                <input type="number" class="form-control" placeholder="e.g 7" runat="server" id="txtDaysPerWeek" min="1" max="7">
                                <p class="fw-lighter small">How many days per week is it used?</p>
                            </div>
                        </div>

                        <!-- Row 3 -->
                        <div class="mt-3">
                            <label for="electricity" class="form-label fw-bold">Electricity Rate (R per kWh)</label>
                            <input type="number" class="form-control" placeholder="e.g 2.50" runat="server" id="txtElectricity" min="0.1" step="0.01">
                            <p class="fw-lighter small">Enter your electricity cost per kWh</p>
                        </div>

                        <!-- Button -->
                        <div class="mt-4">
                            <asp:Button ID="calculateBtn" class="btn btn-success w-100" runat="server" Text="Calculate Savings" OnClick="calculateBtn_Click" />
                      
                        </div>
                    </div>
                </div>

                 <!-- Right Column (new styled panel matching the image) -->
                <div class="col-md-6 col-lg-5">
                    <div class="shadow p-4 mb-5 bg-body rounded savings-card">
                         <!-- Title -->
                        <h4 class="fw-bold mb-3">
                            <i class="bi bi-graph-up-arrow text-success me-2"></i> Your Savings
                        </h4>

                        <!-- Results / visual panel -->
                        <div id="resultsContainer" class="savings-panel" runat="server">
                            
                           

                        </div> <!-- /resultsContainer -->
                    </div> <!-- /panel -->
                </div> <!-- /right column -->
            </div> <!-- /row -->
        </div> <!-- /container -->
    </div> <!-- /p-5 -->

</asp:Content>
