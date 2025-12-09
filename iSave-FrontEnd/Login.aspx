<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="iSave_FrontEnd.Login" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Login Form -->
  <div class="container d-flex justify-content-center align-items-center" style="min-height:80vh;">
    <div class="card shadow-lg p-4" style="width:400px;">
      <h3 class="text-center fw-bold mb-3">Sign In</h3>
      <div>
        <div class="mb-3">
          <label for="email" class="form-label fw-bold">Email</label>
           <asp:TextBox type="email" class="form-control" id="txtEmail" placeholder="you@example.com" required="yes" runat="server">
              </asp:TextBox>
        </div>
        <div class="mb-3">
          <label for="password" class="form-label fw-bold">Password</label>
          <asp:TextBox type="password" class="form-control" id="txtPassword" placeholder="Enter password" required="yes" runat="server">
              </asp:TextBox>
        </div>
          <asp:Label ID="LoginText" runat="server" Text=""></asp:Label>

        <asp:Button type="submit" class="btn btn-success w-100" runat="server" ID="btnLogin" Text="Sign In" OnClick="btnLogin_Click1"></asp:Button>
        <p class="text-center mt-3">Don't have an account? <a href="Register.aspx">sign Up</a></p>
      </div>
    </div>
  </div>
</asp:Content>
