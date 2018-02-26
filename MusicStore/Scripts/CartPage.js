function removeFromCart(id) {
   
    $.ajax({
        url: '/Cart/RemoveItem',
        type: 'POST',
        data: {'id':id}
    }).done(function () {
        location.reload();
        alert("item removed");
        });

}
function payment(amount) {
   
    location.href = '/MakePayment/Index/'+amount;
  
}