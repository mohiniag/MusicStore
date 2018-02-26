

function addToCart(dataset) {
  
    
    $.ajax({
       
        url: '/Cart/Index',
        type:'POST',
        data: dataset
    }).done(function () {
        alert('Added to cart');
    });
    
   
}