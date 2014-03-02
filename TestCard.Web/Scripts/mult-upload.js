$(function () {
    var inputCount = 4;

    $('.add-more').click(function (e) {
        e.preventDefault();

        for (var i = 0; i < inputCount; i++) {
            $(this).parent().siblings('.files').append('<input type="file" name="files" />');
        }
    });
});