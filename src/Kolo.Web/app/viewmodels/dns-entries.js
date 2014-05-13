define(function (require) {
    var system = require('durandal/system');
    var ctor = function () {
        this.dnsEntries = [
            { name: 'test.com', id: 1 }
        ];
        this.dnsGroup = 'Root';
        this.activate = function (parameters) {
            system.log(parameters);
        }
    };

    return ctor;
});