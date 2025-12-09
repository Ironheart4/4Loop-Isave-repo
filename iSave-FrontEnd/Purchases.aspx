<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Purchases.aspx.cs" Inherits="iSave_FrontEnd.Purchases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="max-w-3xl mx-auto bg-white rounded-xl shadow-md border p-6 space-y-6">

    <!-- Card header -->
    <div class="flex items-center justify-between border-b pb-4 mt-2 mb-2">
        <div class="flex items-center space-x-2 text-blue-700 font-semibold">
            <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path d="M8 2v4M16 2v4M3 10h18M3 4h18v18H3V4z" />
            </svg>
            <span>All Purchases</span>
        </div>
         <a href="Dashboard.aspx" class="inline-flex items-center justify-center whitespace-nowrap text-sm font-medium transition-all disabled:pointer-events-none disabled:opacity-50 [&_svg]:pointer-events-none [&_svg:not([class*='size-'])]:size-4 shrink-0 [&_svg]:shrink-0 outline-none focus-visible:border-ring focus-visible:ring-ring/50 focus-visible:ring-[3px] aria-invalid:ring-destructive/20 dark:aria-invalid:ring-destructive/40 aria-invalid:border-destructive border bg-background shadow-xs hover:bg-accent hover:text-accent-foreground dark:bg-input/30 dark:border-input dark:hover:bg-input/50 h-8 rounded-md gap-1.5 px-3 has-[>svg]:px-2.5" data-discover="true">Back</a>
    </div>

    <!-- Purchases list -->
    <div class="space-y-4">
        <asp:Repeater ID="rptPurchases" runat="server">
            <ItemTemplate>
                <div class="flex items-center justify-between p-4 bg-gray-50 rounded-lg shadow-sm hover:bg-gray-100 transition">
                    
                    <!-- Left: Product info -->
                    <div class="flex items-center space-x-4">
                        <div class="bg-blue-100 p-2 rounded-lg">
                            <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5 text-blue-600" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                <path d="M4 14a1 1 0 0 1-.78-1.63l9.9-10.2a.5.5 0 0 1 .86.46l-1.92 6.02A1 1 0 0 0 13 10h7a1 1 0 0 1 .78 1.63l-9.9 10.2a.5.5 0 0 1-.86-.46l1.92-6.02A1 1 0 0 0 11 14z"/>
                            </svg>
                        </div>
                        <div>
                            <h4 class="font-medium text-gray-900"><%# Eval("ProductName") %></h4>
                            <p class="text-sm text-gray-600">Purchased <%# Eval("PurchaseDate", "{0:M/d/yyyy}") %></p>
                        </div>
                    </div>

                    <!-- Right: Price and savings -->
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
</asp:Content>
