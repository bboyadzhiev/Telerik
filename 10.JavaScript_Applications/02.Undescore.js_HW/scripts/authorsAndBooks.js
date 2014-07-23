/// <reference path="libs/underscore.js" />
/// <reference path="Book.js" />
/// <reference path="Author.js" />
(function () {
    if (typeof require !== 'undefined') {
        //load underscore if on Node.js
        _ = require('libs/underscore.js');
    }

    var authors = [
       new Author('Angel', 'Petrov', 60, 'Acho'),
       new Author('Georgi', 'Popov', 43, 'Gogo'),
       new Author('Dimitar', 'Stefanov', 33, 'Stefanoff'),
       new Author('Iordanka', 'Dimitrova', 20, 'Jade'),
       new Author('Maria', 'Trifonova', 46, 'Mimoza'),
       new Author('Petar', 'Donchev', 30, 'Pezz'),
    ],
   books = [
   new Book('Instantiation', 123435343),
   new Book('The new Book', 543435334),
   new Book('The BookMaker', 454433545),
   new Book('Prototype this', 556445310),
   new Book('dotNOT', 470386656),
   ],
   mostPopularAuthor;

    function getAuthorByAlias(authorsArray, alias) {
        return _.find(authorsArray, function (author) {
            return author.getAlias() == alias;
        });
    };

    function getBookByTitle(booksArray, title) {
        return _.find(booksArray, function (book) {
            return book.getTitle() == title;
        });
    };

    function setBookAndAuthor(author, book) {
        if (!(author instanceof Author)) {
            throw "Invalid author!";
        }
        if (!(book instanceof Book)) {
            throw "Invalid book!";
        }
        author.addBook(book);
        book.addAuthor(author);
    };

    function authorToBook(authorAlias, bookTitle, authorsArray, booksArray) {
        try {
            setBookAndAuthor(getAuthorByAlias(authorsArray, authorAlias), getBookByTitle(booksArray, bookTitle));
        } catch (e) {
            console.log(e);
        }
    }

    function getMostPopularAuthor(authorsArray) {
        var author = _(authorsArray).chain()
           .sortBy(function (author) {
               return author.getBooks().length;
           })
           .last()
           .value();
        return author;
    }

    authorToBook('Acho','Instantiation', authors, books);
    authorToBook('Gogo', 'Instantiation', authors, books);
    authorToBook('Stefanoff', 'The new Book', authors, books);
    authorToBook('Jade', 'The new Book', authors, books);
    authorToBook('Mimoza', 'The new Book', authors, books);
    authorToBook('Pezz', 'dotNOT', authors, books);
    authorToBook('Stefanoff', 'dotNOT', authors, books);
    authorToBook('Acho', 'dotNOT', authors, books);
    authorToBook('Gogo', 'The BookMaker', authors, books);
    authorToBook('Acho', 'Prototype this', authors, books);

    console.log('--- All the books ---');
    console.dir(books);
    console.log();
    console.log('--- All the authors ---');
    console.dir(authors);
    console.log();

    console.log('--- Task 6 - By a given collection of books, find the most       ---');
    console.log('--- popular author (the author with the highest number of books) ---');
    mostPopularAuthor = getMostPopularAuthor(authors);
    console.log('The author with most books is: ' + mostPopularAuthor.getFullName() + ' - \'' + mostPopularAuthor.getAlias() + '\'');
    console.dir(mostPopularAuthor.getBooks());

    console.log();
    console.log('Task 7 is in students demo!');
}());