/// <reference path="item.js" />
define(['tech-store-models/item'], function (Item) {
    var itemTypes = {
        accessory: 'accessory',
        smartphone: 'smart-phone',
        notebook: 'notebook',
        pc: 'pc',
        tablet: 'tablet'
    };


    var Store;
    Store = (function () {
        function Store(name) {
            if (name.length < 6
                || name.length > 30
                || !(typeof name == 'string')
                ) {
                throw {
                    message: "Item's name is out of range [6, 40]"
                }
            };
            this._name = name;
            this._items = [];
        };

        Store.prototype.addItem = function (item) {
            if (!(item instanceof Item)) {
                throw {
                    message: "Argument is not a valid Item!"
                };
            };

            this._items.push(item);
            return this;
        };

        Store.prototype.getAll = function () {
            var items = getSortedLex(this._items);
            return items;
        };

        Store.prototype.getSmartPhones = function () {
            var i, smartPhones = [];
            for (i = 0; i < this._items.length; i++) {
                if (this._items[i].type == itemTypes.smartphone) {
                    smartPhones.push(this._items[i]);
                }
            }
            return getSortedLex(smartPhones);
        };

        Store.prototype.getMobiles = function () {
            var i, mobiles = [];
            for (i = 0; i < this._items.length; i++) {
                if (this._items[i].type == itemTypes.smartphone
                    || this._items[i].type == itemTypes.tablet) {
                    mobiles.push(this._items[i]);
                }
            }
            return getSortedLex(mobiles);
        };

        Store.prototype.getComputers = function () {
            var i, computers = [];
            for (i = 0; i < this._items.length; i++) {
                if (this._items[i].type == itemTypes.pc
                    || this._items[i].type == itemTypes.notebook) {
                    computers.push(this._items[i]);
                }
            }
            return getSortedLex(computers);
        };

        Store.prototype.filterItemsByType = function (filter) {
            var i, items = [], type;
            for (i = 0; i < this._items.length; i++) {
                type = this._items[i].type;
                if (type == filter) {
                    items.push(this._items[i]);
                }
            }
            return getSortedLex(items);
        };

        Store.prototype.filterItemsByPrice = function (price) {
            var filtered;
            var p = { min: 0, max: Infinity };

            if (price) {
                p.min = price.min || p.min;
                p.max = price.max || p.max;

                filtered = this._items.filter(function (obj) {
                    return (obj.price > p.min && obj.price < p.max);
                });

                return getSortedAscending(filtered);
            }
            return getSortedAscending(this._items);
        };

        Store.prototype.filterItemsByName = function (partialName) {
            var filtered;

            filtered = this._items.filter(function (obj) {
                return (obj.name.toLowerCase().indexOf(partialName.toLowerCase()) > -1);
            });
            return getSortedAscending(filtered);
        };

        Store.prototype.countItemsByType = function () {
            var i,
                typesArray = [];

            //getting all the types
            for (var k in itemTypes) typesArray[itemTypes[k]] = 0;

            // calculating the count for every type
            for (i = 0; i < this._items.length; i++) {
                typesArray[this._items[i].type] += 1;
            }

            return typesArray;
        };


        //function getItemsByType(args) {
        //    var i, j, items;
        //    for (j = 0; j < this._items.length; j++) {
        //        for (var k in itemTypes)
        //            if (this._items[j].type == args[k]) {
        //                items.push(this._items[i]);
        //            }
        //    }
        //    return items;
        //}

        function getSortedLex(items) {
            items.sort(function (a, b) { return a.name.localeCompare(b.name); });
            return items.slice();
        }

        function getSortedAscending(items) {
            items.sort(function (a, b) { return a.price - b.price });
            return items.slice();
        }

        return Store;

    }());

    return Store;
});