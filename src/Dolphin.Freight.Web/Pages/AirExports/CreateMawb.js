$(function () {
    $("#saveBtn").click(function () {
        $("#createForm").submit();
    })
});


$('#createForm').on('abp-ajax-success', function (result, rs) {
    event.preventDefault();
    location.href = 'EditModal?ShowMsg=true&Id=' + rs.responseText.id

});
