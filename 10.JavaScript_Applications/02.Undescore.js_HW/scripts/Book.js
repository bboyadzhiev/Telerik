/// <reference path="Author.js" />
var Book = (function () {
    function Book(title, isbn) {
        this._title = title;
        this._isbn = isbn;
        this._authors = [];
    }

    Book.prototype = {
        getTitle: function () {
            return this._title;
        },
        getISBN: function () {
            return this._isbn;
        },
        addAuthor: function (author) {
            if (!(author instanceof Author)) {
                throw "Invalid author!";
            }
            this._authors.push(author);
        }
    };

    return Book;
}());