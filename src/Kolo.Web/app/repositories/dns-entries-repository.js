define(function (require) {
    var http = require('plugins/http'),
        config = require('config');
    var ctor = function () {
        var dnsEntriesUrl = config.baseUrl + 'dnsEntries/';
        this.addDnsEntry = function (dnsEntry) {
            return http.post(dnsEntriesUrl, dnsEntry);
        };
        this.deleteDnsEntry = function (dnsEntryId) {
            return http.remove(dnsEntriesUrl + dnsEntryId);
        }
        this.getDnsEntry = function (dnsEntryId) {
            return http.get(dnsEntriesUrl + dnsEntryId);
        }
        this.getDnsEntries = function () {
            return http.get(dnsEntriesUrl);
        }
        this.updateDnsEntry = function (dnsEntry) {
            return http.put(dnsEntriesUrl + dnsEntry.Id, dnsEntry);
        };
    };

    return new ctor();
});