/// <reference path="jquery-2.1.1.js" />
(function () {

    var
        date = Date(),
        author = 'Some Body',
        $author = $('<span> by ' + author + ' </span>'),
        $date = $('<span>' + date + '</span>'),

        $targetElement = $('article p');

    function insert($element, $target, after) {
        if (after) {
            $element.insertAfter($target);
        } else {
            $element.insertBefore($target);
        }
    }

    insert($date, $targetElement, true);
    insert($author, $targetElement, false);
}());