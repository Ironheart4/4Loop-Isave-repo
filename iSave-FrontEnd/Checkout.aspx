<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="iSave_FrontEnd.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #f8f9fa;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .checkout-container {
            max-width: 800px;
            margin: 2rem auto;
            background: white;
            border-radius: 10px;
            box-shadow: 0 0 20px rgba(0,0,0,0.1);
            overflow: hidden;
        }

        .checkout-header {
            background-color: green;
            color: white;
            padding: 1.5rem;
            text-align: center;
        }

        .section-title {
            border-bottom: 1px solid #e9ecef;
            padding-bottom: 0.5rem;
            margin-bottom: 1rem;
            font-weight: 600;
        }

        .info-card {
            background-color: #f8f9fa;
            border-radius: 8px;
            padding: 1rem;
            margin-bottom: 1rem;
        }

        .payment-card {
            background-color: #f8f9fa;
            border-radius: 8px;
            padding: 1rem;
            margin-bottom: 1rem;
        }

        .order-item {
            display: flex;
            justify-content: space-between;
            padding: 0.5rem 0;
            border-bottom: 1px solid #e9ecef;
        }

        .order-summary {
            background-color: #f8f9fa;
            border-radius: 8px;
            padding: 1rem;
        }

        .total-section {
            background-color: #e9ecef;
            padding: 1rem;
            border-radius: 8px;
            margin-top: 1rem;
        }

        .btn-checkout {
            background-color: green;
            color: white;
            font-weight: 600;
            padding: 0.75rem;
            border: none;
            border-radius: 8px;
            width: 100%;
            font-size: 1.1rem;
            margin-top: 1rem;
        }

            .btn-checkout:hover {
                background-color: #0b5ed7;
            }

        .secure-text {
            font-size: 0.85rem;
            color: #6c757d;
            text-align: center;
            margin-top: 0.5rem;
        }

        .divider {
            height: 1px;
            background-color: #e9ecef;
            margin: 1.5rem 0;
        }

        .form-label {
            font-weight: 600;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-4">
        <div class="checkout-header mb-4">
            <h1><i class="fas fa-shopping-cart me-2"></i>Checkout</h1>
        </div>

        <div class="row">
            <!-- Left Column: Shipping & Payment -->
            <div class="col-md-6">
                <!-- Shipping Information -->
                <div class="mb-4">
                    <h3 class="section-title">Shipping Information</h3>
                    <div class="info-card mb-3">
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="form-label">Full Name</label>
                                <input type="text" class="form-control" id="txtfullName" runat="server" required>
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Email Address</label>
                                <input type="email" class="form-control" id="txtemail" runat="server" required>
                            </div>
                        </div>
                    </div>

                    <div class="info-card">
                        <label class="form-label">Shipping Address</label>
                        <textarea class="form-control" id="txtshippingAddress" rows="2" required runat="server"></textarea>
                    </div>
                </div>

                <!-- Payment Details -->
                <div class="mb-4">
                    <h3 class="section-title">Payment Details</h3>
                    <div class="payment-card p-3">
                        <div class="row mb-3">
                            <div class="col-md-8">
                                <label class="form-label">Card Number</label>
                                <input type="text" class="form-control" id="cardNo" runat="server"
                                    required placeholder="**** **** **** 3456"
                                    maxlength="19"
                                    pattern="^(\d{4}[\s-]?){3}\d{4}$"
                                    title="Enter a valid 16-digit card number (e.g., 1234 5678 9012 3456)">
                            </div>
                            <div class="col-md-2">
                                <label class="form-label">ExpiryDate</label>
                                <input type="text" class="form-control" id="ExpiryDate" runat="server"
                                    required placeholder="MM/YY"
                                    maxlength="5"
                                    pattern="^(0[1-9]|1[0-2])\/\d{2}$"
                                    title="Enter a valid expiry date in MM/YY format">
                            </div>
                            <div class="col-md-2">
                                <label class="form-label">CVC</label>
                                <input type="text" class="form-control" id="CVC" runat="server"
                                    required placeholder="123"
                                    maxlength="3"
                                    pattern="^\d{3}$"
                                    title="Enter a valid 3 digit CVC code">
                            </div>
                        </div>
                        <p class="secure-text"><i class="bi bi-lock me-1"></i>Your payment information is secure.</p>
                    </div>
                </div>

                <!-- Shipping Cost Card -->
                <div class="info-card p-3 mb-4">
                    <h5 class="mb-3"><i class="fas fa-truck me-2 text-success"></i>Shipping Cost</h5>

                    <ul class="small text-muted mb-0">
                        <li>Orders below R500 → <strong>R75 shipping</strong></li>
                        <li>Orders between R2500 and R4999 → <strong>R50 shipping</strong></li>
                        <li>Orders R5000 or more → <strong>FREE shipping</strong></li>
                    </ul>
                </div>


            </div>

            <!-- Right Column: Order Summary -->
            <div class="col-md-6">
                <h3 class="section-title">Order Summary</h3>
                <div class="order-summary p-3 border rounded">
                    <asp:Repeater ID="rptCartItems" runat="server">
                        <ItemTemplate>
                            <div class="d-flex justify-content-between align-items-center small mb-2">
                                <div>
                                    <strong><%# Eval("ProductName") %></strong>
                                    <div class="text-muted small">Qty: <%# Eval("Quantity") %></div>
                                </div>
                                <div>R<%# Eval("ItemTotal", "{0:F2}") %></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <hr />

                    <div class="d-flex justify-content-between">
                        <div>Subtotal</div>
                        <div id="lblSubtotal" runat="server"></div>
                    </div>
                    <div class="d-flex justify-content-between">
                        <div>Tax (8%)</div>
                        <div id="lblTax" runat="server"></div>
                    </div>
                    <div class="d-flex justify-content-between">
                        <div>Shipping</div>
                        <div id="lblShipping" runat="server"></div>
                    </div>

                    <hr />

                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <h4>Total</h4>
                        <h3 id="lblTotal" runat="server"></h3>
                    </div>

                    <asp:Button ID="btnPlaceOrder" runat="server" CssClass="btn btn-primary w-100" Text="Place Order" OnClick="btnPlaceOrder_Click" />
                </div>
            </div>
        </div>
    </div>

    <script>
    // Format Card Number (auto spaces after 4 digits)
    document.addEventListener("input", function (e) {
        if (e.target.id.includes("cardNo")) {
            e.target.value = e.target.value
                .replace(/\D/g, "")
                .replace(/(\d{4})(?=\d)/g, "$1 ")
                .trim();
        }
    });

    // Format Expiry Date (auto adds slash after MM)
    document.addEventListener("input", function (e) {
        if (e.target.id.includes("ExpiryDate")) {
            e.target.value = e.target.value
                .replace(/\D/g, "")
                .replace(/(\d{2})(\d{1,2})?/, "$1/$2")
                .trim();
        }
    });
    </script>

</asp:Content>
