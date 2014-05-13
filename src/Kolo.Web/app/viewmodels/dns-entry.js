define(function (require) {
    var router = require('plugins/router');
    var ctor = function () {
        var self = this;
        this.model = {};

        this.save = function () {
            router.navigateBack();
        };

        this.activate = function (dnsEntryId) {
            if (dnsEntryId != 'new')
                loadDnsEntry(dnsEntryId);
        }

        function loadDnsEntry(dnsEntryId) {
            self.model = { Name: 'test', IpAddress: '127.0.0.1', Id: 1, GroupId: 2 };
        }
    }

    return ctor;
});