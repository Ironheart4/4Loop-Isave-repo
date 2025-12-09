<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="iSave_FrontEnd.Cart" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
        .cart-item {
            border: 1px solid #eee;
            border-radius: 10px;
            padding: 15px;
            background: #fff;
            transition: 0.2s ease-in-out;
            height: 100%;
        }
        .cart-item:hover {
            box-shadow: 0 4px 12px rgba(0,0,0,0.1);
            transform: translateY(-2px);
        }
        .cart-item img {
            width: 100%;
            height: 160px;
            object-fit: cover;
            border-radius: 8px;
            margin-bottom: 10px;
        }
        .cart-title {
            font-size: 1rem;
            font-weight: 600;
            margin-bottom: 5px;
        }
        .cart-price {
            font-weight: 600;
            color: #28a745;
            margin-bottom: 8px;
        }
        .cart-qty input {
            width: 70px;
            text-align: center;
            font-size: 0.9rem;
        }
        .cart-summary {
            background: #f8f9fa;
            border-radius: 10px;
            padding: 15px;
        }
        .cart-summary h4 {
            font-weight: 600;
            font-size: 1.1rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container py4-">
        <h2 class="mb-4 mt-2">🛒 Your Shopping Cart</h2>
        <div class="row g-4">
        
        <!-- Cart Items Section -->
        <div class="col-md-8">
            <div class="row g-4" id="cartItemsContainer" runat="server">
                <!-- Items dynamically injected here -->
            </div>
        </div>
          
           

            <!-- Cart Summary -->
            <div class="col-md-4">
                <div class="cart-summary shadow-sm">
                    <h4>Order Summary</h4>
                    <hr />
                    <p class="d-flex justify-content-between">
                        <span>Total:</span> 
                        <span runat="server" id="totalDiv" class="fw-bold">R0.00</span>
                    </p>
                    <asp:Button runat="server" ID="clearCart" class="btn btn-outline-danger w-100" Text="Clear Cart" OnClick="clearCart_Click1"/>
                    <a href="Products.aspx" class="btn btn-outline-secondary w-100 mt-2">Continue Shopping</a>
                    <a href="Checkout.aspx" class="btn btn-outline-success w-100 mt-2">Process to Checkout</a>
                </div>
            </div>
        </div>
    </div>

    <script>
        function updateItemTotal(input, price) {
            const qty = parseInt(input.value);
            const itemTotal = qty * price;
            const itemTotalDiv = input.closest('.card').querySelector('.item-total');
            itemTotalDiv.innerText = "R" + itemTotal.toFixed(2);

            // Recalculate cart total
            let total = 0;
            document.querySelectorAll('.quantityInput').forEach(function (q) {
                const p = parseFloat(q.dataset.price);
                total += parseInt(q.value) * p;
            });
            document.getElementById('<%= totalDiv.ClientID %>').innerText = "R" + total.toFixed(2);
        }
    </script>
</asp:Content>
