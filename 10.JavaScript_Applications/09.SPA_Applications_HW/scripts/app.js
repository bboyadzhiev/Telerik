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
            'httpRequester': 'httpRequester'
        }
    });

    require(['jQuery', 'sammy', 'controller'], function ($, Sammy, appController) {
        var controller = new appController('http://crowd-chat.herokuapp.com/posts', '#crowdChat');
        controller.setEventHandlers();
        var app =Sammy('#crowdChat', function () {
            this.get('#/login', function () {
                console.log('show login');
                controller.showLoginForm();
            });

            this.get('#/chat', function () {
                console.log('show chat');
                controller.showChatForm();
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