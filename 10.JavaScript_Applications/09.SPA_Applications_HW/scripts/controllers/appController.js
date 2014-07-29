/// <reference path="../lib/require.js" />
/// <reference path="../lib/jquery-2.1.1.js" />
/// <reference path="../httpRequester.js" />
/// <reference path="../lib/mustache.js" />
define(['httpRequester', 'mustache'], function (httpRequester, Mustache) {
    var Controller = (function (url, container) {
        var Controller = function (url, container) {
            this._url = url;
            this._container = container;
            this.refreshTime = 5000;
        }

        Controller.prototype.setUserName = function (userName) {
            sessionStorage.setItem('CrowdChatUsername', userName)
        };

        Controller.prototype.getUserName = function () {
            return sessionStorage.getItem('CrowdChatUsername');
        };

        Controller.prototype.isLoggedIn = function () {
            if (this.getUserName() != null) {
                return true;
            }
            return false;
        }

        Controller.prototype.logout = function () {
            sessionStorage.removeItem('CrowdChatUsername');
        };

        Controller.prototype.showLoginForm = function () {
            console.log('show login form');
            $(this._container).load('html/loginForm.html');
            console.log('login form loaded');
        };

        Controller.prototype.showChatForm = function () {
            var _this = this;
            $.when(
                $.get('html/chatForm.html', function (data) {
                    $(_this._container).html(data);
                })
                )
            .then(
                function success() {
                    _this.updateChatBox();
                }
            )
        }

        Controller.prototype.updateChatBox = function () {
            var _this = this;
            httpRequester.getJSON(_this._url, function success(data) {
                console.log(data);
                //$.ajax({
                //    type: 'GET',
                //    url: 'templates/chat.html',
                //    dataType: 'html'
                //})
                httpRequester.getHTML('templates/chat.html')
                .then(function success(template) {
                    var result = Mustache.render(template, { data: data });
                    //console.log(data);
                    $('#chatbox').html(result);
                })


            })


            //$.when(
            //    $.ajax({
            //        type: 'GET',
            //        url: 'templates/chat.html',
            //        dataType: 'html'
            //    })
            //    )
            //.then(function success(template) {
            //    console.log('rendering');
            //    console.log(template);
            //    var result = Mustache.render(template, {posts:[{ by: 'joro', text: 'test' }, { by: 'dino', text: 'text' }]});
            //    console.log(result);
            //    $(_this._container).append(result);
            //})
        }

        Controller.prototype.sendMessage = function (message) {
            var _this = this;
            $.when(
                httpRequester.postJSON(_this._url, message,
                function success() {
                    console.log('message has been sent: ' + message);
                },
                function error() {
                    console.log('Error occured while sending message!');
                }
                )
                )
            .then(function success() {
                _this.updateChatBox();
            })
        }

        Controller.prototype.updateChatMessages = function () {

        }

        Controller.prototype.setEventHandlers = function () {
            var $container = $(this._container);
            var _this = this;
            console.log('events');
            $container.on('click', '#loginBtn', function () {
                var $loginInput = $('#nickText');
                var userName = $loginInput.val();
                if (userName != null && userName.length > 2) {
                    console.log('urename set to ' + userName);
                    _this.setUserName(userName);

                    window.location = '#/chat';
                } else {
                    alert('username cannot be empty');
                }
            });

            $container.on('click', '#submitmsg', function () {
                var data, message = $('#usermsg').val();
                var currentdate = new Date();
                var datetime = "Last Sync: " + currentdate.getDate() + "/"
                                + (currentdate.getMonth() + 1) + "/"
                                + currentdate.getFullYear() + " @ "
                                + currentdate.getHours() + ":"
                                + currentdate.getMinutes() + ":"
                                + currentdate.getSeconds();
                if (_this.getUserName() !== null && message) {
                    data = {
                        user: _this.getUserName(),
                        //text: '[' + currentdate + ']: ' + message
                        text: message
                    };
                    _this.sendMessage(data);
                }
            })

            $container.on('click', '#exit-btn', function () {
                _this.logout();
                window.location = '#/login';
            });

        }

        return Controller;
    }());
    return Controller;
})