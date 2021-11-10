$(function () {
    $('#file-input').click(function (e) {
        $('#download').css('display','inline-block');
    });

    $('#download').click(function (e) {
        e.preventDefault();  //stop the browser from following
        //window.location.href = 'uploads/file.doc';
        download($('#barcode').attr('src'), "strcode.png", "image/png");
    });
});
