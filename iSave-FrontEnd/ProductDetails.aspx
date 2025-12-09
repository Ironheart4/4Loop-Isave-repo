<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="iSave_FrontEnd.ProductDetails" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container py-5">
    <a href="Products.aspx" class="text-success mb-3 d-inline-block" style="text-decoration: none;">&larr; Back to
      Products</a>
    <div class="row">
      <div class="col-md-6">
        <div class="product-image" runat="server"  id="image">
         
        </div>
      </div>
      <div class="col-md-6">
        <h2 id="productName" runat="server"></h2>
        <p id="productDescription" runat="server"></p>
        <h3 class="mb-4" id="productPrice" runat="server"></h3>
        <div class="mb-3 d-flex align-items-center gap-2">
          <label for="quantityInput" class="fw-bold mb-0">Quantity:</label>
          <input type="number" id="quantityInput" value="1" min="1" class="form-control" style="width:80px;">
        </div>
          <div runat="server" id="BtnCart">

          </div>
        

        <div class="d-flex gap-2">
          <a class="btn btn-outline-warning flex-fill" href="Calculator.aspx" role="button">Calculate My Savings</a>
          <a  class="btn btn-outline-danger flex-fill" role="button">Add to Wishlist</a>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
