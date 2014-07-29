/// <reference path="highscores.js" />
function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
var sheepsAndRams = function () {
    var SheepsAndRams, sheepsAndRamsInstance;
    var START_SCORE = 2000, CODE_LENGTH = 4;
    var resultPattern = document.createElement('p'),
        mainLoop, score;
    SheepsAndRams = (function () {
        function SheepsAndRams(playerName, playerInput, outputId, hsOutput) {
            this._input = document.getElementById(playerInput);
            this._output = document.getElementById(outputId);
            this._outputID = outputId;
            this._playerName = playerName;
            this._highScores = highScores.getScoresBoard(hsOutput, "sheeps")
            this._highScores.setTitle("Sheeps And Rams");
            this.restart();
        }

        SheepsAndRams.prototype.run = function () {
            mainLoop = setInterval(function () {
                score--;
            }, 1000);
        };
        SheepsAndRams.prototype.stop = function () {
            clearInterval(mainLoop);
        };

        SheepsAndRams.prototype.restart = function () {
            console.clear();
            score = START_SCORE;
            this._abcd = getRandomInt(1000, 9999);
            this._code = this.getCode(this._abcd);

            var clean = this._output.querySelectorAll("p");

            for (var i = 0; i < clean.length; i++) {
                this._output.removeChild(clean[i]);
            }
            this._running = true;
            this.run();
        }

        SheepsAndRams.prototype.showHighScores = function () {
            this._highScores.addHighScore(this._playerName, score);
            this._highScores.updateHighScoresBoard();
            this._highScores.draw();
        }

        SheepsAndRams.prototype.testCode = function () {
            if (!this._running) {
                this.restart();
                return;
            }
            var playerCode = this._input.value;
            var result, i, playerCodeString = '';
            if (playerCode.length !== CODE_LENGTH) {
                alert("Code is invalid!");
            } else {
                result = this.checkCode(this.getCode(playerCode));

                for (i = 0; i < playerCode.length; i++) {
                    playerCodeString += playerCode[i] + ' ';
                }

                var res = resultPattern.cloneNode(true);
                res.innerHTML = playerCodeString + ' - Rams: ' + result.rams + ' Sheep: ' + result.sheep;
                this._output.appendChild(res);

                if (result.rams == 4) {
                    this.stop();
                    this._playerName = window.prompt("Success! Score: " + score + " \n Enter your name:", this._playerName);
                    this.showHighScores();
                    this._running = false;
                }
            }
        }

        SheepsAndRams.prototype.getCode = function (number) {
            var code = [];
            var len = number.toString().length;
            console.log("Code length is " + len + " digits");
            for (var i = 0; i < len; i++) {
                if (i == 0) {
                    code.unshift(Math.floor(number % 10));
                } else {
                    code.unshift(Math.floor((number / Math.pow(10, i)) % 10));
                }
            }

            // var a = Math.floor( (number / 1000) % 10);
            // var b = Math.floor((number / 100) % 10);
            // var c = Math.floor( (number / 10) % 10);
            // var d = Math.floor( number % 10);
            console.log(code);
            return code;
        };

        SheepsAndRams.prototype.checkCode = function (playerCode) {

            var m, i, j, k, rams = 0, sheep = 0, skip = false;
            var ramPositions = [], sheepPositions = [];
            var len = playerCode.length;
            for (m = 0; m < length; m++) {
                ramPositions.push(false);
                sheepPositions.push(false);
            };

            for (i = 0; i < len; i++) {
                if (playerCode[i] == this._code[i]) {
                    rams++;
                    ramPositions[i] = true;
                    //console.log('found ram at ' + i);
                } else {
                    for (j = 0; j < len; j++) {
                        if (playerCode[i] == this._code[j] && !ramPositions[i] && !sheepPositions[i]) {
                            sheep++;
                            sheepPositions[i] = true;
                            //  console.log('found sheep at ' + i);
                        }
                    }
                }
            }
            return {
                rams: rams,
                sheep: sheep
            }
        }
        return SheepsAndRams;
    }())

    return {
        startGame: function (playerName, playerInput, outputId, hsOutput) {
            if (!sheepsAndRamsInstance) {
                sheepsAndRamsInstance = new SheepsAndRams(playerName, playerInput, outputId, hsOutput);
            }
            return sheepsAndRamsInstance;
        },
        testCode: function () {
            return sheepsAndRamsInstance.testCode();
        },
        restartGame: function () {
            return sheepsAndRamsInstance.restart();
        }

    }

}();