var scoresModule = function () {
    var Scores, scoresInstance;
    var scoresContainer = document.getElementById('scoresDiv');
    var 
        playersDiv = document.createElement('div'),
        playerBoardPattern = document.createElement('div'),
        playerTitlePattern = document.createElement('h2'),
        playerScorePattern = document.createElement('h3'),
        playerLivesPattern = document.createElement('p');
    scoresContainer.style.display = "inline-block";
    scoresContainer.style.border = "1px solid black";
    scoresContainer.style.verticalAlign = 'top';
    scoresContainer.style.textAlign = 'center';
    scoresContainer.style.float = 'left';

    function refreshBoardDiv(boardDiv, title, score, lives) {
        var hTitle = boardDiv.children[0];
        hScore = boardDiv.children[1];
        hLives = boardDiv.children[2];

        hTitle.innerHTML = title;
        hScore.innerHTML = "Score: " + score;
        hLives.innerHTML = "Lives: " + lives;
        return boardDiv;
    }

    function buildBoardDiv(playerBoard, player) {
        var playerTitle = playerTitlePattern.cloneNode(true),
            playerScore = playerScorePattern.cloneNode(true),
            playerLives = playerLivesPattern.cloneNode(true);

        playerBoard.appendChild(playerTitle);
        playerBoard.appendChild(playerScore);
        playerBoard.appendChild(playerLives);

        playerBoard = refreshBoardDiv(playerBoard, player.title, player.score, player.lives);
        return playerBoard;
    }


    Scores = (function (scoresWidth, scoresHeight) {
        function Scores(scoresWidth, scoresHeight) {
            scoresContainer.style.width = scoresWidth + 'px';
            scoresContainer.style.height = scoresHeight + 'px';
            this.players = [];
        }

        Scores.prototype = (function () {
            function updatePlayer(player) {
                for (var i = 0; i < this.players.length; i++) {
                    if (this.players[i].id == player.id) {
                        this.players[i].title = player.title;
                        this.players[i].score = player.score;
                        this.players[i].lives = player.lives;
                    }
                }
            }

            function addPlayer(player) {
                this.players.push(player);
                var currentPlayerBoard = playerBoardPattern.cloneNode(true);
                var board = buildBoardDiv(currentPlayerBoard, player);
                playersDiv.appendChild(board);
                
            }

            function updatePlayersBoards() {
                for (var i = 0; i < this.players.length; i++) {
                    var currentPlayerBoard = playerBoardPattern.cloneNode(true);
                    var board = buildBoardDiv(currentPlayerBoard, this.players[i])
                   
                    playersDiv.children[i].innerHTML = board.innerHTML;
                }

            }

            function draw() {
                var scoresFragment = document.createDocumentFragment();

                scoresFragment.appendChild(playersDiv);
                scoresContainer.appendChild(scoresFragment);
            }

            return { // prototype functions
                addPlayer: addPlayer,
                updatePlayer: updatePlayer,
                updatePlayersBoards: updatePlayersBoards,
                draw: draw
            };

        }());

        return Scores;
    }());

    return { // score module
        getScoresBoard: function (scoresWidth, scoresHeight) {
            if (!scoresInstance) {
                scoresInstance = new Scores(scoresWidth, scoresHeight);
            }
            return scoresInstance;
        }
    }
}();