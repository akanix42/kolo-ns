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
        this.model = { Name: '', IpV4: '', Id: null, GroupId: null, Type: 'A', };
        //applyValidation();
        this.save = function () {
            validate();
            return;
            dnsEntriesRepository.addDnsEntry(self.model);
        };

        this.activate = function (dnsEntryId) {
            if (dnsEntryId != 'new')
                loadDnsEntry(dnsEntryId);
        }

        this.compositionComplete = function() {
            applyValidation();
        }

        function loadDnsEntry(dnsEntryId) {
            self.model = { Name: 'test', IpV4: '127.0.0.1', Id: 1, GroupId: 2 };
            //applyValidation();

        }

        function applyValidation() {
            var name = observable(self.model, 'Name');//.extend({ required: true });
            $('form[data-validatable]').validate({
                //onkeyup: true
            });
        }
        function validate() {
            $('form[data-validatable="true"]').validate();
            //var model = {};
            //$.each(self.model, function(key, value) {
            //    model[key] = observable(self.model, key);
            //});
            //var validator = ko.validatedObservable(model);
            //validator.errors.showAllMessages();
            //console.log('validate');
            //console.log(validator.isValid());
        }
    }
    
    return ctor;
});