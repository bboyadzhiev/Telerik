/// <reference path="lib/require.js" />
/// <reference path="controllers/appController.js" />
/// <reference path="lib/jquery-2.1.1.js" />
define(function () {
    require.config({
        paths: {
            'jQuery': 'lib/jquery-2.1.1',
            'sammy': 'lib/sammy-0.7.4',
            'mustache': 'lib/mustache',
            'controller': 'controllers/appController',
            'httpRequester': 'httpRequester',
            'underscore': 'lib/underscore',
            'filter' : 'filter'
        }
    });

    require(['jQuery', 'sammy', 'controller'], function ($, Sammy, appController) {
        var controller = new appController('http://localhost:3000', '#crowdChat');
     //   var controller = new appController('http://jsapps.bgcoder.com', '#crowdChat');
        controller.setEventHandlers();
        var app = Sammy('#crowdChat', function () {

            this.get('#/login', function () {
                controller.showLoginForm();
            });
            this.get('#/register', function () {
                controller.showRegisterForm();
            })

            this.get('#/chat', function () {
                controller.showChatForm();
            })

            this.get('#/guest', function () {
                controller.showGuestForm();
            })
        });

        app.run('#/login');
        //console.log('run');
        //$(function () {
        //    console.log('run');
        //    app.run('#/login');
        //});

    }); // require
});