// ===== Product Listing =====
function loadProducts() {
  fetch('products.json')
    .then(res => res.json())
    .then(products => {
      const container = document.getElementById('productsContainer');
      if (!container) return;
      
      // Clear container first
      container.innerHTML = '';
      
      products.forEach(product => {
        const col = document.createElement('div');
        col.className = 'col';
        col.innerHTML = `
          <div class="card h-100 shadow-sm position-relative">
            <img src="${product.image}" class="card-img-top img-fluid" alt="${product.name}" style="object-fit: cover; height: 200px;">
            ${product.energySaved ? `<span class="energy-badge">Saves ${product.energySaved} Energy</span>` : ''}
            <div class="card-body d-flex flex-column">
              <h5 class="card-title">${product.name}</h5>
              <div class="d-flex align-items-center mb-2">
                ${generateStarRating(product.rating)}
                <p class="text-muted ms-2 mb-0">${product.reviews}</p>
              </div>
              <p class="card-text flex-grow-1">${product.description}</p>
              <div class="row align-items-center">
                <div class="col"><p class="mb-0 fw-bold fs-5">R${parseFloat(product.price).toFixed(2)}</p></div>
                <div class="col d-flex justify-content-end">
                  <a href="demo.html?id=${product.id}" class="btn btn-success btn-sm">View details</a>
                </div>
              </div>
            </div>
          </div>
        `;
        container.appendChild(col);
      });
    })
    .catch(err => {
      console.error('Error loading products:', err);
      // Fallback to embedded products if fetch fails
      loadFallbackProducts();
    });
}

// Helper function to generate star rating
function generateStarRating(rating) {
  let stars = '';
  const fullStars = (rating.match(/★/g) || []).length;
  const emptyStars = 5 - fullStars;
  
  for (let i = 0; i < fullStars; i++) {
    stars += '<i class="bi bi-star-fill"></i>';
  }
  for (let i = 0; i < emptyStars; i++) {
    stars += '<i class="bi bi-star"></i>';
  }
  
  return stars;
}

// Fallback products if JSON file can't be loaded
function loadFallbackProducts() {
  const products = [
    {
      id: 1,
      name: "Smart Thermostat Pro",
      description: "WiFi-enabled programmable thermostat with learning capabilities",
      rating: "★★★★★",
      reviews: "128 reviews",
      price: 199.99,
      image: "https://via.placeholder.com/300x300?text=Thermostat",
      energySaved: "15%"
    },
    {
      id: 2,
      name: "Eco Lightbulb",
      description: "LED lightbulb that saves energy and lasts 25,000 hours",
      rating: "★★★★☆",
      reviews: "64 reviews",
      price: 5.99,
      image: "https://via.placeholder.com/300x300?text=Lightbulb",
      energySaved: "80%"
    },
    {
      id: 3,
      name: "Solar Panel Kit",
      description: "Complete solar panel kit for home energy generation",
      rating: "★★★★★",
      reviews: "42 reviews",
      price: 899.99,
      image: "https://via.placeholder.com/300x300?text=Solar+Panel",
      energySaved: "40%"
    },
    {
      id: 4,
      name: "Smart Plug",
      description: "Control your appliances remotely and save energy",
      rating: "★★★★☆",
      reviews: "89 reviews",
      price: 24.99,
      image: "https://via.placeholder.com/300x300?text=Smart+Plug",
      energySaved: "10%"
    },
    {
      id: 5,
      name: "Energy Monitor",
      description: "Track your home's energy consumption in real-time",
      rating: "★★★★★",
      reviews: "56 reviews",
      price: 149.99,
      image: "https://via.placeholder.com/300x300?text=Energy+Monitor",
      energySaved: "20%"
    },
    {
      id: 6,
      name: "Insulation Kit",
      description: "Improve your home's insulation and reduce heating costs",
      rating: "★★★★☆",
      reviews: "37 reviews",
      price: 79.99,
      image: "https://via.placeholder.com/300x300?text=Insulation",
      energySaved: "25%"
    },
    {
    id: 7,
        name: "EcoFlow RIVER 2 Pro Portable Power Station",
        description: "Portable power station for emergency backup",
        rating: "★★★★★",
        reviews: "52 reviews",
        price: 6746.00,
        image: "https://us.ecoflow.com/cdn/shop/products/ecoflow-us-ecoflow-river-2-pro-portable-power-station-30042784006217_2000x.png?v=1742453520",
        energySaved: "30%",
    }
  ];
  
  const container = document.getElementById('productsContainer');
  if (!container) return;
  
  container.innerHTML = '';
  
  products.forEach(product => {
    const col = document.createElement('div');
    col.className = 'col';
    col.innerHTML = `
      <div class="card h-100 shadow-sm position-relative">
        <img src="${product.image}" class="card-img-top img-fluid" alt="${product.name}" style="object-fit: cover; height: 200px;">
        ${product.energySaved ? `<span class="energy-badge">Saves ${product.energySaved} Energy</span>` : ''}
        <div class="card-body d-flex flex-column">
          <h5 class="card-title">${product.name}</h5>
          <div class="d-flex align-items-center mb-2">
            ${generateStarRating(product.rating)}
            <p class="text-muted ms-2 mb-0">${product.reviews}</p>
          </div>
          <p class="card-text flex-grow-1">${product.description}</p>
          <div class="row align-items-center">
            <div class="col"><p class="mb-0 fw-bold fs-5">R${parseFloat(product.price).toFixed(2)}</p></div>
            <div class="col d-flex justify-content-end">
              <a href="demo.html?id=${product.id}" class="btn btn-success btn-sm">View details</a>
            </div>
          </div>
        </div>
      </div>
    `;
    container.appendChild(col);
  });
}

