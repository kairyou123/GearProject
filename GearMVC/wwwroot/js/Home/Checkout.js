

$(document).ready(function () {
    changePage(1);
});
function MoneyFormat(num) {
    if (num == 0) {
        return '0';
    }
    if (!num) {
        return '';
    }
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
}
function displayList(list, paginator_html) {
    var total = 0;
    $.each(cart, (key, item) => {
        var sale = item.LinhKien.DonGias[0].GiamGia;
        var price_unit = item.LinhKien.DonGias[0].DonGiaBan;
        total += (price_unit - price_unit * sale / 100) * item.SoLuong;
    });
    var html = `<thead>
                        <tr>
                            <th class="table-checkout--img"></th>
                            <th class="table-checkout--name">Sản phẩm</th>
                            <th class="table-checkout--quantily">Số lượng</th>
                            <th class="table-checkout--price text-center">Giá tiền</th>
                        </tr>
                    </thead>`;
    $.each(list, (key, item) => {
        var sale = item.LinhKien.DonGias[0].GiamGia;
        var price_unit = item.LinhKien.DonGias[0].DonGiaBan;
        var price = (price_unit - price_unit * sale / 100) * item.SoLuong;
        html += `<tbody>
            <tr>
                <td class="table-checkout--img"><a href="/product/detail/`+ item.LinhKienId + `"><img src="/images/products/` + item.LinhKien.Hinh.split(",")[0] + `" alt="img"></a></td>
                <td class="table-checkout--name"><a href="/product/detail/`+ item.LinhKienId + `">` + item.LinhKien.TenLK + `</a></td>
                <td class="table-checkout--quantily"> ` + item.SoLuong + ` </td>
                <td class="table-checkout--price text-center" >`+ MoneyFormat(price) + ` VNĐ</td>
            </tr>
        </tbody>`;
    });
    if (maxPage > 1) html += paginator_html;
    html += `<tbody>
        <tr class="table-checkout--total">
            <td colspan="2" class="text-right font-weight-bold">Tổng tiền:</td>
            <td colspan="2" class="text-right font-weight-bold">`+ MoneyFormat(total) + ` VNĐ</td>
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
    var html = `<tbody><tr><td colspan="4">
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

function CreateOrder() {
    var pttt = $('input[name="paymentMethod"]:checked').val();
    $.ajax({
        url: '/user/createorder',
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { pttt: pttt},
        async: true,
        success: function (result) {
            if (result) {
                alert("Thanh toán thành công");
                window.location.href = "/";
            }
            else
                alert("Unexpected server error occurred.")
        },
        error: function () {
            alert("Error while retreiving data");
        }
    });
}