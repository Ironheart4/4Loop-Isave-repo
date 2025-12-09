<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="iSave_FrontEnd.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="min-h-screen bg-gray-50">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
            <!-- Header -->
            <div class="mb-8">
                <div class="flex flex-col sm:flex-row sm:items-center sm:justify-between">
                    <div>
                        <h1 class="text-3xl font-bold text-gray-900">Welcome back, <asp:Label ID="lblUserName" runat="server" Text="Demo" />! 👋</h1>
                        <p class="text-gray-600 mt-1">Here's your personalized energy savings dashboard</p>
                    </div>
                </div>
            </div>
            <!-- Stats Cards -->
            <div class="grid grid-cols-1 md:grid-cols-4 gap-6 mb-8">
                <div class="bg-card text-card-foreground flex flex-col gap-6 rounded-xl border py-6 shadow-sm border-green-200">
                    <div class="p-6">
                        <div class="flex items-center justify-between">
                            <div>
                                <p class="text-sm font-medium text-gray-600">Energy Saved</p>
                                <asp:Label ID="lblEnergySaved" runat="server" CssClass="text-2xl font-bold text-green-600" Text="0W" />
                            </div>
                            <div class="bg-green-100 p-3 rounded-full">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-zap h-6 w-6 text-green-600" aria-hidden="true">
                                    <path d="M4 14a1 1 0 0 1-.78-1.63l9.9-10.2a.5.5 0 0 1 .86.46l-1.92 6.02A1 1 0 0 0 13 10h7a1 1 0 0 1 .78 1.63l-9.9 10.2a.5.5 0 0 1-.86-.46l1.92-6.02A1 1 0 0 0 11 14z"></path>
                                </svg>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="bg-card text-card-foreground flex flex-col gap-6 rounded-xl border py-6 shadow-sm border-yellow-200">
                    <div class="p-6">
                        <div class="flex items-center justify-between">
                            <div>
                                <p class="text-sm font-medium text-gray-600">Money Saved</p>
                                <asp:Label ID="lblMoneySaved" runat="server" CssClass="text-2xl font-bold text-yellow-600" Text="$0" />
                                <p class="text-xs text-gray-500">per month</p>
                            </div>
                            <div class="bg-yellow-100 p-3 rounded-full">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-dollar-sign h-6 w-6 text-yellow-600" aria-hidden="true">
                                    <line x1="12" x2="12" y1="2" y2="22"></line>
                                    <path d="M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6"></path>
                                </svg>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="bg-card text-card-foreground flex flex-col gap-6 rounded-xl border py-6 shadow-sm border-green-200">
                    <div class="p-6">
                        <div class="flex items-center justify-between">
                            <div>
                                <p class="text-sm font-medium text-gray-600">CO₂ Reduced</p>
                                <asp:Label ID="lblCO2Reduced" runat="server" CssClass="text-2xl font-bold text-green-600" Text="0kg" />
                                <p class="text-xs text-gray-500">annually</p>
                            </div>
                            <div class="bg-green-100 p-3 rounded-full">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-leaf h-6 w-6 text-green-600" aria-hidden="true">
                                    <path d="M11 20A7 7 0 0 1 9.8 6.1C15.5 5 17 4.48 19 2c1 2 2 4.18 2 8 0 5.5-4.78 10-10 10Z"></path>
                                    <path d="M2 21c0-3 1.85-5.36 5.08-6C9.5 14.52 12 13 13 12"></path>
                                </svg>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="bg-card text-card-foreground flex flex-col gap-6 rounded-xl border py-6 shadow-sm border-blue-200">
                    <div class="p-6">
                        <div class="flex items-center justify-between">
                            <div>
                                <p class="text-sm font-medium text-gray-600">Yearly Projection</p>
                                <asp:Label ID="lblYearlyProjection" runat="server" CssClass="text-2xl font-bold text-blue-600" Text="$0" />
                                <p class="text-xs text-gray-500">estimated</p>
                            </div>
                            <div class="bg-blue-100 p-3 rounded-full">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-trending-up h-6 w-6 text-blue-600" aria-hidden="true">
                                    <polyline points="22 7 13.5 15.5 8.5 10.5 2 17"></polyline>
                                    <polyline points="16 7 22 7 22 13"></polyline>
                                </svg>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Milestone Progress -->
            <div class="bg-card text-card-foreground flex flex-col gap-6 rounded-xl border py-6 shadow-sm mb-8 border-purple-200">
                <div class="@container/card-header grid auto-rows-min grid-rows-[auto_auto] items-start gap-1.5 px-6 has-data-[slot=card-action]:grid-cols-[1fr_auto] [.border-b]:pb-6">
                    <div class="leading-none font-semibold flex items-center space-x-2">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-target h-5 w-5 text-purple-600" aria-hidden="true">
                            <circle cx="12" cy="12" r="10"></circle>
                            <circle cx="12" cy="12" r="6"></circle>
                            <circle cx="12" cy="12" r="2"></circle>
                        </svg>
                        <span>Next Milestone</span>
                    </div>
                </div>
                <div class="px-6">
                    <div class="space-y-4">
                        <div class="flex justify-between items-center">
                            <span class="text-sm font-medium text-gray-700">Achieve R200 monthly savings to become an Energy Master!</span>
                            <span class="text-sm text-gray-500"><asp:Label ID="lblMilestoneProgress" runat="server" Text="R0.00 / R200" /></span>
                        </div>
                        <div id="progressBar" aria-valuemax="100" aria-valuemin="0" aria-valuenow="0" role="progressbar" data-state="indeterminate" data-max="100" class="bg-primary/20 relative w-full overflow-hidden rounded-full h-3">
                            <div data-state="indeterminate" data-max="100" class="bg-primary h-full w-full flex-1 transition-all" style="transform: translateX(-<asp:Literal ID="litProgressPercent" runat="server" Text="100" />%);"></div>
                        </div>
                        <p class="text-xs text-gray-500"><asp:Label ID="lblMilestoneRemaining" runat="server" Text="R200.00 more to reach your goal!" /></p>
                    </div>
                </div>
            </div>
            <!-- Savings Trends and Achievements -->
            <div class="grid grid-cols-1 lg:grid-cols-3 gap-8 mb-8">
                <div class="lg:col-span-2">
                    <div class="bg-card text-card-foreground flex flex-col gap-6 rounded-xl border py-6 shadow-sm">
                        <div class="@container/card-header grid auto-rows-min grid-rows-[auto_auto] items-start gap-1.5 px-6 has-data-[slot=card-action]:grid-cols-[1fr_auto] [.border-b]:pb-6">
                            <div class="leading-none font-semibold flex items-center space-x-2">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-trending-up h-5 w-5 text-green-600" aria-hidden="true">
                                    <polyline points="22 7 13.5 15.5 8.5 10.5 2 17"></polyline>
                                    <polyline points="16 7 22 7 22 13"></polyline>
                                </svg>
                                <span>Savings Trends</span>
                            </div>
                        </div>
                        <div class="px-6">
                            <div class="h-80">
                                <canvas id="savingsChart" style="width: 100%; height: 100%;"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="bg-card text-card-foreground flex flex-col gap-6 rounded-xl border py-6 shadow-sm">
                        <div class="@container/card-header grid auto-rows-min grid-rows-[auto_auto] items-start gap-1.5 px-6 has-data-[slot=card-action]:grid-cols-[1fr_auto] [.border-b]:pb-6">
                            <div class="leading-none font-semibold flex items-center space-x-2">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-award h-5 w-5 text-yellow-600" aria-hidden="true">
                                    <path d="m15.477 12.89 1.515 8.526a.5.5 0 0 1-.81.47l-3.58-2.687a1 1 0 0 0-1.197 0l-3.586 2.686a.5.5 0 0 1-.81-.469l1.514-8.526"></path>
                                    <circle cx="12" cy="8" r="6"></circle>
                                </svg>
                                <span>Achievements</span>
                            </div>
                        </div>
                        <div class="px-6">
                            <div class="space-y-4">
                                <asp:Repeater ID="rptAchievements" runat="server">
                                    <ItemTemplate>
                                        <div class="flex items-center space-x-3 p-3 bg-gradient-to-r from-yellow-50 to-orange-50 rounded-lg border border-yellow-200">
                                            <div class="flex-1">
                                                <div class="flex items-center space-x-2 mb-1">
                                                    <h4 class="font-semibold text-gray-900 text-sm"><%# Eval("Title") %></h4>
                                                    <span class="inline-flex items-center justify-center rounded-md border px-2 py-0.5 font-medium w-fit whitespace-nowrap shrink-0 [&>svg]:size-3 gap-1 [&>svg]:pointer-events-none focus-visible:border-ring focus-visible:ring-ring/50 focus-visible:ring-[3px] aria-invalid:ring-destructive/20 dark:aria-invalid:ring-destructive/40 aria-invalid:border-destructive transition-[color,box-shadow] overflow-hidden border-transparent bg-secondary text-secondary-foreground [a&]:hover:bg-secondary/90 text-xs"><%# Eval("Category") %></span>
                                                </div>
                                                <p class="text-gray-600 text-xs mb-2"><%# Eval("Description") %></p>
                                                <div class="flex items-center space-x-1 text-xs text-gray-500">
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-calendar h-3 w-3" aria-hidden="true">
                                                        <path d="M8 2v4"></path>
                                                        <path d="M16 2v4"></path>
                                                        <rect width="18" height="18" x="3" y="4" rx="2"></rect>
                                                        <path d="M3 10h18"></path>
                                                    </svg>
                                                    <span>Earned <%# Eval("EarnedDate", "{0:M/d/yyyy}") %></span>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="border-t pt-4">
                                    <h5 class="font-medium text-gray-700 mb-3 text-sm">Upcoming Achievements</h5>
                                    <div class="space-y-2">
                                        <asp:Repeater ID="rptUpcomingAchievements" runat="server">
                                            <ItemTemplate>
                                                <div class="flex items-center space-x-3 p-2 bg-gray-50 rounded-lg opacity-60">
                                                    <div>
                                                        <p class="font-medium text-gray-700 text-sm"><%# Eval("Title") %></p>
                                                        <p class="text-xs text-gray-500"><%# Eval("Description") %></p>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Recent Purchases and Invoices -->
            <div class="grid grid-cols-1 lg:grid-cols-2 gap-8">
                <div class="bg-card text-card-foreground flex flex-col gap-6 rounded-xl border py-6 shadow-sm">
                    <div class="@container/card-header grid auto-rows-min grid-rows-[auto_auto] items-start gap-1.5 px-6 has-data-[slot=card-action]:grid-cols-[1fr_auto] [.border-b]:pb-6">
                        <div class="flex items-center justify-between">
                            <div class="leading-none font-semibold flex items-center space-x-2">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-calendar h-5 w-5 text-blue-600" aria-hidden="true">
                                    <path d="M8 2v4"></path>
                                    <path d="M16 2v4"></path>
                                    <rect width="18" height="18" x="3" y="4" rx="2"></rect>
                                    <path d="M3 10h18"></path>
                                </svg>
                                <span>Recent Purchases</span>
                            </div>
                            <a href="Purchases.aspx" class="inline-flex items-center justify-center whitespace-nowrap text-sm font-medium transition-all disabled:pointer-events-none disabled:opacity-50 [&_svg]:pointer-events-none [&_svg:not([class*='size-'])]:size-4 shrink-0 [&_svg]:shrink-0 outline-none focus-visible:border-ring focus-visible:ring-ring/50 focus-visible:ring-[3px] aria-invalid:ring-destructive/20 dark:aria-invalid:ring-destructive/40 aria-invalid:border-destructive border bg-background shadow-xs hover:bg-accent hover:text-accent-foreground dark:bg-input/30 dark:border-input dark:hover:bg-input/50 h-8 rounded-md gap-1.5 px-3 has-[>svg]:px-2.5" data-discover="true">View All</a>
                        </div>
                    </div>
                    <div class="px-6">
                        <div class="space-y-4">
                            <asp:Repeater ID="rptPurchases" runat="server">
                                <ItemTemplate>
                                    <div class="flex items-center justify-between p-4 bg-gray-50 rounded-lg">
                                        <div class="flex items-center space-x-4">
                                            <div class="bg-blue-100 p-2 rounded-lg">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-zap h-5 w-5 text-blue-600" aria-hidden="true">
                                                    <path d="M4 14a1 1 0 0 1-.78-1.63l9.9-10.2a.5.5 0 0 1 .86.46l-1.92 6.02A1 1 0 0 0 13 10h7a1 1 0 0 1 .78 1.63l-9.9 10.2a.5.5 0 0 1-.86-.46l1.92-6.02A1 1 0 0 0 11 14z"></path>
                                                </svg>
                                            </div>
                                            <div>
                                                <h4 class="font-medium text-gray-900"><%# Eval("ProductName") %></h4>
                                                <p class="text-sm text-gray-600">Purchased <%# Eval("PurchaseDate", "{0:M/d/yyyy}") %></p>
                                            </div>
                                        </div>
                                        <div class="text-right">
                                            <p class="font-medium text-gray-900">R<%# Eval("Price", "{0:0.00}") %></p>
                                            <p class="text-sm text-green-600">Saves R<%# Eval("MonthlySavings", "{0:0.0}") %>/month</p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Panel ID="pnlNoPurchases" runat="server" Visible="false" CssClass="text-center py-8">
                                        <p class="text-gray-600">No purchases yet.</p>
                                    </asp:Panel>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="bg-card text-card-foreground flex flex-col gap-6 rounded-xl border py-6 shadow-sm">
                    <div class="@container/card-header grid auto-rows-min grid-rows-[auto_auto] items-start gap-1.5 px-6 has-data-[slot=card-action]:grid-cols-[1fr_auto] [.border-b]:pb-6">
                        <div class="flex items-center justify-between">
                            <div class="leading-none font-semibold flex items-center space-x-2">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-file-text h-5 w-5 text-purple-600" aria-hidden="true">
                                    <path d="M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z"></path>
                                    <path d="M14 2v4a2 2 0 0 0 2 2h4"></path>
                                    <path d="M10 9H8"></path>
                                    <path d="M16 13H8"></path>
                                    <path d="M16 17H8"></path>
                                </svg>
                                <span>Recent Invoices</span>
                            </div>
                            <a href="Invoices.aspx" class="inline-flex items-center justify-center whitespace-nowrap text-sm font-medium transition-all disabled:pointer-events-none disabled:opacity-50 [&_svg]:pointer-events-none [&_svg:not([class*='size-'])]:size-4 shrink-0 [&_svg]:shrink-0 outline-none focus-visible:border-ring focus-visible:ring-ring/50 focus-visible:ring-[3px] aria-invalid:ring-destructive/20 dark:aria-invalid:ring-destructive/40 aria-invalid:border-destructive border bg-background shadow-xs hover:bg-accent hover:text-accent-foreground dark:bg-input/30 dark:border-input dark:hover:bg-input/50 h-8 rounded-md gap-1.5 px-3 has-[>svg]:px-2.5" data-discover="true">View All</a>
                        </div>
                    </div>
                    <div class="px-6">
                        <div class="space-y-4">
                            <asp:Repeater ID="rptInvoices" runat="server">
                                <ItemTemplate>
                                    <div class="flex items-center justify-between p-4 bg-gray-50 rounded-lg">
                                        <div class="flex items-center space-x-4">
                                            <div class="bg-purple-100 p-2 rounded-lg">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-file-text h-5 w-5 text-purple-600" aria-hidden="true">
                                                    <path d="M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z"></path>
                                                    <path d="M14 2v4a2 2 0 0 0 2 2h4"></path>
                                                    <path d="M10 9H8"></path>
                                                    <path d="M16 13H8"></path>
                                                    <path d="M16 17H8"></path>
                                                </svg>
                                            </div>
                                            <div>
                                                <h4 class="font-medium text-gray-900">Invoice #<%# Eval("InvoiceNumber") %></h4>
                                                <p class="text-sm text-gray-600">Issued <%# Eval("IssuedDate", "{0:M/d/yyyy}") %></p>
                                            </div>
                                        </div>
                                        <div class="text-right">
                                            <p class="font-medium text-gray-900">R<%# Eval("TotalAmount", "{0:0.00}") %></p>
                                            <p class="text-sm text-gray-600">Status: <%# Eval("Status") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="text-center py-8">
                                        <p class="text-gray-600">No invoices yet.</p>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Chart.js Initialization Script -->
       <script>
           function initChart(chartData) {
               var ctx = document.getElementById('savingsChart').getContext('2d');
               new Chart(ctx, {
                   type: 'line',
                   data: {
                       labels: chartData.labels,
                       datasets: [
                           {
                               label: 'Money Saved (R)',
                               data: chartData.money,
                               borderColor: '#eab308',
                               borderWidth: 3,
                               fill: false,
                               tension: 0.1
                           },
                           {
                               label: 'Energy Saved (W)',
                               data: chartData.energy,
                               borderColor: '#16a34a',
                               borderWidth: 3,
                               fill: false,
                               tension: 0.1
                           },
                           {
                               label: 'CO₂ Reduced (kg)',
                               data: chartData.co2,
                               borderColor: '#059669',
                               borderWidth: 3,
                               fill: false, 
                               tension: 0.1
                           }
                       ]
                   },
                   options: {
                       responsive: true,
                       maintainAspectRatio: false,
                       scales: {
                           y: {
                               beginAtZero: true
                           }
                       },
                       plugins: {
                           legend: {
                               position: 'bottom'
                           }
                       }
                   }
               });
           }
           // Update progress bar aria-valuenow dynamically
           function updateProgressBar() {
               var inverseProgressPercent = parseFloat('<%= litProgressPercent.Text %>');
               var progressPercent = 100 - inverseProgressPercent; // Convert to actual progress
               var progressBar = document.getElementById('progressBar');
               if (progressBar) {
                   progressBar.setAttribute('aria-valuenow', progressPercent.toFixed(0));
               }
           }
           window.onload = updateProgressBar;
       </script>
    </div>
</asp:Content>