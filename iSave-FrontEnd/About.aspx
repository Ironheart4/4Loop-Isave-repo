<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="iSave_FrontEnd.About" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- About Content -->
  <div class="container py-5">
    <h1 class="fw-bold text-center mb-4">About iSave</h1>
    <p class="text-center lead mb-5">s
      At <span class="fw-bold text-success">iSave</span>, we are committed to making energy-efficient living
      simple, affordable, and accessible for everyone.
      Our mission is to help households and businesses save money while protecting the planet.
    </p>

    <div class="row text-center g-4">
      <div class="col-md-4">
        <i class="bi bi-lightbulb-fill text-success fs-1"></i>
        <h5 class="mt-2">Smart Solutions</h5>
        <p>We provide innovative products like LED lighting, smart thermostats, and solar panels to reduce energy
          usage.</p>
      </div>
      <div class="col-md-4">
        <i class="bi bi-people-fill text-warning fs-1"></i>
        <h5 class="mt-2">Community Impact</h5>
        <p>Thousands of people are already saving energy and money with iSave, contributing to a greener tomorrow.</p>
      </div>
      <div class="col-md-4">
        <i class="bi bi-globe-americas text-primary fs-1"></i>
        <h5 class="mt-2">Global Mission</h5>
        <p>Our vision is a world where every home and business uses energy responsibly for the benefit of all.</p>
      </div>
    </div>
  </div>

</asp:Content>
