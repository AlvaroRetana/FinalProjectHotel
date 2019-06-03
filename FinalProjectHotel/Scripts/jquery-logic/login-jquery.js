function SignUp() {

    $("#ShowModal").modal();
    $("#message1").hide();
    $("#message2").hide();
}

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


