/// <reference path="libs/require.js" />
/// <reference path="libs/handlebars-v1.3.0.js" />
/// <reference path="libs/jquery-2.1.1.js" />
define(["jquery", "handlebars"], function ($, handlebars) {
    var ComboBox = (function () {
        function ComboBox(content) {
            this.content = content;
        };
        ComboBox.prototype.render = function (templateHTML) {
            var template = Handlebars.compile(templateHTML);

            // Creating ComboBox HTML
            var $items = $('<div>')
                .css({
                    "display": "block",
                    "border-color": "#C1E0FF",
                    "border-weight": "1px",
                    "border-style": "solid",
                    "width": "250px"
                })
                .addClass('ComboBox');

            // Appending content
            for (var i = 0; i < this.content.length; i++) {
                $items.append(template(this.content[i]));
            }

            // Implementing selection
            $items.children().on("click", function () {
                if ($(this).hasClass('selected')) {
                    $(this).removeClass('selected');
                    $(this).siblings().show("slow");
                } else {
                    $(this).siblings().hide("slow");
                    $(this).addClass('selected');
                }
            });

            // every item
            $items.children()
                .css({
                    "margin":"2px",
                    "display": "block"
                })
                .hide();

            //internal item data
            $items.children().children().css({
                "display": "inline-block",
                "vertical-align" : "top"
            })

            $items.children().first().addClass('selected').show("slow");

            return $items;
        };

        return ComboBox;
    }());

    //controls.ComboBox = function (contentArray) {
    //    if (!(contentArray instanceof Array)) {
    //        throw { name: 'ComboBox exception', message: 'ComboBox items should be an Array' };
    //    }
    //    return new ComboBox(contentArray);
    //};
    //
    //return controls;

    return {
        ComboBox : function (contentArray) {
            if (!(contentArray instanceof Array)) {
                throw { name: 'ComboBox exception', message: 'ComboBox items should be an Array' };
            }
            return new ComboBox(contentArray);
        }
    }
});