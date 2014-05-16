define(function (require) {
    var jqValidate = require('jquery.validate.main'),
        additional = require('jquery.validate.additional'),
        $ = require('jquery');

    $.extend($.validator,
    {
        dataRules: function (element) {
            var method,
                value,
                rules = {},
                $element = $(element);
            for (method in $.validator.methods) {
                var rule = "rule" + method[0].toUpperCase() + method.substring(1).toLowerCase();
                var elementData = $element.data();
                if (!(rule in elementData)) continue;
                value = elementData[rule] || true;
                rules[method] = value;
            }
            return rules;
        }
    });
    var originalInit = $.validator.prototype.init;
    $.validator.prototype.init = function () {
        var self = this;
        originalInit.call(self);

        $(self.currentForm)
            .find(":text, [type='password'], [type='file'], select, textarea, " +
                "[type='number'], [type='search'] ,[type='tel'], [type='url'], " +
                "[type='email'], [type='datetime'], [type='date'], [type='month'], " +
                "[type='week'], [type='time'], [type='datetime-local'], " +
                "[type='range'], [type='color'] " +
                "[type='radio'], [type='checkbox']")
            .each(function() {
                self.submitted[this.name] = '';
            });
    };
});
