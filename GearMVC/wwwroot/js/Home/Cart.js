$(document).ready(function () {
    getCart();
});
var currentPage = 1;
var maxPage = 0;
var recordsPerPage = 10;
var cart;

function getCart() {
    $.ajax({
        url: '/user/getcart',
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (result) {
            if (result.length != 0) {
                cart = result;
                maxPage = Math.ceil(cart.length / recordsPerPage);
                changePage(currentPage);
            }
            else DisplayEmptyCart();
        },
        error: function () {
            alert("Error while retreiving data");
        }
    });
}
function DisplayEmptyCart() {
    var html = `<div class="cart-empty">
                <div>
                    <p>
                        Giỏ hàng đang trống!
                    </p>
                </div>
                <div>
                    <img src="/images/cart_emty.png" />
                </div>
             </div>`;

    $("#giohang-content").html(html);
    $("#thanhtoanbtn").html("");
}
function MoneyFormat(num) {
    if (num == 0) {
        return '0';
    }
    if (!num) {
        return '';
    }
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
}
function displayList(list,paginator_html) {
    var total = 0;
    $.each(cart, (key, item) => {
        var sale = item.LinhKien.DonGias[0].GiamGia;
        var price_unit = item.LinhKien.DonGias[0].DonGiaBan;
         total += (price_unit - price_unit * sale / 100) * item.SoLuong;
    });
    var html = `<thead>
                        <tr>
                            <th class="table-cart--img"></th>
                            <th class="table-cart--name">Sản phẩm</th>
                            <th class="table-cart--quantily">Số lượng</th>
                            <th class="table-cart--price text-center">Giá tiền</th>
                            <th class="table-cart--trash"></th>
                        </tr>
                    </thead>`;
    $.each(list, (key, item) => 
    {
        var sale = item.LinhKien.DonGias[0].GiamGia;
        var price_unit = item.LinhKien.DonGias[0].DonGiaBan;
        var price = (price_unit - price_unit * sale / 100) * item.SoLuong;
        html += `<tbody>
            <tr>
                <td class="table-cart--img"><a href="/product/detail/`+item.LinhKienId+`"><img src="/images/products/`+item.LinhKien.Hinh.split(",")[0]+`" alt="img"></a></td>
                <td class="table-cart--name"><a href="/product/detail/`+item.LinhKienId+`">`+item.LinhKien.TenLK+`</a></td>
                <td class="table-cart--quantily">
                    <input type="number" name="sl" min="1" max="`+item.LinhKien.SLTonKho+`" value="`+item.SoLuong+`" size="5" class="quantily" onblur="updateCartItem(`+item.LinhKienId+`, $(this))">
                </td>
                <td class="table-cart--price text-center" >`+ MoneyFormat(price) +` VNĐ</td>
                <td class="table-cart--trash">
                    <button class="btn btn-sm btn-danger" onclick="deleteCartItem(`+item.LinhKienId+`)">
                        <i class="fa fa-trash"></i>
                    </button>
                </td>
            </tr>
        </tbody>`;
    });
    if (maxPage > 1) html += paginator_html;
    html += `<tbody>
        <tr class="table-cart--total">
            <td colspan="3" class="text-right font-weight-bold">Tổng tiền:</td>
            <td colspan="2" class="text-right font-weight-bold">`+ MoneyFormat(total) +` VNĐ</td>
        </tr>
    </tbody>`;
    $("#giohang-content").html(html);
}
function changePage(page) {
    if (maxPage == 0) {
        $("#giohang-content").html("");
        return;
    }
    currentPage = page;
    var html = `<tbody><tr><td colspan="5">
                 <nav aria-label="Page navigation example">
                            <ul class="pagination justify-content-center">`;
    if (currentPage == 1) {
        html += `<li class="page-item disabled">
                            <a class="page-link" href="#" tabindex="-1">&lt;-</a>
                        </li>`;
    }
    else {
        html += `<li class="page-item">
                                <a class="page-link" onclick=changePage(`+ (currentPage - 1) + `)>
                                    &lt;-
                                </a>
                        </li>`;
    }

    for (var i = 1; i <= maxPage; i++) {

        html += `<li class="page-item `;
        html += currentPage == i ? `active` : ``;
        html += `">
                                <a class="page-link" onclick=changePage(`+ i + `)>` + i + `</a>
                        </li>`;
    }

    if (currentPage == maxPage) {
        html += `<li class="page-item disabled">
                            <a class="page-link" href="#" tabindex="-1">-></a>
                         </li>`;
    }
    else {
        html += `<li class="page-item">
                            <a class="page-link" onclick=changePage(`+ (currentPage + 1) + `)>
                                ->
                            </a>
                         </li>`;
    }

    html += ` </ul>
                        </nav></td></tr></tbody>`;

    displayList(cart.slice((currentPage - 1) * recordsPerPage, currentPage * recordsPerPage), html);

}
function deleteCartItem(id) {
    var confirm = window.confirm("Bạn muốn xóa sản phẩm này?");
    if (!confirm) return;
    $.ajax({
        url: '/cart/deleteitem',
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: { linhkienid: id},
        success: function (result) {
            if (result) {
                getCart();
            }
            else {
                alert("Unexpected server error occurred.")
            }
        },
        error: function () {
            alert("Error while removing data");
        }
    });
}
function updateCartItem(id, element) {
    
    var soluong = parseInt(element.val());
    if (isNaN(soluong) || soluong === undefined || soluong === null) {
        element.val(1);
        soluong = 1;
    }
    var max = parseInt(element.prop("max"));
    if (soluong < 1) {
        element.val(1);
        soluong = 1;
    }
    else if (soluong > max) {
        element.val(max);
        soluong = max;
        alert("Bạn chỉ có thể mua tối đa " + max + " đơn vị của sản phẩm này!");
    }
    else element.val(soluong);

    $.ajax({
        url: '/cart/updateitem',
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: { linhkienid: id, soluong: soluong },
        success: function (result) {
            if (result) getCart();
            else alert("Unexpected server error occurred.");
        },
        error: function () {
            alert("Error while updating cart");
        }
    });
}