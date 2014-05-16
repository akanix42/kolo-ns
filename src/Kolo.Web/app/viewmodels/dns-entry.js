define(function (require) {
    var router = require('plugins/router'),
        ko = require('knockout'),
        //knockoutValidation = require('knockout-validation'),
        jqValidate = require('jquery.validate'),
        dnsEntriesRepository = require('repositories/dns-entries-repository'),
        observable = require('plugins/observable'),
        $ = require('jquery');

    var ctor = function () {
        var self = this;
        var validator;
        this.model = { Name: '', IpV4: '', Id: null, GroupId: null, Type: 'A', };
        //applyValidation();
        this.save = function () {
            if (!validator.form()) return;

            if (!self.model.Id)
                dnsEntriesRepository.addDnsEntry(self.model);

        };

        this.activate = function (dnsEntryId) {
            if (dnsEntryId != 'new')
                loadDnsEntry(dnsEntryId);
        }

        this.compositionComplete = function () {
            applyValidation();
        }

        function loadDnsEntry(dnsEntryId) {
            self.model = { Name: 'test', IpV4: '127.0.0.1', Id: 1, GroupId: 2 };
            //applyValidation();

        }

        function applyValidation() {
            validator = $('[data-active-view="true"] form[data-validatable="true"]').validate();
        }

    }

    return ctor;
});