define(function (require) {
    var http = require('plugins/http'),
        config = require('config');
    var ctor = function () {
        var forwardingServersUrl = config.baseUrl + 'forwardingServers/';
        this.addForwardingServer = function (forwardingServer) {
            return http.post(forwardingServersUrl, forwardingServer);
        };
        this.deleteForwardingServer = function (forwardingServerId) {
            return http.remove(forwardingServersUrl + forwardingServerId);
        }
        this.getForwardingServer = function (forwardingServerId) {
            return http.get(forwardingServersUrl + forwardingServerId);
        }
        this.getforwardingServers = function () {
            return http.get(forwardingServersUrl);
        }
        this.updateForwardingServer = function (forwardingServer) {
            return http.put(forwardingServersUrl + forwardingServer.Id, forwardingServer);
        };
    };

    return new ctor();
});