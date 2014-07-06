/// <reference path="libs/require.js" />
/// <reference path="libs/handlebars-v1.3.0.js" />
/// <reference path="controls.js" />
require.config({
    paths: {
        "jquery": "libs/jquery-2.1.1",
        "handlebars": "libs/handlebars-v1.3.0",
        "controls": "controls"
    }
});

require(["jquery", "controls"], function ($, controls) {
    var people = [
        { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "images/minkov.jpg" },
        { id: 2, name: "Nikolay Kostovv", age: 19, avatarUrl: "images/niki.jpg" },
        { id: 3, name: "Ivaylo Kenov", age: 20, avatarUrl: "images/ivo.jpg" },
        { id: 4, name: "Todor Stoyanov", age: 21, avatarUrl: "images/todor.jpg" }
    ];

    var comboBox = controls.ComboBox(people);
    var template = $('#person-template').html();
    var comboBoxHtml = comboBox.render(template);
    
    $('#container').html(comboBoxHtml);
});
