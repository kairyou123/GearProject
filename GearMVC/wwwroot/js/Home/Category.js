
var currentPage=1;
var maxPage=0;
var recordsPerPage = 8;
var products;
$(document).ready(function () {
    Init();
    searchProducts(1);
});

function Init() {
    
}
function searchProducts(page) {
    var orderby = $("#OrderBy").val()
    switch (orderby) {
        case "popular":
            products.sort((a, b) => {
                return  b.DaBan - a.DaBan ;
            }); 
            break;
        case "price-ascend":
            products.sort((a, b) => {
                var sale1 = a.DonGias[0].GiamGia;
                var price1 = a.DonGias[0].DonGiaBan;
                var sale2 = b.DonGias[0].GiamGia;
                var price2 = b.DonGias[0].DonGiaBan;
                return ((price1 - price1 * sale1 / 100) - (price2 - price2 * sale2 / 100));
            });
            break;
        case "price-descend":
            products.sort((a, b) => {
                var sale1 = a.DonGias[0].GiamGia;
                var price1 = a.DonGias[0].DonGiaBan;
                var sale2 = b.DonGias[0].GiamGia;
                var price2 = b.DonGias[0].DonGiaBan;
                return (price2 - price2 * sale2 / 100) - (price1 - price1 * sale1 / 100);
            });
            break;
    }
    changePage(page);
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
function displayList(list) {
    var html = ``;
    $.each(list, (key, item) => {
        var sale = item.DonGias[0].GiamGia;
        var price = item.DonGias[0].DonGiaBan;
        html += `<div class="product-category-content-products col-md-3">
            <div class="border">
                <div class="product-category-content-products-img">
                    <a href="/product/detail/`+ item.Id + `">
                        <img src="/images/products/`+ item.Hinh.split(",")[0] + `" alt="img">
                    </a>
                    <div class="products-hover">
                        <p class="products-hover-see-more">
                            <a href="/product/detail/`+ item.Id + `">Nhấn để xem chi tiết</a>
                        </p>
                        <div class="products-hover-btn">`;
        if (item.SLTonKho > 0)
            html += `<p><a onclick="addToCart(` + item.Id + `,1)">Thêm vào giỏ hàng</a></p>`;
        else
            html += `<p><span class="out-of-stock">Hết hàng</p></span>`;
            html += `</div>
        </div>`;

                    if (item.DaBan >= 100)
                    {
                        html += `<div class="products-tags">
                            <p>HOT</p>
                        </div>`;
                    }
                    else if (moment(item.NgayCapNhat).isAfter(moment().add(-10,"days")))
                    {
                        html += `<div class="products-tags">
                            <p>NEW</p>
                        </div>`;
                    }

        html += `</div>
                <div class="product-category-content-products-name">
                    <h2>`+ item.TenLK + `</h2>
                </div>`;
        if (item.DaBan >= 100)
        {
        html += `<div class="products-sold">
                    <span>Đã bán ` + item.DaBan + `</span>
                    </div>`;
        }
                html += `<div class="product-category-content-products-price">
                    <p>`+ MoneyFormat(price) +` VNĐ</p>
                </div>
                <div class="product-category-content-products-price-sale">
                    <p>`+ MoneyFormat(price - price * sale / 100) +` VNĐ</p>
                </div>
            </div>
        </div>`;
    });

    $("#category-content").html(html);    
}
function changePage(page) {
    if (maxPage == 0) {
        $("#paginator").html("");
        $("#category-content").html("");
        return;
    }
    currentPage = page;
    var html = `
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
                        </nav>`;
    $("#paginator").html(html);

    displayList(products.slice((currentPage - 1) * recordsPerPage, currentPage * recordsPerPage));

}
