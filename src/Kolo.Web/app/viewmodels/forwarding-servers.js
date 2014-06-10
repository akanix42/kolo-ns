define(function (require) {
    var system = require('durandal/system'),
        forwardingServersRepository = require('repositories/forwarding-servers-repository')
    ;
    var ctor = function () {
        var self = this;
        self.forwardingServers = [ ];
        self.dnsGroup = 'Root';
        self.activate = function (parameters) {
            system.log(parameters);
            return forwardingServersRepository.getforwardingServers()
                .then(function(entries) {
                    self.forwardingServers = entries;
                });
        }
    };

    return ctor;
});