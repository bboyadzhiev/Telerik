/// <reference path="libs/underscore.js" />
/// <reference path="web-storage-objects.js" />
var highScores = function () {
    var HighScores, scoresInstance,
    highScoresBoard = document.createElement('div'),
    highScoresPattern = document.createElement('div'),
    titlePattern = document.createElement('h2'),
    scorePattern = document.createElement('li'),
    scoresListPattern = document.createElement('ol'),
    btnPattern = document.createElement('input');
    var SCORES_COUNT = 10;

    function buildHighScoresBoard() {
        var highScoresTitleElement = prepareTitle('Untitled');
        var highScoresListElement = prepareAllHighScores();
        var okButton = btnPattern.cloneNode(true);
        okButton.setAttribute("value", "OK");
        okButton.setAttribute("type", "button");
        okButton.addEventListener("click", function () {
            this.parentNode.parentNode.classList.add("hiddenDiv");
        });
        var resetButton = btnPattern.cloneNode(true);
        resetButton.setAttribute("value", "RESET");
        resetButton.setAttribute("type", "button");
        resetButton.addEventListener("click", function () {
            highScores.resetHighScores();
            this.parentNode.parentNode.classList.add("hiddenDiv");
        });
        highScoresBoard.appendChild(highScoresTitleElement);
        highScoresBoard.appendChild(highScoresListElement);
        highScoresBoard.appendChild(okButton);
        highScoresBoard.appendChild(resetButton);
    }

    function updateAllHighScores(highScoresList) {
        var highScoresUL = scoresListPattern.cloneNode(true);
        for (var i = 0; i < highScoresList.length; i++) {
            var row = prepareHighScore(highScoresList[i].playerName, highScoresList[i].playerScore)
            highScoresUL.appendChild(row);
        };
        return highScoresUL;
    }

    function prepareAllHighScores() {
        var highScoresUL = scoresListPattern.cloneNode(true);
        for (var i = 0; i < SCORES_COUNT; i++) {
            var row = prepareHighScore(' - ', ' - ')
            highScoresUL.appendChild(row);
        };
        return highScoresUL;
    }

    function prepareHighScore(playerName, score) {
        var highScore = scorePattern.cloneNode(true);
        highScore.innerHTML = "<em>" + playerName + " " + score + "</em>";
        return highScore;
    }

    function prepareTitle(title) {
        var scoresTitle = titlePattern.cloneNode(true);
        scoresTitle.innerHTML = title;
        return scoresTitle;
    }

    HighScores = function (scoresContainer, scoresStorage) {
        function HighScores(scoresContainer, scoresStorage) {
            this._highScoresContainer = document.getElementById(scoresContainer);
            buildHighScoresBoard();
            this._scoresStorage = scoresStorage;
            this._scoresContainer = scoresContainer;
            this._highScoresList = [];
            this._title = 'Untitled Game';
            this.loadHighScores();
        }

        HighScores.prototype = (function () {

            function addHighScore(playerName, playerScore) {
                var isHighScore = false;
                this._highScoresList = _.sortBy(this._highScoresList, function (score) {
                    return score.playerScore * -1;
                });
                if (this._highScoresList.length < SCORES_COUNT) {
                    isHighScore = true;
                } else {
                    if (_.min(this._highScoresList, function (hs) {
                       return hs.playerScore;
                    }).playerScore <= playerScore) {
                        this._highScoresList.pop();
                        isHighScore = true;
                    };
                }

                if (isHighScore) {
                    console.log('new High Score :' + playerName + ' '+ playerScore);
                    this._highScoresList.push({ playerName: playerName, playerScore: playerScore });
                    this.saveHighScores();
                    this.updateHighScoresBoard();
                }
            };

            function saveHighScores() {
                if (this._highScoresList.length > 0) {
                    var highScores = { title: this._title, scores: this._highScoresList };
                    localStorage.setObject(this._scoresStorage, highScores);
                }
            }

            function loadHighScores() {
                if (!localStorage[this._scoresStorage]) {
                    console.log('not found');
                } else {
                    console.log('loading...');
                    var highScores = localStorage.getObject(this._scoresStorage);
                    this._highScoresList = highScores.scores.slice();
                    this._title = highScores.title;
                }
            }

            function updateHighScoresBoard() {
                var hsTitle, hsContent, sortedScores;
                sortedScores = _.sortBy(this._highScoresList, function (score) {
                    return score.playerScore * -1;
                });

                hsTitle = this._title;
                highScoresBoard.children[0].innerHTML = hsTitle;
                for (var i = 0; i < sortedScores.length; i++) {
                    var hsContent = prepareHighScore(sortedScores[i].playerName, sortedScores[i].playerScore);
                    highScoresBoard.children[1].children[i].innerHTML = hsContent.innerHTML;
                }
            }

            function resetHighScores() {
                console.log('resetting High Scores');
                console.log(this._highScoresList);
                this._highScoresList = [];
                localStorage.removeItem(this._scoresStorage);
                console.log(this._highScoresList);
            }

            function setTitle(title) {
                this._title = title;
            }

            function draw() {
                var scoresFragment = document.createDocumentFragment();

                scoresFragment.appendChild(highScoresBoard);
                this._highScoresContainer.classList.remove("hiddenDiv");
                this._highScoresContainer.appendChild(scoresFragment);
            }

            function show(c) {
                var f = document.getElementById(c);
                f.classList.remove("hiddenDiv");
            };

            return {
                draw: draw,
                show: show,
                resetHighScores: resetHighScores,
                loadHighScores: loadHighScores,
                addHighScore: addHighScore,
                saveHighScores: saveHighScores,
                setTitle: setTitle,
                updateHighScoresBoard: updateHighScoresBoard
            };
        }())

        return HighScores;
    }();

    return { // score module
        getScoresBoard: function (scoresContainer, scoresStorage) {
            if (!scoresInstance) {
                scoresInstance = new HighScores(scoresContainer, scoresStorage);
            }
            return scoresInstance;
        },
        resetHighScores: function () {
            scoresInstance.resetHighScores();
        }
    }
}();