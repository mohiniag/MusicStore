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
   
    $.ajax({
        url: '/MakePayment/Index',
        type: 'POST',
        data: {'amount':amount}
    }).done(function () {
        alert("successfull");
        });

}