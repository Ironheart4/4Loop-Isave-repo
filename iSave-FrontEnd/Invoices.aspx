<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="iSave_FrontEnd.Invoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Outer card -->
    <div class="max-w-3xl mx-auto bg-white rounded-xl shadow-md border p-6 space-y-6 mt-2 mb-2">

        <!-- Card header -->
        <div class="flex items-center justify-between border-b pb-4">
            <div class="flex items-center space-x-2 text-purple-700 font-semibold">
                <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none"
                    viewBox="0 0 24 24" stroke="currentColor">
                    <path d="M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z" />
                    <path d="M14 2v4a2 2 0 0 0 2 2h4" />
                    <path d="M10 9H8M16 13H8M16 17H8" />
                </svg>
                <span>All Invoices</span>
            </div>
             <a href="Dashboard.aspx" class="inline-flex items-center justify-center whitespace-nowrap text-sm font-medium transition-all disabled:pointer-events-none disabled:opacity-50 [&_svg]:pointer-events-none [&_svg:not([class*='size-'])]:size-4 shrink-0 [&_svg]:shrink-0 outline-none focus-visible:border-ring focus-visible:ring-ring/50 focus-visible:ring-[3px] aria-invalid:ring-destructive/20 dark:aria-invalid:ring-destructive/40 aria-invalid:border-destructive border bg-background shadow-xs hover:bg-accent hover:text-accent-foreground dark:bg-input/30 dark:border-input dark:hover:bg-input/50 h-8 rounded-md gap-1.5 px-3 has-[>svg]:px-2.5" data-discover="true">Back</a>
        </div>

        <!-- Invoice list -->
        <asp:Repeater ID="rptInvoices" runat="server">
            <ItemTemplate>
                <div class="flex items-center justify-between bg-gray-50 p-4 rounded-lg hover:bg-gray-100 transition">
                    <!-- Left section -->
                    <div class="flex items-center space-x-4">
                        <div class="bg-purple-100 p-2 rounded-lg">
                            <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5 text-purple-600" fill="none"
                                viewBox="0 0 24 24" stroke="currentColor">
                                <path d="M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z" />
                                <path d="M14 2v4a2 2 0 0 0 2 2h4" />
                                <path d="M10 9H8M16 13H8M16 17H8" />
                            </svg>
                        </div>
                        <div>
                            <h4 class="font-medium text-gray-900">Invoice #<%# Eval("InvoiceNumber") %></h4>
                            <p class="text-sm text-gray-600">Issued <%# Eval("IssuedDate", "{0:MMM d, yyyy}") %></p>
                        </div>
                    </div>

                    <!-- Right section -->
                    <div class="text-right">
                        <p class="font-semibold text-gray-900">R<%# Eval("TotalAmount", "{0:0.00}") %></p>
                        <p class="text-sm text-gray-600">
                            Status: 
                            <span class='<%# Eval("Status").ToString() == "Paid" ? "text-green-600 font-medium" : "text-red-600 font-medium" %>'>
                                <%# Eval("Status") %>
                            </span>
                        </p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
