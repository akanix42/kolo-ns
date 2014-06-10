define(['plugins/router', 'durandal/app'], function (router, app) {
    router.on('router:navigation:complete', function (instance, instruction) {
        ga('create', 'UA-50928509-1', 'kolo.com');
        ga('send', 'pageview');
    });
    return {
        router: router,
        search: function() {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: 'dns-entries/:id', title: 'DNS Entry', moduleId: 'viewmodels/dns-entry', nav: false },
                { route: ['', 'dns-entries', 'dns-entries?*'], title: 'DNS Entries', moduleId: 'viewmodels/dns-entries', nav: true },
                { route: 'forwarding-servers/:id', title: 'Forwarding Server', moduleId: 'viewmodels/forwarding-server', nav: false },
                { route: [ 'forwarding-servers', 'forwarding-servers?*'], title: 'Forwarding Servers', moduleId: 'viewmodels/forwarding-servers', nav: true },
                { route: 'flickr', moduleId: 'viewmodels/flickr', nav: true }
            ]).buildNavigationModel();
            
            return router.activate();
        }
    };
});