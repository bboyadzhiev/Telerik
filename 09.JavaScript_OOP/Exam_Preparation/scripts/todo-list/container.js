define(function() {
  'use strict';
  var Container;
  Container = (function() {
   function Container() {
       this._sections = {};

   }

   Container.prototype.add = function (section) {
       this._sections.push(section);
   }

   Container.prototype.getData = function () {
       var copiedSections = this._sections.splice();
       return this._sections.map(function () {

       })
   }
   return Container;
  }());
  return Container;
});