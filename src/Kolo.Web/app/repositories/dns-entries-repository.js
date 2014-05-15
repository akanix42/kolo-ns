define(function (require) {
    var http = require('plugins/http'),
        config = require('config');
    var ctor = function () {
        this.addDnsEntry = function(dnsEntry) {
            return http.post(config.baseUrl + 'dnsEntries', dnsEntry);
        };

    };

    return new ctor();
});