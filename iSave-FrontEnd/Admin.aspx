<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="iSave_FrontEnd.Admin" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .card .fw-bold {
        color: #0d6efd; /* Bootstrap primary color */
    }
    .card .bg-light {
        background-color: #f8f9fa !important;
    }
    .card .rounded {
        border-radius: 0.5rem !important;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-5">
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h1 class="fw-bold">Add Product</h1>

        </div>
        <div class="row">
            <!-- Left Column - Product Form -->
            <div class="col-md-8">
                <div class="card admin-card">
                    <div class="card-header bg-success text-white">
                        <h5 class="card-title mb-0"><i class="bi bi-plus-circle me-2"></i>Add New Product</h5>
                    </div>
                    <div class="card-body">
                        <div id="productForm">
                            <div class="form-section">
                                <h5 class="mb-3">Basic Information</h5>

                                <div class="mb-3">
                                    <label for="productName" class="form-label fw-bold">Product Name</label>
                                    <asp:TextBox runat="server" type="text" class="form-control" ID="productName" placeholder="Enter product name" required></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <label for="productImage" class="form-label fw-bold">Image URL</label>
                                    <asp:TextBox runat="server" type="url" class="form-control" ID="productImage" placeholder="https://example.com/image.jpg" required></asp:TextBox>
                                    <div class="form-text">Enter a direct link to the product image</div>
                                </div>

                                <div class="mb-3">
                                    <label for="productDescription" class="form-label fw-bold">Description</label>
                                    <textarea class="form-control" id="productDescription" rows="3" placeholder="Enter product description" runat="server" required></textarea>
                                </div>
                            </div>


                            <div class="form-section">
                                <h5 class="mb-3">Technical Specifications</h5>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="mb-3">
                                            <label for="energySaved" class="form-label fw-bold">Energy Saved (Watts)</label>
                                            <asp:TextBox runat="server" type="number" class="form-control" ID="energySaved" placeholder="e.g. 45" min="0" required></asp:TextBox>
                                            <div class="form-text">How many watts does this product save compared to standard alternatives?</div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="mb-3">
                                            <label for="carbonReduced" class="form-label fw-bold">Carbon Reduced (kg)</label>
                                            <asp:TextBox runat="server" type="number" class="form-control" ID="carbonReduced" placeholder="e.g. 120" min="0" step="0.1" required></asp:TextBox>
                                            <div class="form-text">Estimated carbon reduction per year in kilograms</div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="mb-3">
                                            <label for="productPrice" class="form-label fw-bold">Price (R)</label>
                                            <asp:TextBox runat="server" type="number" class="form-control" ID="productPrice" placeholder="e.g. 199.99" min="0" step="0.01" required>
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="mb-3">
                                            <label for="inStock" class="form-label fw-bold">In Stock</label>
                                            <asp:TextBox runat="server" type="text" class="form-control" ID="inStock" placeholder="e.g. 50" min="0" required></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="mb-3">
                                    <label for="productLink" class="form-label fw-bold">Product Link</label>
                                    <asp:TextBox runat="server" type="url" class="form-control" ID="productLink" placeholder="https://example.com/product-page" required></asp:TextBox>
                                    <div class="form-text">Link to the product page on your website</div>
                                </div>
                            </div>
                            <asp:Label runat="server" ID="ProductAdded" Text="" class="mb-3"></asp:Label>
                            <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                                <button type="reset" class="btn btn-outline-secondary me-md-2">Clear Form</button>
                                <asp:Button ID="btnAdd" Text="Add Product" runat="server" type="submit" class="btn btn-success" OnClick="btnAdd_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
