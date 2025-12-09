<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="iSave_FrontEnd.Register" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- Sign Up Form -->
  <div class="container d-flex justify-content-center align-items-center mt-4 mb-4" style="min-height:80vh;">
    <div class="card shadow-lg p-4" style="width:450px;">
      <h3 class="text-center fw-bold mb-3">Create Account</h3>
      <form>
        <div class="mb-3">
          <label for="fullname" class="form-label fw-bold">First Name</label>
          <asp:TextBox type="text" class="form-control" id="txtFirstName" placeholder="Enter First Name" required="yes" runat="server">
              </asp:TextBox>
        </div>
        <div class="mb-3">
          <label for="fullname" class="form-label fw-bold">Last Name</label>
          <asp:TextBox type="text" class="form-control" id="txtLaastName" placeholder="Enter Last Name" required="yes" runat="server">
              </asp:TextBox>
        </div>
        
        <div class="mb-3">
          <label for="email" class="form-label fw-bold">Email</label>
          <asp:TextBox type="email" class="form-control" id="txtEmail" placeholder="you@example.com" required="yes" runat="server">
              </asp:TextBox>
        </div>
          <div class="mb-3">
          <label for="phone" class="form-label fw-bold">Phone</label>
          <asp:TextBox type="number" class="form-control" id="txtPhone" placeholder="Enter phone" required="yes" runat="server">
              </asp:TextBox>
        </div>
        <div class="mb-3">
          <label for="password" class="form-label fw-bold">Password</label>
          <asp:TextBox type="password" class="form-control" id="txtPassword" placeholder="Enter password" required="yes" runat="server">
              </asp:TextBox>
        </div>
        <div class="mb-3">
          <label for="confirmpassword" class="form-label fw-bold">Confirm Password</label>
          <asp:TextBox type="password" class="form-control" id="txtConfirmPassword" placeholder="Re-enter password" runat="server" required="yes">
              </asp:TextBox>
        </div>
          <div class="mb-3">
             <label for="phone" class="form-label fw-bold">User Type</label>
              <asp:DropDownList ID="UserType" runat="server" required="yes">
                      <asp:ListItem Text="Select User Type" Value="" />
                    <asp:ListItem Text="Admin" Value="A" />
                    <asp:ListItem Text="Customer" Value="C" />
                 </asp:DropDownList>
          </div>
          <asp:Label ID="RegisterText" runat="server" Text=""></asp:Label>



        <asp:Button type="submit" class="btn btn-success w-100" runat="server" ID="btnSignUp" Text="Sign Up" OnClick="btnSignUp_Click"></asp:Button>
        <p class="text-center mt-3">Already have an account? <a href="Login.aspx">Sign In</a></p>
      </form>
    </div>
  </div>
</asp:Content>
