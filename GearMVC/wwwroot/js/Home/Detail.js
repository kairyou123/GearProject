function updateCartItem() {
    var element = $("#product_num");
    var soluong = parseInt(element.val());
    if (isNaN(soluong) || soluong === undefined || soluong === null) {
        element.val(1);
        soluong = 1;
    }
    var max = parseInt(element.prop("max"));
    if (soluong < 1) {
        element.val(1);
    }
    else if (soluong > max) {
        element.val(max);
        alert("Bạn chỉ có thể mua tối đa " + max + " đơn vị của sản phẩm này!");
    }
    else element.val(soluong);
}