﻿/// <reference path="script2.js" />
var module1 = (function () {
    var Rect = (function () {

        var BORDERS = {
            LEFT: 0,
            RIGHT: 1000,
            TOP: 0,
            BOTTOM: 1000
        };

        function validatePosition() {
            if (this._x < BORDERS.LEFT || BORDERS.RIGHT < this._x ||
                this._y < BORDERS.TOP || BORDERS.BOTTOM < this._y) {
                return false;
            }
            return true;
        }

        function Rect(x, y, width, height) {
            this._x = x;
            this._y = y;
            if (!validatePosition.call(this)) {
                throw new Error('Invalid Rect position');
            }

            this._width = width;
            this._height = height;
        }

        Rect.prototype = {
            calcArea: function () {
                return this._width * this._height;
            },
            calcPerimeter: function () {
                return 2 * this._width + 2 * this._height;
            }
        };

        return Rect;
    }());

    var r = new Rect(0, 0, 10, 10);
    console.log(r.calcArea());
    r._width = 5;
    console.log(r.calcArea());
    
}());