<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="iSave_FrontEnd.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
       <style>
    .card .fw-bold {
        color: #0d6efd; /* Bootstrap primary color */
    }
    .card .bg-light {
        background-color: #f8f9fa !important;
    }
    .card .rounded {
        border-radius: 0.5rem !important;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div id="form1" runat="server">
        <div class="container mt-4">

            <!-- Summary Cards -->
            <div class="row text-center mb-4">
                <div class="col-md-3">
                    <div class="card shadow-sm p-3">
                        <h6>Total Orders</h6>
                        <h3 ID="totalOrders" runat="server"></h3>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card shadow-sm p-3">
                        <h6>Total Sales</h6>
                        <h3 ID="totalSales" runat="server"></h3>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card shadow-sm p-3">
                        <h6>Customers</h6>
                        <h3 ID="totalCustomers" runat="server"></h3>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="card shadow-sm p-3">
                        <h6>Total Products</h6>
                        <h3 ID="totalProducts" runat="server"></h3>
                    </div>
                </div>
            </div>

            <!-- Charts -->
            <div class="row mb-4">
                <div class="col-md-8">
                    <div class="card p-3">
                        <h6>Sales Trend</h6>
                        <canvas id="salesChart"></canvas>
                    </div>
                </div>
                  <div class="col-md-4">
                    <div class="card p-3">
                        <h6>Purchases Per Users</h6>
                        <canvas id="userPurchasesChart" width="400" height="400"></canvas>
                    </div>
                </div>
            </div>

            <!-- Top Products -->
            <div class="row mb-4">
                <div class="col-md-8">
                    <div class="card p-3">
                        <h6>Top Products</h6>
                        <canvas id="productChart"></canvas>
                    </div>
                </div>
                 <div class="col-md-4">
                    <div class="card p-3">
                        <h6>Revenue per Porduct</h6>
                        <canvas id="revenueChart" width="500" height="400"></canvas>
                    </div>
                </div>
            </div>
           
        </div>
    </div>

    <!-- Chart Script -->
<script>
    function generateColors(count) {
        const colors = [];
        for (let i = 0; i < count; i++) {
            const r = Math.floor(Math.random() * 255);
            const g = Math.floor(Math.random() * 255);
            const b = Math.floor(Math.random() * 255);
            colors.push(`rgba(${r}, ${g}, ${b}, 0.6)`);
        }
        return colors;
    }
    // Daily sales line chart
    var salesData = <%= SalesDataJson %>;
    var salesLabels = <%= SalesLabelsJson %>;

    if (salesData.length > 30) {
        salesData = salesData.slice(-30);
        salesLabels = salesLabels.slice(-30);
    }

    new Chart(document.getElementById('salesChart'), {
        type: 'line',
        data: {
            labels: salesLabels,
            datasets: [{
                label: 'Sales (R)',
                data: salesData,
                borderColor: 'blue',
                backgroundColor: 'rgba(0,0,255,0.1)',
                fill: true,
                tension: 0.3 // smooth line
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { display: true },
                tooltip: { mode: 'index', intersect: false }
            },
            scales: {
                x: {
                    display: true,
                    title: { display: true, text: 'Date' },
                    ticks: {
                        maxRotation: 45,
                        minRotation: 45,
                        autoSkip: true,
                        maxTicksLimit: 10 // show max 10 labels
                    }
                },
                y: {
                    display: true,
                    title: { display: true, text: 'Sales (R)' }
                }
            }
        }
    });

    // Top products bar chart
    var productData = <%= ProductDataJson %>;
    var productLabels = <%= ProductLabelsJson %>;

    var prodCol=  generateColors(productData.length)
    new Chart(document.getElementById('productChart'), {
        type: 'bar',
        data: {
            labels: productLabels,
            datasets: [{
                label: 'Units Sold',
                data: productData,
                backgroundColor: prodCol
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { display: true },
                tooltip: { mode: 'index', intersect: false }
            },
            scales: {
                x: { display: true, title: { display: true, text: 'Product' } },
                y: { display: true, title: { display: true, text: 'Units Sold' } }
            }
        }
    });

    var userPurchaseData = <%= UserPurchaseDataJson %>;
    var userPurchaseLabels = <%= UserPurchaseLabelsJson %>;


    var chartColors = generateColors(userPurchaseData.length);

    new Chart(document.getElementById('userPurchasesChart'), {
        type: 'pie',
        data: {
            labels: userPurchaseLabels,
            datasets: [{
                label: 'User Purchases',
                data: userPurchaseData,
                backgroundColor: chartColors,
                borderColor: 'rgba(255,255,255,1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'right'
                },
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            return context.label + ': ' + context.raw + ' purchases';
                        }
                    }
                }
            }
        }
    });

    var revenueData = <%= RevenueDataJson %>;
    var revenueLabels = <%= RevenueLabelsJson %>;

    var barColor = generateColors(revenueData.length);

  
    new Chart(document.getElementById('revenueChart'), {
        type: 'bar',
        data: {
            labels: revenueLabels,
            datasets: [{
                label: 'Revenue (R)',
                data: revenueData,
                backgroundColor: barColor
            }]
        },
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: true,
                    text: 'Revenue per Product'
                }
            }
        }
    });
</script>

</asp:Content>
