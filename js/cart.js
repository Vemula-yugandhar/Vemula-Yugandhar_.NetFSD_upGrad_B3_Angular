// 🔥 Add to Cart with Quantity
function addToCart(product, qty = 1){
  let cart = JSON.parse(localStorage.getItem("cart")) || [];

  let existing = cart.find(p => p.id === product.id);

  if(existing){
    existing.qty += qty;
  } else {
    product.qty = qty;
    cart.push(product);
  }

  localStorage.setItem("cart", JSON.stringify(cart));

  updateCartCount();

  // 🔥 IMPORTANT FIX
  if(typeof loadProducts === "function"){
    loadProducts(); // refresh product UI
  }

  alert(product.name + " added to cart!");
}

// 🔥 Update Navbar Cart Count
function updateCartCount(){
  let cart = JSON.parse(localStorage.getItem("cart")) || [];
  let total = 0;

  cart.forEach(i => total += i.qty);

  $("#cartCount").text(total);
}

// 🔥 Load Cart Page
function loadCart(){
  let cart = JSON.parse(localStorage.getItem("cart")) || [];
  let html = "";
  let total = 0;

  cart.forEach((item, i) => {

    let itemTotal = item.price * item.qty;
    total += itemTotal;

    html += `
    <tr>
      <td>${item.name}</td>
      <td>₹${item.price}</td>

      <td>
        <button class="btn btn-sm btn-secondary" onclick="changeQtyCart(${i}, -1)">-</button>
        <span class="mx-2 fw-bold">${item.qty}</span>
        <button class="btn btn-sm btn-secondary" onclick="changeQtyCart(${i}, 1)">+</button>
      </td>

      <td class="text-success fw-bold">₹${itemTotal}</td>

      <td>
        <button class="btn btn-danger btn-sm" onclick="removeItem(${i})">
          Remove
        </button>
      </td>
    </tr>`;
  });

  $("#cartItems").html(html);
  $("#total").text(total);
}

// 🔥 Change Qty in Cart Page
function changeQtyCart(i, change){
  let cart = JSON.parse(localStorage.getItem("cart"));

  cart[i].qty += change;

  if(cart[i].qty <= 0){
    cart.splice(i,1);
  }

  localStorage.setItem("cart", JSON.stringify(cart));

  loadCart();
  updateCartCount();
}

// 🔥 Remove Item
function removeItem(i){
  let cart = JSON.parse(localStorage.getItem("cart"));

  cart.splice(i,1);

  localStorage.setItem("cart", JSON.stringify(cart));

  loadCart();
  updateCartCount();
}