$(function () {
    $(document).on('change', '.change-request-filter select', function () {
        $(this).parents('form').submit();
    });
});