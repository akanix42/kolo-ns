define(function (require) {
    var router = require('plugins/router'),
        ko = require('knockout'),
        //knockoutValidation = require('knockout-validation'),
        jqValidate = require('jquery.validate'),
        dnsEntriesRepository = require('repositories/dns-entries-repository'),
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
                dnsEntriesRepository.addDnsEntry(self.model);
            else
                dnsEntriesRepository.updateDnsEntry(self.model);


        };

        self.remove = function () {
            dnsEntriesRepository.deleteDnsEntry(self.model.Id)
                .then(function() {
                    router.navigate('#dns-entries?groupId=' + self.model.GroupId);
                });
        }

        setUpDurandalEvents();

        function setUpDurandalEvents() {
            self.activate = function (dnsEntryId) {
                if (dnsEntryId != 'new')
                    loadDnsEntry(dnsEntryId);
            }

            self.compositionComplete = function () {
                applyValidation();
            }

        }
       
        function loadDnsEntry(dnsEntryId) {
            dnsEntriesRepository.getDnsEntry(dnsEntryId)
            .then(function(dnsEntry) {
                $.extend(self.model, getEmptyModel(), dnsEntry);

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