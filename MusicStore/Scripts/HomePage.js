

function addToCart(dataset) {
    alert(JSON.stringify(dataset));
    
    $.ajax({
       
        url: 'Cart/Index',
        
        data: dataset,
    }).done(function () {
        alert('Added to cart');
    });
    
   
}