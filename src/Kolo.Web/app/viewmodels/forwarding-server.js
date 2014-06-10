define(function (require) {
    var router = require('plugins/router'),
        ko = require('knockout'),
        //knockoutValidation = require('knockout-validation'),
        jqValidate = require('jquery.validate'),
        forwardingServersRepository = require('repositories/forwarding-servers-repository'),
        observable = require('plugins/observable'),
        $ = require('jquery');

    function getEmptyModel() {
        return { Name: '', IpV4: '', Id: null, GroupId: null, Type: 'A', };
    }
    var ctor = function () {
        var self = this;
        
        var validator;
        self.model = getEmptyModel();
        //applyValidation();
        self.save = function () {
            if (!validator.form()) return;

            if (!self.model.Id)
                forwardingServersRepository.addForwardingServer(self.model);
            else
                forwardingServersRepository.updateForwardingServer(self.model);


        };

        self.remove = function () {
            forwardingServersRepository.deleteForwardingServer(self.model.Id)
                .then(function() {
                    router.navigate('#forwarding-servers?groupId=' + self.model.GroupId);
                });
        }

        setUpDurandalEvents();

        function setUpDurandalEvents() {
            self.activate = function (forwardingServerId) {
                if (forwardingServerId != 'new')
                    loadForwardingServer(forwardingServerId);
            }

            self.compositionComplete = function () {
                applyValidation();
            }

        }
       
        function loadForwardingServer(forwardingServerId) {
            forwardingServersRepository.getForwardingServer(forwardingServerId)
            .then(function(forwardingServer) {
                $.extend(self.model, getEmptyModel(), forwardingServer);

            });
            //$.extend(self.model, getEmptyModel(), { Name: 'test', IpV4: '127.0.0.1', Id: null, GroupId: 2 });
            //self.model = { Name: 'test', IpV4: '127.0.0.1', Id: 1, GroupId: 2 };
            //applyValidation();

        }

        function applyValidation() {
            validator = $('[data-active-view="true"] form[data-validatable="true"]').validate();
        }

    }

    return ctor;
});