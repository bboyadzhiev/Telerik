define(function () {
    'use strict';
    var Section;
    Section = (function () {
        function Section(title) {
            this._title = title;
            this._itemsList = [];
        };

        Section.prototype = {
            add: function (item) {
                this._itemsList.push(item);
            },
            getData: function () {
                var itemsList = this._itemsList.map(function (item) {
                    return item.getData();
                });
                
                return {
                    title: this._title,
                    items: itemsList
                };
            }
             

        };

        return Section;
    }());
    return Section;
});