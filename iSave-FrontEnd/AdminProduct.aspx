<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminProduct.aspx.cs" Inherits="iSave_FrontEnd.AdminProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
    .product-card {
      display: flex;
      align-items: center;
      justify-content: space-between;
      background: #fff;
      padding: 15px;
      margin-bottom: 15px;
      border-radius: 8px;
      box-shadow: 0 2px 5px rgba(0,0,0,0.1);
    }
    .product-card img {
      width: 120px;
      height: 80px;
      object-fit: cover;
      border-radius: 5px;
      margin-right: 15px;
    }
    .product-info {
      flex: 1;
    }
    .product-info h4 {
      margin: 0;
      color: #333;
    }
    .product-info p {
      margin: 5px 0;
      font-size: 14px;
      color: #666;
    }
    .product-info .price {
      font-weight: bold;
      color: #ff9900;
      margin-top: 5px;
    }
    .actions button {
      padding: 8px 12px;
      border: none;
      border-radius: 5px;
      cursor: pointer;
      margin-left: 8px;
      font-weight: bold;
    }
    .btn-update {
      background-color: #4CAF50;
      color: white;
    }
    .btn-delete {
      background-color: #e53935;
      color: white;
    }
    .btn-update:hover {
      background-color: #43a047;
    }
    .btn-delete:hover {
      background-color: #c62828;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="d-flex justify-content-between align-items-center mb-4 mt-4">
         <h1 class="fw-bold">Add Product</h1>
</div>

 <div id="DisplayProducts" runat="server">

    

 </div>
</asp:Content>
