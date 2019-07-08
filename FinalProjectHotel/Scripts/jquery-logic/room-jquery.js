var path = "s";

$(document).ready(function () {

    $.ajax({
        type: "GET",
        url: "/Admin/GetConsecutives",
        data: "{}",
        success: function (data) {

            var s = '<option value="-1">Please Select a Consecutive</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Consecutivo + '">' + data[i].Consecutivo +'</option>';
            }
            $("#ComboBoxConsecutive").html(s);  
         
        }
    });

    $.ajax({
        type: "GET",
        url: "/Admin/GetPrices",
        data: "{}",
        success: function (data) {

            var s = '<option value="-1">Please Select a Price</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Consecutive + '">' + data[i].Price + '</option>';
            }
            $("#ComboBoxPrice").html(s);

        }
    });
});  


function Save() {

    var RoomValues = new Object();

    RoomValues.id_consecutivo = $("#ComboBoxConsecutive").val();
    RoomValues.nombre = $("#InputName").val();
    RoomValues.numero = $("#InputNumber").val();
    RoomValues.descripcion = $("#ComboBoxDescription").val();
    RoomValues.imagen = path;
    RoomValues.disponibilidad = $("#ComboBoxAvailability").val();
    RoomValues.id_precio = $("#ComboBoxPrice").val();

    $.ajax({
        type: "post",
        data: JSON.stringify(RoomValues),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "/Admin/SaveRoom",
        success: function (data) {
            alert("OK");
        }
    });


}

function Update() {

    var RoomValues = new Object();

    RoomValues.id_consecutivo = $("#InputID").val();
    RoomValues.nombre = $("#InputName").val();
    RoomValues.numero = $("#InputNumber").val();
    RoomValues.descripcion = $("#ComboBoxDescription").val();
    RoomValues.imagen = $("#InputImage").val();
    RoomValues.disponibilidad = $("#ComboBoxAvailability").val();
    RoomValues.id_precio = $("#ComboBoxPrice").val();

    console.log(RoomValues);

    $.ajax({
        type: "post",
        data: JSON.stringify(RoomValues),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "/Admin/UpdateRoom",
        success: function (data) {
            alert("OK");
        }
    });


}

    $('#file').on("change", function () {
        var formdata = new FormData($('form').get(0));
        CallService(formdata);
    });

    function CallService(file) {
        $.ajax({
            url: '/Admin/UploadImage',
            type: 'POST',
            data: file,
            cache: false,
            processData: false,
            contentType: false,
            success: function (data) {
                path = data;
                $("#InputImage").val(path);
                $("#InputImage").html(path);
            },
            error: function () {
            }
        });
    }










