define(function () {
    'use strict';
    var Item;
    Item = (function () {
        function Item(content) {
            this._content = content;
        }

        Item.prototype.getData = function () {
            return {
                content: this._content // Object
            };

        };

        return Item;
    })();
    return Item;
});