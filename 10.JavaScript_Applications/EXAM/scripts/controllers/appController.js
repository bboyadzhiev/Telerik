/// <reference path="../lib/require.js" />
/// <reference path="../lib/jquery-2.1.1.js" />
/// <reference path="../httpRequester.js" />
/// <reference path="../lib/mustache.js" />
define(['httpRequester', 'mustache', 'underscore', 'filter'], function (httpRequester, Mustache, _, uscoreFilter) {
    var Controller = (function (url, container) {
        var Controller = function (url, container) {
            this._url = url;
            this._container = container;
            this.refreshTime = 5000;
            this._pass = null;
            this._sessionKey = null;
            this._data = null;
        }



        Controller.prototype.setUserName = function (userName) {
            sessionStorage.setItem('CrowdChatUsername', userName)
        };


        Controller.prototype.setPassword = function (pass) {
            this._pass = pass;
        };

        Controller.prototype.getPassword = function () {
            return this._pass;
        }

        Controller.prototype.getUserName = function () {
            return sessionStorage.getItem('CrowdChatUsername');
        };

        Controller.prototype.isLoggedIn = function () {
            if (this.getUserName() != null) {
                return true;
            }
            return false;
        }

        Controller.prototype.getShaUserData = function () {
            var shaUserData = {
                username: this.getUserName(),
                authCode: CryptoJS.SHA1(this.getUserName() + this.getPassword()).toString()
            };
            return shaUserData;
        };

        Controller.prototype.showLoginForm = function () {
            $(this._container).load('html/loginForm.html');
        };

        Controller.prototype.showRegisterForm = function () {
            $(this._container).load('html/registerForm.html');
        };

        Controller.prototype.showGuestForm = function () {
            // $(this._container).load('html/guestForm.html');
            var _this = this;
            httpRequester.getHTML('html/guestForm.html')
             .then(function (data) {
                 $(_this._container).html(data);
             })
            .then(
                function success() {
                    _this.updateChatBox();
                })
        };

        Controller.prototype.showChatForm = function () {
            var _this = this;

            httpRequester.getHTML('html/chatForm.html')
             .then(function (data) {
                 $(_this._container).html(data);
             })
            .then(
                function success() {
                    _this.updateChatBox();
                })
        }

        Controller.prototype.updateChatBox = function () {
            var _this = this;

            httpRequester.getJSON(_this._url + '/post', function success(data) {
                console.log(data);
                httpRequester.getHTML('templates/chat.html')
                .then(function success(template) {
                    var result = Mustache.render(template, { data: data });
                    //console.log(data);
                    _this._data = data;
                    $('#chatbox').html(result);
                })
                .then(function success() {
                
                        httpRequester.getHTML('html/filterForm.html')
                   .then(function success(filterHTML) {
                       //console.log(filterHTML);
                       $(filterHTML).insertAfter('#chatbox');
                   })          

                })
            })
        }

        Controller.prototype.refreshChatBox = function () {
            var _this = this;

            httpRequester.getJSON(_this._url + '/post', function success(data) {
                console.log(data);
                httpRequester.getHTML('templates/chat.html')
                .then(function success(template) {
                    var result = Mustache.render(template, { data: data });
                    //console.log(data);
                    _this._data = data;
                    $('#chatbox').html(result);
                })
               
            })
        }

        Controller.prototype.filterChatBox = function (name, pattern) {
            var _this = this;
            var filtered;
            if (!(name) && !(pattern)) {
                filtered = _this._data.slice();
            } else {
                filtered = uscoreFilter.getByBoth(_this._data, name, pattern)
            }
             
            console.log(name);
            console.log(pattern);
            console.log(filtered);
            httpRequester.getHTML('templates/chat.html')
            .then(function success(template) {
                var result = Mustache.render(template, { data: filtered });
                //console.log(data);
                $('#chatbox').html(result);
            })
           //.then(function success() {
           //    httpRequester.getHTML('html/filterForm.html')
           //    .then(function success(filterHTML) {
           //        console.log(filterHTML);
           //        $(filterHTML).insertAfter('#chatbox');
           //    })
           //
           //})

        }

        Controller.prototype.logout = function () {
            var _this = this;
            var header = {
                'X-SessionKey': _this._sessionKey
            }
            httpRequester.putJSON(_this._url + '/user', true, header)
            .done(function (response) {
                if (response) {
                    console.log(response);
                    console.log('user logged out');
                    _this._sessionKey = null;
                    sessionStorage.removeItem('CrowdChatUsername');
                }
            })
            .fail(function (err) {
                alert('Logout failed!');
                console.log('Logout error:');
                console.log(err);
            });
        };


        Controller.prototype.sendMessage = function (message) {
            var _this = this;
            console.log(_this._sessionKey);

            var header = {
                'X-SessionKey': _this._sessionKey
            }

            httpRequester.postJSONwithHeaders(_this._url + '/post', message, header)
            .done(
                function (response) {
                    console.log(response);
                    if (response) {
                        _this.refreshChatBox();
                        console.log('Message posted!');
                    }
                }
            )
            .fail(
            function error(data) {
                alert('Posting failed!');
                console.log(data);
            })
        }

        Controller.prototype.updateChatMessages = function () {

        }

        Controller.prototype.registerUser = function () {
            var _this = this;

            $.when(
                   httpRequester.postJSON(_this._url + '/user', _this.getShaUserData())
                )
                .done(function (response) {
                    console.log(response);
                    if (response) {
                        console.log('registered');
                        window.location = '#/login';
                    }

                })
            .fail(function error(data) {
                console.log('Registration error fail:');
                console.log(data);
                alert('Registration failed!');
            }
            );
        }

        Controller.prototype.authenticateUser = function () {
            var _this = this;
            console.log('auth attempt');
            $.when(
                   httpRequester.postJSON(_this._url + '/auth', _this.getShaUserData())
                )
                .done(function (response) {
                    console.log(response);

                    if (response && response.username == _this.getUserName()) {
                        console.log('authenticated');
                        _this._sessionKey = response.sessionKey;
                        console.log(response);
                        window.location = '#/chat';
                    }

                })
            .fail(function error(data) {
                console.log(data);
                alert('Authentication failed!');
                console.log('Authentication error fail ' + data);
            }
            );

        }

        Controller.prototype.setEventHandlers = function () {
            var $container = $(this._container);
            var _this = this;
            console.log('events');

            //login
            $container.on('click', '#loginBtn', function () {
                var $loginInput = $('#nickText');
                var userName = $loginInput.val();
                var pass = $('#passwdText').val();
                if (userName != null && userName.length > 2 && pass != null) {
                    console.log('urename set to ' + userName);
                    console.log('pass is:' + pass);
                    _this.setUserName(userName);
                    _this.setPassword(pass);
                    _this.authenticateUser();

                } else {
                    alert('Username and Password fields cannot be empty');
                }
            });

            //guest
            $container.on('click', '#guestBtn', function () {
                window.location = '#/guest'
            });

            $container.on('click', '#homeBtn', function () {
                window.location = '#/login'
            });

            //register new user
            $container.on('click', '#newRegBtn', function () {
                window.location = '#/register'
            });

            //register
            $container.on('click', '#registerBtn', function () {
                var $loginInput = $('#nickText');
                var userName = $loginInput.val();
                var pass = $('#passwdText').val();
                if (userName != null && userName.length > 2 && pass != null) {
                    console.log('urename set to ' + userName);
                    console.log('pass is:' + pass);
                    _this.setUserName(userName);
                    _this.setPassword(pass);
                    _this.registerUser();

                } else {
                    alert('Username and Password fields cannot be empty');
                }
            });

            //post message
            $container.on('click', '#submitmsg', function () {
                var data, title = null, message = null;
                if (_this._sessionKey == null) {
                    alert('Your session has expired!');
                    return;
                }
                message = $('#usermsg').val();
                title = $('#msgTitle').val();
                if (title && message) {
                    data = {
                        title: title,
                        body: message
                    };
                    _this.sendMessage(data);
                }
                else {
                    alert('Message title and message text should not be empty!');
                }
            });

            //logout
            $container.on('click', '#exit-btn', function () {
                if (_this._sessionKey && _this.getUserName()) {
                    _this.logout();
                } else {
                    window.location = '#/login';
                }

            });

            //filters
            $container.on('click', '#filterBtn', function () {
                var filterByName = $('#nickFilterText').val();
                var filterByPattern = $('#patternFilterText').val();
                if (filterByName || filterByPattern) {
                    _this.filterChatBox(filterByName, filterByPattern);
                };
            })

        }

        return Controller;
    }());
    return Controller;
})