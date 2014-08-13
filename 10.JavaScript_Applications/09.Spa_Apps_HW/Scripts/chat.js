/// <reference path="mustache.js" />
/// <reference path="jquery-2.1.1.js" />
var chatModule = (function () {
    var CHAT_SERVER_URL = 'http://crowd-chat.herokuapp.com/posts',
        $view;

    var initialize = function (ctx) {
        $view = ctx.$element();
        $view.empty();
        $view.load('views/chatView.html');
        setInterval(refreshChat(), 5000);
        $view.on('click', '#sendBtn', sendMessage());
    };

    function refreshChat() {
        $.when(
            $.getJSON(CHAT_SERVER_URL),
           $.ajax({
               type: 'GET',
               url: 'template/postTemplate.html',
               dataType: 'html'
           })
           )
        .then(
            function success(postsCollection, postTemplate) {
                var result = Mustache.render(postTemplate[0], { postsCollection: postsCollection[0] })
                $view.find('#chatMessages').empty();
                $view.find('#chatMessages').append(result);
            },
            function error(err) {
                alert('Error occured: ' + err);
            });
    };

    function sendMessage() {
        var message = $view.find('#messageText').val();
        var nickName = localStorage.getItem('crowdChatNick');

        $.post(CHAT_SERVER_URL, {
            text: message,
            user: nickName
        }, function success(message) {
            refreshChat();
        }, "json");
    };
    return {
        initialize: initialize
    }
}());