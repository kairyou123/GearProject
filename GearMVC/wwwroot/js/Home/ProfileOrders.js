
function CancelOrder(id) {
    if (!window.confirm("Bạn muốn hủy hóa đơn này")) return;
    $.ajax({
        url: '/user/cancelorder',
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { id: id },
        async: true,
        success: function (result) {
            if (result) {
                alert("Hủy thành công");
                window.location.reload();
            }
            else
                alert("Unexpected server error occurred.")
        },
        error: function () {
            alert("Error while retreiving data");
        }
    });
}