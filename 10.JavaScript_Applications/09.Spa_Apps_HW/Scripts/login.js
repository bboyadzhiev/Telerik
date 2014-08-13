/// <reference path="jquery-1.4.4.js" />
var loginModule = (function () {
    var $view, appCtx;
    

    var initialize = function (context) {
        appCtx = context;
        $view = appCtx.$element();
        $view.empty();
        $view.load('views/loginView.html');
        $view.on('click', '#loginBtn', function () {
            var nickname = $view.find('#nickName').val();
            console.log(nickname);
            if (nickname) {
                localStorage.setItem('crowdChatNick', nickname)
                appCtx.redirect('#/crowdChat');
            } else {
                alert('You must enter a nickname!');
            }
        })
    };
    return {
        initialize: initialize
    }
}());