define(function () {
    'use strict';
    var Section;
    Section = (function () {
        function Section(title) {
            this._items = {};
            this.title = title;
        }

        Section.prototype.add = function (item) {
            this._items.push(item);
        };
        Section.prototype.getData = function () {
            var copiedArray = this._items.slice(); // fix
            return {
                titie: this.title,
                //items: this._items // VERY BAD!!!
                items: copiedArray
            }
        };

        return Section;

    }());

    return Section;
});