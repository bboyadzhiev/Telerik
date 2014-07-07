/// <reference path="item.js" />
/// <reference path="section.js" />
define(function () {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            this._sections = [];
        }

        Container.prototype = {
            add: function (section) {
                this._sections.push(section);
            },
            getData: function () {
                var result = this._sections.map(function (section) {
                    return section.getData();
                });
                return result;
            }
        };
        return Container;

    }());
    return Container;
});