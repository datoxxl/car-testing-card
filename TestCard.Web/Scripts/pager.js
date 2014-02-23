$(function () {

    initPager();

    $(document).ajaxComplete(function () {
        initPager();
    });

    function initPager() {
        $('.x-pager').not('.init-done').each(function (idex, elem) {
            var $pager = $(elem);
            var $pageIndex = $pager.find('#pageIndex');
            var totalPageCount = parseInt($pager.find('#pageTotal').val());

            var $form = $pager.parent('form');

            $pager.addClass("init-done");

            $pager.find('.page-num')
                .change(function (e) {
                    e.preventDefault();
                    e.stopPropagation();

                    var page = $(this).val();

                    $(this).val(goTo(page));
                })
                .bind("keypress", function (e) {
                    if (e.keyCode == 13) {
                        e.stopPropagation();
                    }
                });

            $pager.find('.prev,.next,.first,.last')
                .click(function () {
                    var page = $(this).data("page") || '';

                    if (page != '') {
                        goTo(page);
                    }
                });

            $pager.find('.refresh')
                .click(function () {
                    var page = $(this).data("page") || 1;

                    get(page);
                });

            function goTo(page) {
                var oldPage = parseInt($pageIndex.val());

                if (isNaN(page) || page == '') {
                    return oldPage;
                }

                page = parseInt(page);

                if (page >= 1 && page <= totalPageCount) {
                    get(page);

                    return page;
                }

                return oldPage;
            }

            function get(page) {
                $pageIndex.val(page);
                $form.submit();
            }
        });
    }
});