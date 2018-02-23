

function addToCart(dataset) {
  
    
    $.ajax({
       
        url: 'Cart/Index',
        type:'POST',
        data: dataset,
        success: function (response) {
            alert(response);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    }).done(function () {
        alert('Added to cart');
    });
    
   
}