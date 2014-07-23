/// <reference path="Person.js" />
/// <reference path="Book.js" />
var Author = (function () {

    function Author(fname, lname, age, alias) {
        Person.call(this, fname, lname, age);
        this._books = [];
        this._alias = alias;
    }

    Author.prototype = new Person();

    Author.prototype.getBooks = function () {
        var books = this._books.slice();
        return books;
    };

    Author.prototype.addBook = function (book) {
        if (!(book instanceof Book)) {
            throw "Invalid book!";
        }
        this._books.push(book);
    };

    Author.prototype.getAlias = function () {
        return this._alias;
    };

    return Author;
}());