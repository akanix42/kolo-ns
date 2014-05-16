define(function (require) {
    var system = require('durandal/system'),
        dnsEntriesRepository = require('repositories/dns-entries-repository')
    ;
    var ctor = function () {
        var self = this;
        self.dnsEntries = [ ];
        self.dnsGroup = 'Root';
        self.activate = function (parameters) {
            system.log(parameters);
            return dnsEntriesRepository.getDnsEntries()
                .then(function(entries) {
                    //debugger;
                    //self.dnsEntries.length = 0;
                    self.dnsEntries = entries;
                    //for (var i = 0; i < entries; i++)
                    //    self.dnsEntries.push(entries[i]);
                });
        }
    };

    return ctor;
});