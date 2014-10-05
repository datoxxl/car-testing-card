function setupTestingCard(param) {

    window.GeoKBD.map({ fields: 'OwnerName' });
    $('#CarNumber').formatCarNumber();

    var cache = {};

    $("#CarBrand").autocomplete({
        minLength: 0,
        source: function (request, response) {
            var term = request.term;
            if (term in cache) {
                response(cache[term]);
                return;
            }

            $.getJSON(param.brands, request, function (data, status, xhr) {
                cache[term] = data;
                response(data);
            });
        }
    }).focus(function () {
        $(this).autocomplete("search");
    });;

    $("#CarModel").autocomplete({
        minLength: 0,
        source: function (request, response) {
            var term = request.term;
            request.brandName = $('#CarBrand').val();

            $.getJSON(param.models, request, function (data, status, xhr) {
                response(data);
            });
        }
    }).focus(function () {
        $(this).autocomplete("search");
    });;
}

$.fn.formatCarNumber = function () {
    var C_AZ = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    var C_09 = '0123456789';
    var numberRules = [
        {
            dashPositions: [3],
            charPositions: [0, 1, 2],
            numPositions: [4, 5, 6]
        },
        {
            dashPositions: [2, 6],
            charPositions: [0, 1, 7, 8],
            numPositions: [3, 4, 5]
        }];

    function isNumeric(c) {
        return C_09.indexOf(c) != -1;
    }

    function isAlpha(c) {
        return C_AZ.indexOf(c) != -1;
    }

    function isDash(c) {
        return c === '-';
    }

    function formatCarNumber(obj) {

        insertDash(obj);

        return isValidFormat(obj.text, obj.carNumber)
    }

    function isValidFormat(text, numberObj) {

        for (var i = 0; i < text.length; i++) {
            var c = text[i];

            if (!(isNumeric(c) && numberObj.numPositions.indexOf(i) != -1
                || isAlpha(c) && numberObj.charPositions.indexOf(i) != -1
                || isDash(c) && numberObj.dashPositions.indexOf(i) != -1)) {
                return false;
            }
        }

        return true;
    }

    function insertDash(obj) {

        for (var i = 0; i < obj.carNumber.dashPositions.length; i++) {
            var pos = obj.carNumber.dashPositions[i];

            if (obj.text.length > pos && obj.text[pos] !== '-') {
                obj.text = obj.text.insertText('-', pos);
                obj.caretPos++;
            }
        }
    }

    function process(elem, c) {
        var obj = {
            text: elem.value,
            caretPos: elem.selectionStart
        };

        var insertChar = (c || '') != '';

        if (insertChar) {
            obj.text = obj.text.insertText(String.fromCharCode(c).toUpperCase(), elem.selectionStart, elem.selectionEnd);
            obj.caretPos++;
        }

        var resultObj = null;
        var isValid = false;

        for (var i = 0; i < numberRules.length && !isValid; i++) {
            resultObj = $.extend({ carNumber: numberRules[i] }, obj);
            isValid = formatCarNumber(resultObj);
        }

        if (isValid) {
            elem.value = resultObj.text;
            if (insertChar) {
                $(elem).selectRange(resultObj.caretPos);
            }
        }
    }

    return this.each(function () {

        $(this).keypress(function (e) {
            e.preventDefault();

            process(this, e.which);
        })
        .change(function () {
            process(this)
        });
    });
};