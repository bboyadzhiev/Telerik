/// <reference path="lib/require.js" />
/// <reference path="lib/jquery-2.1.1.js" />
/// <reference path="lib/underscore.js" />
define(['underscore'], function (_) {
    function getByUser(data, userName) {
        //console.log(data);
        var byUserPosts = _.filter(data, function (post) {
            //console.log(user.username);
            return post.user.username == userName
        });
        return byUserPosts;
    }
    function getByPattern(data, pattern) {
        var byPattern = _.filter(data, function (post) {
            return post.body.indexOf(pattern) > -1;
        });
        return byPattern;
    };

    function getByBoth(data, userName, pattern) {
        var result = data.slice();



        if (userName) {
            result = _.filter(result, function (post) {
                //console.log(user.username);
                return post.user.username == userName
            });
        }
        if (pattern) {
            result = _.filter(result, function (post) {
                return post.body.indexOf(pattern) > -1;
            });
        }
        return result;
    }

    return {
        getByUser: getByUser,
        getByPattern: getByPattern,
        getByBoth: getByBoth
    }
})