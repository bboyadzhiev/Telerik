/// <reference path="jquery-1.4.4.js" />
/// <reference path="sammy-0.7.4.js" />
var controller = $.sammy(function () {
    this.element_selector = '#crowdChat';
    this.get('#/', function (context) {
        loginModule.initialize(context);
    });

    this.get('#/crowdChat', function (context) {
        chatModule.initialize(context);
    })
});

$(function () {
    controller.run('#/')
}());
