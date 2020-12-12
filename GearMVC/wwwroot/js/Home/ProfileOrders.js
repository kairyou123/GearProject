
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
function UpdateProfile() {
    if (!InputIsValid()) return;
    var hoten = $("#HoTenInput").val();
    var sdt = $("#PhoneNumberInput").val();
    var gioitinh = $('input[name="GioiTinhInput"]:checked').val();
    var diachi = $("#DiaChiInput").val();
    var currentpass = $("#CurrentPasswordInput").val();
    var newpass = $("#NewPasswordInput").val();
    var newpassconfirm = $("#NewPasswordConfirmInput").val();
    var dto = {
        CurrentPassword: currentpass,
        NewPassword: newpass,
        NewPasswordConfirm: newpassconfirm,
        PhoneNumber: sdt,
        DiaChi: diachi,
        GioiTinh: gioitinh,
        HoTen: hoten
    };
    $.ajax({
        url: '/user/profile-orders/updateprofile',
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(dto),
        async: true,
        success: function (result) {
            if (result.code == 200) {
                alert("Cập nhật thành công");
                window.location.reload();
            }
            else {
                alert(result.message);
            }
        },
        error: function () {
            alert("Error while retreiving data");
        }
    });
}

function InputIsValid() {
    var hoten = $("#HoTenInput").val();
    var sdt = $("#PhoneNumberInput").val();
    var diachi = $("#DiaChiInput").val();
    var currentpass = $("#CurrentPasswordInput").val();
    var newpass = $("#NewPasswordInput").val();
    var newpassconfirm = $("#NewPasswordConfirmInput").val();
    var error = $("#error-message");

    if (!sdt || !hoten || !diachi || !currentpass || !newpass || !newpassconfirm) {
        error.html("Xin nhập đầy đủ thông tin.");
        return false;
    }
    var phoneregex = /^[0-9]+$/i;
    var passregex = /.{5,}/i;
    if (!phoneregex.test(sdt)) {
        error.html("SĐT không đúng định dạng");
        return false;
    }
    if (!passregex.test(currentpass) || !passregex.test(newpass) || !passregex.test(newpassconfirm)) {
        error.html("Mật khẩu ít nhất 5 ký tự");
        return false;
    }
    if (newpass != newpassconfirm) {
        error.html("Mật khẩu nhập lại không trùng khớp");
        return false;
    }
    error.html("");
    return true;
}

function Reset() {
    window.location.href = "/user/profile-orders/3";
}