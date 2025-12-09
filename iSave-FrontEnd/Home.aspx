<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="iSave_FrontEnd.Home"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Hero Section -->
  <div class="p-5" id="content">
    <div class="d-flex align-items-center flex-wrap">
      <div class="me-2">
        <h1 class="fw-bold">Save Energy</h1>
        <h1 class="fw-bold">Save Money</h1>
        <h1 class="fw-bold text-success">Save the Planet</h1>
        <p>Your personal energy coach with predictive insights, smart<br>
          recommendations, and real-time tracking to maximize<br> your savings</p>
        <div class="d-flex">
          <a class="btn btn-outline-success d-inline-flex align-items-center me-2" href="Products.aspx" role="button">
            Shop Products <i class="bi bi-arrow-right ms-2"></i>
          </a>
        </div>
      </div>
      <div>
        <img src="images/img.png" alt="Energy Saving" style="max-width:600px;">
      </div>
    </div>
  </div>

  <!-- Featured Products -->
  <div class="container py-5">
    <h1 class="fw-bold text-center mb-3">Featured Products</h1>
    <p class="text-center mb-5">Start saving today with our most popular energy-efficient solutions.</p>
    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-4" id="featuredProductsContainer" runat="server">
      <!-- Only 3 featured products will be loaded here -->
    </div>
    <!-- More Products Button -->
    <div class="d-flex justify-content-center mt-5">
      <a class="btn btn-outline-success" href="Products.aspx" role="button">View All Products <i
          class="bi bi-arrow-right ms-2"></i></a>
    </div>
  </div>

  <!-- Call to Action -->
  <div class="mt-2 py-3" style="background-color: #0f5132; color: white;" runat="server" id="HomeSignIn">
    <h1 class="fw-bold text-center mb-3 pt-2">Ready to Start Your Energy Journey?</h1>
    <p class="text-center mb-5">Join thousands of customers who are already saving money and helping the<br> environment
      with personalized energy coaching.</p>
    <div class="d-flex justify-content-center">
      <a class="btn btn-outline-warning d-inline-flex align-items-center mb-5" href="Login.aspx" role="button">
        <i class="bi bi-box-arrow-in-right me-2"></i> Sign Up
      </a>
    </div>
  </div>



</asp:Content>
