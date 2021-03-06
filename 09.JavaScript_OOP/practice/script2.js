﻿/// <reference path="script1.js" />
var modle2 = (function () {
    var Shape = (function () {
        function Shape(x, y, width, height) {
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
        }

        Shape.prototype = {
            calcArea: function () {
                return this._width * this._height;
            },
            calcPerimeter: function () {
                return 2 * this._width + 2 * this._height;
            }
        };

        return Shape;
    }());
    

    console.log( 'script2');
    var s = new Shape(5, 5, 10, 11);
    console.log(s.calcArea());
    s._width = 9;
    console.log(s.calcArea());

}());

var iife = function () { console.log("invoked!"); }();