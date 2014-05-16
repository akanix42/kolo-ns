requirejs.config({
    paths: {
        'text': '../lib/require/text',
        'durandal': '../lib/durandal/js',
        'plugins': '../lib/durandal/js/plugins',
        'transitions': '../lib/durandal/js/transitions',
        'knockout': '../lib/knockout/knockout-3.1.0',
        'knockout-validation': '../lib/knockout-validation/knockout.validation',
        'bootstrap': '../lib/bootstrap/js/bootstrap.min',
        'jquery': '../lib/jquery/jquery-2.1.1.min',
        'when': '../lib/when/when',
        'jquery.validate.main': '../lib/jquery.validate/jquery.validate.min',
        'jquery.validate.additional': '../lib/jquery.validate/additional-methods.min',
        'jquery.validate': 'jquery.validate.shim',

    },
    shim: {
        'bootstrap': {
            deps: ['jquery'],
            exports: 'jQuery'
        },
        'jquery.validate.main': ['jquery'],
        'jquery.validate.additional': ['jquery', 'jquery.validate.main']
    }

});

define(function (require) {
    var system = require('durandal/system'),
        app = require('durandal/app'),
        viewLocator = require('durandal/viewLocator');
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = 'Kolo';

    app.configurePlugins({
        router: true,
        dialog: true,
        widget: true,
        observable: true
    });

    app.start().then(function () {
        viewLocator.useConvention();


        //Show the app by setting the root view model for our application with a transition.
        app.setRoot('viewmodels/shell', 'entrance');
    });
});