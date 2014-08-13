/// <reference path="jquery-2.1.1.js" />
var httpRequestsModule = (function () {
    function getJSON(url, onSuccess, onError) {
       return $.ajax({
            url: url,
            type: 'GET',
            contentType: 'application/json',
            success: onSuccess,
            error: onError
        })
    };

    function postJSON(url, data, onSuccess, onError) {
       return $.ajax({
            url: url,
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json',
            success: onSuccess,
            error: onError
        })
    };

    return {
        getJSON: getJSON, // Returns a promise
        postJSON: postJSON // Returns a promise
    }
}());