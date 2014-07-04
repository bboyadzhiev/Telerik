/// <reference path="snakeCanvas.js" />
var directions = {
    up: 1,
    down: 2,
    right: 3,
    left: 4
};

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

var snakeEngine = (function () {
    var
        kbdCodes1 = {
            up: 87,
            down: 83,
            left: 65,
            right: 68
        },
        kbdCodes2 = {
            up: 38,
            down: 40,
            left: 37,
            right: 39
        },
        collisionType = {
            himself: 1,
            otherPlayer: 2,
            border: 3,
            obstacle: 4
        };
    var mainLoop,
        SPEED = 250;//ms
    

    var startGame = function (itemsCount, boardWidth, boardHeight) {
        var boardWidth = boardWidth || 40;
        var boardHeight = boardHeight || 20;
        var itemsCount = itemsCount || (boardWidth * boardHeight) / 100;

        var snakeField = snakeCanvas.getSnakeCanvas(boardWidth, boardHeight);
        var snake1 = new Snake(5, 5, 1, directions.right, 1);
        var snake2 = new Snake(5, boardWidth - 6, boardHeight - 2, directions.left, 2);

        var guilty = 0;
        var wBorder = boardWidth - 1,
            hBorder = boardHeight - 1;
        var items = randomItems(itemsCount, wBorder, hBorder);

        snakeField.drawBoard();


        snakeControls(snake1, snake2);
        clearInterval(mainLoop);
        mainLoop = setInterval(function () {
            // check for items
            snake1.eatItems(items);
            snake2.eatItems(items);
            
           // snake1.finishRedirection();
           // snake2.finishRedirection();

            //Check for collisions
            if (snake1.inSnakeCollision(snake2) || snake1.inSelfCollision() || snake1.inBorderCollision(wBorder, hBorder)) {
                guilty += 1;
            }

            if (snake2.inSnakeCollision(snake1) || snake2.inSelfCollision() || snake2.inBorderCollision(wBorder, hBorder)) {
                guilty += 2;
            }

            if (guilty != 0) {
                if (guilty == 1) {
                    confirm('Player 1 has collided ' + snake1.getCollision());
                } else if (guilty == 2) {
                    confirm('Player 2 has collided ' + snake2.getCollision());
                } else {
                    confirm('Both players have collided ' + snake1.getCollision() + '!');
                }
                //clean corpse (snake1); not needed but available anyway
                snakeField.clearSnake(snake2.getBody());
                snake1.reset();
                //clean corpse (snake2); not needed but available anyway
                snakeField.clearSnake(snake2.getBody());
                snake2.reset();

                //redraw board
                snakeField.drawBoard(boardWidth, boardHeight);
                guilty = 0;
                items = randomItems(itemsCount, wBorder, hBorder);
            }

            //Items
            snakeField.drawItems(items);
            //Snake 1
            snakeField.clearPosition(snake1.getTail());
            snake1.move();
            snakeField.reDrawSnake(snake1.getBody(), snake1.direction);
            //Snake 2
            snakeField.clearPosition(snake2.getTail());
            snake2.move();
            snakeField.reDrawSnake(snake2.getBody(), snake2.direction);

        }, SPEED);
    };

    var randomItems = function (itemsCount, wBorder, hBorder) {
        var items = [];
        for (var i = 0; i < itemsCount; i++) {
            items.push(new Item(wBorder, hBorder));
        }
        return items;
    };

    var snakeControls = function (snake1, snake2) {
        document.onkeydown = function (event) {
            event = event || window.event;
            switch (event.keyCode) {
                case kbdCodes1.up: snake1.changeDirection(directions.up); break;
                case kbdCodes1.down: snake1.changeDirection(directions.down); break;
                case kbdCodes1.left: snake1.changeDirection(directions.left); break;
                case kbdCodes1.right: snake1.changeDirection(directions.right); break;
                case kbdCodes2.up: snake2.changeDirection(directions.up); break;
                case kbdCodes2.down: snake2.changeDirection(directions.down); break;
                case kbdCodes2.left: snake2.changeDirection(directions.left); break;
                case kbdCodes2.right: snake2.changeDirection(directions.right); break;
            }
        }
    };

    var Item = function (wBorder, hBorder) {
        this.x = getRandomInt(1, wBorder-1);
        this.y = getRandomInt(1, hBorder-1);

        return { x: this.x, y: this.y }
    };

    var Snake = function (startLength, startX, startY, startDirection, id) {
        this.startLength = startLength || 4;
        this.startX = startX;
        this.startY = startY;
        this.startDirection = startDirection;
        this.reset();
        this.collision = collisionType.himself;
        this.hasEated = 0;
        this.id = id;
        this.points = 0;
        this.redirecting = false;
    };

    Snake.prototype = (function () {
        var i, j,
        getHead, getTail, getBody, grow,
        reset,
        move, getDirection, changeDirection,
        eatItems, hasRedirected,
        getCollision, inSelfCollision, inSnakeCollision, inBorderCollision;

        getHead = function () {
            return this.body[0];
        };

        getBody = function () {
            var _body = this.body.slice()
            return _body;
        }

        getTail = function () {
            var _tail = this.body[this.body.length - 1]
            return _tail;
            // return this.body[this.body.length - 1];
        };

        grow = function () {
            var currentX = this.getHead().x,
                            currentY = this.getHead().y;
            switch (this.direction) {
                case directions.up: this.body.unshift({ x: currentX, y: currentY - 1 }); break;
                case directions.down: this.body.unshift({ x: currentX, y: currentY + 1 }); break;
                case directions.left: this.body.unshift({ x: currentX - 1, y: currentY }); break;
                case directions.right: this.body.unshift({ x: currentX + 1, y: currentY }); break;
            }
        }

        reset = function () {
            this.direction = this.startDirection;
            this.body = [];

            for (var i = 0; i < this.startLength; i++) {
                if (this.direction == directions.left) {
                    this.body.push({ x: this.startX + i, y: this.startY });
                }
                if (this.direction == directions.right) {
                    this.body.push({ x: this.startX - i, y: this.startY });
                }
            }
        }

        move = function () {
            this.grow();
            if (this.hasEated > 0) {
                this.hasEated--;
            } else {
                this.body.pop();
            }
        };

        getDirection = function () {
            var _dir = this.direction;
            return _dir;
        }

        changeDirection = function (newDirection) {
            var currentDirection = this.direction;
            var change = false;
            var currentX = this.getHead().x,
            currentY = this.getHead().y;
            if (this.redirecting || currentDirection == newDirection) {
                return;
            }

            switch (newDirection) {
                case directions.up:
                    if (currentDirection != directions.down) {
                        change = true;
                    }
                    break;
                case directions.down:
                    if (currentDirection != directions.up) {
                        change = true;
                    }
                    break;
                case directions.left:
                    if (currentDirection != directions.right) {
                        change = true;
                    }
                    break;
                case directions.right:
                    if (currentDirection != directions.left) {
                        change = true;
                    }
                    break;
            }

            if (change) {
                this.direction = newDirection;
             //   this.redirecting = true;
            }
        };

        finishRedirection = function () {
            this.redirecting = false;
        }

        eatItems = function (items) {
            var head = this.getHead();
            for (var i = 0; i < items.length; i++) {
                if (head.x == items[i].x && head.y == items[i].y) {
                    items.splice(i, 1);
                    this.hasEated++;
                }
            }
        };

        getCollision = function () {
            var reason;
            switch (this.collision) {
                case collisionType.himself: reason = 'with himself';  break;
                case collisionType.otherPlayer: reason = 'with the other player'; break;
                case collisionType.border: reason = 'with the border'; break;
                case collisionType.obstacle: reason = 'with an obstacle'; break;
            }
            return reason;
        };

        inSelfCollision = function () {
            var head = this.getHead();
            var length = this.getBody().length;
            var inCollision = false;
            for (var i = 1; i < length; i++) {
                if (head.x == this.getBody()[i].x && head.y == this.getBody()[i].y) {
                    this.collision = collisionType.himself;
                    inCollision = true;
                }
            }
            return inCollision;
        };

        inSnakeCollision = function (otherSnake) {
            var head = this.getHead();
            var otherLength = otherSnake.getBody().length;
            var inCollision = false;
            for (var i = 0; i < otherLength; i++) {
                if (head.x == otherSnake.getBody()[i].x && head.y == otherSnake.getBody()[i].y) {
                    this.collision = collisionType.otherPlayer;
                    inCollision = true;
                }
            }
            return inCollision;
        };

        inBorderCollision = function (boardWidth, boardHeight) {
            var head = this.getHead();
            var length = this.getBody().length;
            var inCollision = false;
            for (var i = 0; i < length; i++) {
                if (head.x == boardWidth
                    || head.y == boardHeight
                    || head.x == 0
                    || head.y == 0) {
                    this.collision = collisionType.border;
                    inCollision = true;
                }
            }
            return inCollision;
        };

        return {
            
            changeDirection: changeDirection,
            finishRedirection: finishRedirection,
            getHead: getHead,
            getTail: getTail,
            getBody: getBody,
            grow: grow,
            move: move,
            eatItems: eatItems,
            getCollision: getCollision,
            inSelfCollision: inSelfCollision,
            inBorderCollision: inBorderCollision,
            inSnakeCollision: inSnakeCollision,
            reset: reset
        }

    }());

    return {
        startGame: startGame
    }
}());

