$.fn.enhanceTable = function (settings) {

    var Sum = "sum";
    var Count = "count";

    var obj = {
        showSummaryRow: false,
        columnConfig: [],
        defaultAccumulatorType: "sum",
        minRowCount: 2
    };

    $.extend(obj, settings);

    function process($table) {
        if (obj.showSummaryRow) {
            renderSummaryRow($table);
        }
    }

    function renderSummaryRow($table) {
        var $rows = $table.find('tbody tr');

        if (obj.minRowCount > $rows.length) {
            return;
        }

        var accumulator = [];

        $rows.each(function (i, row) {
            var $cols = $(row).find('td');

            if (accumulator.length == 0) {
                var columnCount = $cols.length;
                accumulator = getSummaryAccumulator(columnCount);
            }

            $cols.each(function (j, column) {

                switch (accumulator[j].type) {
                    case Sum:
                        accumulator[j].value += +($(column).text());
                        break;
                    case Count:
                        accumulator[j].value++;
                        break;
                    default:

                }
            });
        });

        if (accumulator.length > 0) {
            var $newRow = $('<tr>').addClass('summary');
            var colArray = [];

            for (var i = 0; i < accumulator.length; i++) {
                colArray.push($('<td>').text(accumulator[i].value));
            }

            $newRow.append(colArray);
            $table.append($newRow);
        }
    }

    function getSummaryAccumulator(columnCount) {
        var accumulator = [];

        for (var i = 0; i < columnCount; i++) {
            accumulator[i] = {
                value: 0,
                type: searchColumnConfig(i) || obj.defaultAccumulatorType
            };
        }

        return accumulator;
    }

    function searchColumnConfig(columnIndex) {
        for (var i = 0; i < obj.columnConfig.length; i++) {
            if (obj.columnConfig[i].columnIndex == columnIndex) {
                return obj.columnConfig[i].type;
            }
        }

        return 0;
    }

    return this.each(function () {
        process($(this));
    });
};