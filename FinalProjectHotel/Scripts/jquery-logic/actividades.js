$(document).ready(function () {
    $('#example').DataTable({
        retrieve: true,
        "ajax": {
            "url": "https://jsonplaceholder.typicode.com/posts",
            "dataSrc": ""
        },

        "columns": [
            { "data": "userId" },
            { "data": "id" },
            { "data": "title" },
            { "data": "body" }
        ]
    });
});

$(document).ready(function () {
    var table = $('#example').DataTable();
    $('#example tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });
    $('#button').click(function () {
        table.row('.selected').remove().draw(false);
    });
    $('#editar').click(function () {
        table.row('.selected').data({
            "userId": $('#txtuserId').val(),
            "id": $('#txtid').val(),
            "title": $('#txttitle').val(),
            "body": $('#txtbody').val()
        }).draw();
    });
});

$(document).ready(function () {
    var table = $('#example').DataTable();
    var counter = 101;

    $('#agregar').on('click', function () {


        table.row.add({
            "userId": "Test Lab",
            "id": counter,
            "title": "Test Lab",
            "body": "Test Lab"
        }).draw();

        counter++;
    });

});