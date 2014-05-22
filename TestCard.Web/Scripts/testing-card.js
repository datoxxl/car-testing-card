﻿function setupTestingCard(param) {

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

    function formatLicenseNumber(text, obj) {
        if (text.length >= 3 && text.indexOf('-') == -1) {
            obj.resultText = text.insertText('-', 3);

            return true;
        }

        return false;
    }

    return this.each(function () {

        $(this).keypress(function (e) {
            e.preventDefault();

            var c = String.fromCharCode(e.which).toUpperCase();

            var selStart = this.selectionStart;
            var selEnd = this.selectionEnd;
            var srcText = this.value;
            var caretPos = selStart;
            var resultText = srcText;

            if (C_AZ.indexOf(c) != -1 && selStart < 3
                || C_09.indexOf(c) != -1 && selStart > 3 && selStart <= 6) {

                resultText = srcText.insertText(c, selStart, selEnd);
                if (resultText.length <= 7) {
                    caretPos++;
                }
                else {
                    resultText = srcText;
                }
            }

            var obj = {};

            if (formatLicenseNumber(resultText, obj)) {
                resultText = obj.resultText;
                caretPos++;
            }

            this.value = resultText;
            $(this).selectRange(caretPos);
        })
        .change(function () {
            var obj = {};

            if (formatLicenseNumber(this.value, obj)) {
                this.value = obj.resultText;
            }
        });
    });
};