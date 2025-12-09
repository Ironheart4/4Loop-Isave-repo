<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="iSave_FrontEnd.Products" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="p-5">
        <h1 class="fw-bold">Energy-Efficient Products</h1>
        <p class="fw-lighter">Discover smart solutions to reduce your energy consumption and save money.</p>
        <!-- Category filter section -->
        <div class="mt-4">
            <div class="d-flex justify-content-between align-items-center">
                <h4 id="currentCategory" class="mb-0">All Products</h4>
                <div class="form-group">
                    <select id="sortSelect" class="form-select" onchange="sortProducts(this.value)">
                        <option value="name" <%= GetSelectedSort("name") %>>Sort by Name</option>
                        <option value="price-low" <%= GetSelectedSort("price-low") %>>Price: Low to High</option>
                        <option value="price-high" <%= GetSelectedSort("price-high") %>>Price: High to Low</option>
                    </select>
                </div>
            </div>
            <hr>
        </div>
    </div>

    <div class="container my-4">
        <div class="row g-4 justify-content-center" runat="server" id="DisplayProducts">
        </div>

    </div>
    </div>
   <script>
       function sortProducts(value) {
           // Reload page with the selected sorting as query string
           window.location.href = "Products.aspx?sort=" + value;
       }
   </script>
</asp:Content>
