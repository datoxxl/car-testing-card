$(function () {
    $(document).on('change', '.x-list-filter select', function () {
        var $t = $(this);
        var $form = $t.parents('form');

        $form.attr('action', updateQueryStringParameter($form.attr('action'), $t.attr('name'), $t.val()));

        $t.before(getLoader('small'));

        $form.submit();
    });
});