$("#message1").hide();
$("#message2").hide();

function SaveForm() {
    var username = $("#User").val();
    var password = $("#Password").val();
    var email = $("#Email").val();
    var name = $("#Name").val();
    var lastname = $("#Lastname").val();
    var secondlastname = $("#Secondlastname").val();
    var phone = $("#Phone").val();
    if (username == "" || password == "" || email == "" || name == "" || lastname == "" || secondlastname == "" || phone == "") {
        $("#message1").hide();
        $("#message2").show();
        return false;
    }
    $('#modal').modal('toggle');
    var data = $("#Registration").serialize();
    $.ajax({
        type: "post",
        data: data,
        url: "/User/SaveData",
        success: function (result) {
            $("#message1").show();
            $("#message2").hide();
            $("#Registration")[0].reset();
        }
    });
}

$("#msg").hide();
var Login = function () {
    var data = $("#loginForm").serialize();
    $.ajax({
        type: "post",
        url: "/User/CheckValidUser",
        data: data,
        success: function (result) {
            if (result == "Fail") {
                $("#loginForm")[0].reset();
                $("#msg").show();
            }
            else {
                window.location.href = "/User/AfterLogin";
                $("#msg").hide();
            }
        }
    })
}

$("#message1Change").hide();
$("#message2Change").hide();
var ChangePassword = function () {
    var oldpassword = $("#OldPassword").val();
    var newpassword = $("#NewPassword").val();
    var confirmnewpassword = $("#ConfirmPassword").val();

    $.ajax({
        type: "POST",
        url: "/User/ChangePasswordUser", // the method we are calling
        data: { Oldpassword: oldpassword, Newpassword: newpassword, Confirmnewpassword: confirmnewpassword },
        dataType: "json",
        success: function (result) {
            if (result == "fail") {
                $("#ChangePasswordForm")[0].reset();
                $("#message1Change").show();
                $("#message2Change").hide();
            }
            else {
                $("#ChangePasswordForm")[0].reset();
                $("#message1Change").hide();
                $("#message2Change").show();

            }
        }
    })
}