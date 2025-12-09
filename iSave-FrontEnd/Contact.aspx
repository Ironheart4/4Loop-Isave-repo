<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="iSave_FrontEnd.Contact"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="p-5">
        <h1 class="fw-bold text-center mb-3">Contact Us</h1>
        <p class="text-center mb-5">Have questions about our products or need help with your energy savings journey?<br>
            We're here to help!</p>
        <div class="d-flex justify-content-center gap-4">
            <div class="shadow-lg p-3 mb-5 bg-body-white rounded">
                <h5 class="mb-4">Get in Touch</h5>
                <div class="col" id="links">
                    <div class="row mb-2 ">
                        <div class="d-flex align-items-center mb-2">
                            <i class="bi bi-envelope me-2 text-success"></i>
                            <p class="mb-0 fw-bold">Email</p>
                        </div>
                        <p class="ms-4 fw-lighter">support@isave.com</p>
                    </div>
                    <div class="row mb-2">
                        <div class="d-flex align-items-center mb-2">
                            <i class="bi bi-telephone-fill me-2 text-success"></i>
                            <p class="mb-0 fw-bold">Phone</p>
                        </div>
                        <p class="ms-4 fw-lighter">+1 (555) 123-4567
                            <br>Mon-Fri, 9AM-6PM EST
                        </p>
                    </div>
                    <div class="row mb-3">
                        <div class="d-flex align-items-center mb-2">
                            <i class="bi bi-clock me-2 text-success"></i>
                            <p class="mb-0 fw-bold">Business Hours</p>
                        </div>
                        <p class="ms-4 fw-lighter">Monday - Friday: 9:00 AM - 6:00 PM
                            <br>Saturday: 10:00 AM - 4:00 PM
                            <br>Sunday: Closed
                        </p>
                    </div>
                </div>
            </div>
            <div class="shadow-lg p-3 mb-5 bg-body-white rounded">
                <h5 class="mb-4">Send us a Message</h5>
                <div class="row g-3">
                    <div class="col">
                        <label for="fullname" class="form-label fw-bold">Name *</label>
                        <input type="text" class="form-control" placeholder="Your full name" aria-label="First name"
                            id="fullname">
                    </div>
                    <div class="col">
                        <label for="inputEmail4" class="form-label fw-bold">Email *</label>
                        <input type="email" class="form-control" placeholder="your.email@exmaple.com" id="inputEmail4">
                    </div>
                    <div class="col">
                        <label for="Inquiry " class="form-label fw-bold">Inquiry Type</label>
                        <select class="form-select" id="Inquiry">
                            <option>...</option>
                            <option>General Question</option>
                            <option>Product Information</option>
                            <option>Order Support</option>
                            <option>Technical Support</option>
                        </select>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <label for="Subject" class="form-label fw-bold">Subject</label>
                            <input type="text" class="form-control" placeholder="Brief Subject Line"
                                aria-label="First name" id="Subject">
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col">
                            <label for="Textarea1" class="form-label fw-bold">Message *</label>
                            <textarea class="form-control" id="Textarea1" rows="3"
                                placeholder="Tell us how can we help you"></textarea>
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="d-grid">
                            <button class="btn btn-success" type="button">
                                <i class="bi bi-send me-2"></i>
                                Send Message
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="mb-3 p-2">
        <h1 class="fw-bold text-center mb-3">Other Ways to Get Help</h1>
        <div class="d-flex justify-content-center gap-4">
            <div class="row">
                <div class="col">
                    <div class="card" style="width: 18rem;">
                        <i class="bi bi-chat-left-dots text-center mt-5 fs-2 text-success "></i>
                        <div class="card-body">
                            <h5 class="card-title text-center">Live Chat</h5>
                            <p class="card-text text-center fw-lighter">Get instant help from our support team during
                                business hours.</p>
                            <div class=" d-flex justify-content-center">
                                <button type="button" class="btn btn-outline-primary">Start Chat</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card" style="width: 18rem;">
                        <i class="bi bi-telephone-fill text-center mt-5 fs-2 text-success "></i>
                        <div class="card-body">
                            <h5 class="card-title text-center">Schedule a Call</h5>
                            <p class="card-text text-center fw-lighter">Book a consultation with our energy efficiency
                                experts.</p>
                            <div class=" d-flex justify-content-center">
                                <button type="button" class="btn btn-outline-warning">Book a Call</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card" style="width: 18rem;">
                        <i class="bi bi-geo-alt-fill text-center mt-5 fs-2 text-success "></i>
                        <div class="card-body">
                            <h5 class="card-title text-center">Visit a Store</h5>
                            <p class="card-text text-center fw-lighter">See our products in person and get hands-on
                                assistance.</p>
                            <div class=" d-flex justify-content-center">
                                <button type="button" class="btn btn-outline-danger">Find Stores</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
