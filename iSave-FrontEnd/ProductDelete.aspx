<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductDelete.aspx.cs" Inherits="iSave_FrontEnd.ProductDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="card shadow p-4">
            <h3 class="text-danger">Delete Product</h3>
            <hr />

            <!-- Product Preview -->
            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:Image ID="imgProduct" runat="server" CssClass="img-fluid rounded border" Width="200" Height="150" />
                </div>
                <div class="col-md-8">
                    <h4><asp:Label ID="lblProductName" runat="server"></asp:Label></h4>
                    <p><strong>Product ID:</strong> <asp:Label ID="lblProductId" runat="server"></asp:Label></p>
                    <p><strong>Price:</strong> R<asp:Label ID="lblProductPrice" runat="server"></asp:Label></p>
                </div>
            </div>

            <!-- Confirmation message -->
            <asp:Label ID="lblMessage" runat="server" CssClass="mb-3 d-block text-danger fw-bold"></asp:Label>

            <!-- Buttons -->
         <asp:Button ID="btnConfirmDelete" CssClass="btn btn-danger" runat="server" Text="Confirm Delete" OnClick="btnConfirmDelete_Click" />
            <a href="AdminProduct.aspx" class="btn btn-secondary mt-2">Cancel</a>
        </div>
</asp:Content>