// ===== Shared Cart Functions =====
function getCart() {
  return JSON.parse(localStorage.getItem('cart')) || [];
}

function saveCart(cart) {
  localStorage.setItem('cart', JSON.stringify(cart));
  updateCartCount();
}

function updateCartCount() {
  const cart = getCart();
  let totalQuantity = cart.reduce((sum, item) => sum + item.quantity, 0);
  const countEl = document.getElementById('cart-count');
  if (countEl) countEl.textContent = totalQuantity;
}

// ===== Add to Cart (Single or Multiple Quantity) =====
function addToCartWithQuantity(productId, quantity) {
  fetch('products.json')
    .then(res => res.json())
    .then(products => {
      const product = products.find(p => p.id === productId);
      if (!product) return;

      let cart = getCart();
      let item = cart.find(i => i.id === productId);
      if (item) {
        item.quantity += quantity;
      } else {
        cart.push({...product, quantity: quantity});
      }

      saveCart(cart);
      alert(`${product.name} (x${quantity}) added to cart!`);
    })
    .catch(err => {
      console.error('Error adding to cart:', err);
      alert('Error adding product to cart');
    });
}


// ===== Display Cart Page =====
function displayCart() {
  const cart = getCart();
  const container = document.getElementById('cart-items');
  const totalEl = document.getElementById('cart-total');
  if (!container || !totalEl) return;

  container.innerHTML = '';
  let total = 0;

  if (cart.length === 0) {
    container.innerHTML = '<div class="col-12"><p class="text-center">Your cart is empty.</p></div>';
  } else {
    cart.forEach((item, index) => {
      const itemPrice = parseFloat(item.price);
      const itemTotal = itemPrice * item.quantity;
      total += itemTotal;

      const col = document.createElement('div');
      col.className = 'col-md-4 mb-3';
      col.innerHTML = `
        <div class="card h-100 shadow-sm">
          <img src="${item.image}" class="card-img-top" style="height:200px; object-fit:cover;" alt="${item.name}">
          <div class="card-body d-flex flex-column justify-content-between">
            <h5 class="card-title">${item.name}</h5>
            <div class="d-flex align-items-center mb-2">
              <button class="btn btn-sm btn-outline-secondary me-2" onclick="changeQuantity(${index}, -1)">-</button>
              <span>Quantity: ${item.quantity}</span>
              <button class="btn btn-sm btn-outline-secondary ms-2" onclick="changeQuantity(${index}, 1)">+</button>
            </div>
            <p class="fw-bold">R${itemTotal.toFixed(2)}</p>
            <button class="btn btn-sm btn-danger mt-auto" onclick="removeFromCart(${index})">Remove</button>
          </div>
        </div>
      `;
      container.appendChild(col);
    });
  }

  totalEl.textContent = `R${total.toFixed(2)}`;
}

// ===== Remove item =====
function removeFromCart(index) {
  let cart = getCart();
  cart.splice(index, 1);
  saveCart(cart);
  displayCart();
}

// ===== Clear cart =====
function clearCart() {
  localStorage.removeItem('cart');
  displayCart();
  updateCartCount();
}

// ===== Change Quantity =====
function changeQuantity(index, delta) {
  let cart = getCart();
  cart[index].quantity += delta;
  if (cart[index].quantity <= 0) cart.splice(index, 1);
  saveCart(cart);
  displayCart();
}

// Initialize cart count and products
document.addEventListener('DOMContentLoaded', function() {
  updateCartCount();
  loadProducts();
});