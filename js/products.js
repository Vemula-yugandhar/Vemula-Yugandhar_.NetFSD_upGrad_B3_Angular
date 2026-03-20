$(document).ready(function(){
  loadProducts();
  updateCartCount();
});

function loadProducts(){
  $.getJSON("data/products.json", function(products){

    let cart = JSON.parse(localStorage.getItem("cart")) || [];

    let html = "";

    products.forEach(p => {

      let item = cart.find(x => x.id === p.id);
      let qty = item ? item.qty : 0;

      html += `
      <div class="col-md-3 mb-3">
        <div class="card p-2">
          <img src="${p.image}" height="150">
          <h5>${p.name}</h5>
          <p>₹${p.price}</p>

          <button onclick='addToCart(${JSON.stringify(p)})' class="btn btn-success">
            Add (${qty})
          </button>

          <a href="product-details.html?id=${p.id}" class="btn btn-primary mt-1">View</a>
        </div>
      </div>`;
    });

    $("#productList").html(html);
  });
}