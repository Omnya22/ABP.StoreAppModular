$(function () {
    $('#file-input').click(function (e) {
        $('#download').css('display','inline-block');
    });

    $('#download').click(function (e) {
        e.preventDefault();
        window.location.href = "C:\\img.png";
    });
});
