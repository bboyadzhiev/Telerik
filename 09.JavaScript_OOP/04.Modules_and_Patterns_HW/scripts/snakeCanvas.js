/// <reference path="snakeEngine.js" />
var snakeCanvas = function () {
    var SnakeCanvas, snakeCanvasInstance;
    var ELEMENT_SIZE = 10;
    var id = 0;
    var elements = {
        snakeBody: "images/body.png",
        snakeHead: "images/head.png",
        headUp: "images/headUp.png",
        headDown: "images/headDown.png",
        headLeft: "images/headLeft.png",
        headRight: "images/headRight.png",
        playground: "images/ground.png",
        border: "images/border.png",
        item: "images/item.png"
    };
    
    var canvas = document.getElementById('snakeCanvas');
    var ctx = canvas.getContext('2d'),

    SnakeCanvas = (function (boardWidth, boardHeight) {
        function SnakeCanvas(boardWidth, boardHeight) {
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            this.tiles = 0;
            this._id = id;
            id++;
            canvas.setAttribute('width', boardWidth * ELEMENT_SIZE);
            canvas.setAttribute('height', boardHeight * ELEMENT_SIZE);
            console.log("Snake Canvas Created " + this._id);
        }

        function drawTile(element, x, y, sizeX, sizeY) {
            var tile = new Image();
            tile.src = element;
            tile.onload = function () {
                ctx.drawImage(tile, x, y, sizeX, sizeY);
            }

        }

        SnakeCanvas.prototype.drawItems = function (items) {
            for (var i = 0; i < items.length; i++) {
                drawTile(elements.item, items[i].x * ELEMENT_SIZE, items[i].y * ELEMENT_SIZE, ELEMENT_SIZE, ELEMENT_SIZE);
            }
        }

        SnakeCanvas.prototype.clearPosition = function (position) {
            drawTile(elements.playground, position.x * ELEMENT_SIZE, position.y * ELEMENT_SIZE, ELEMENT_SIZE, ELEMENT_SIZE);
        }

        SnakeCanvas.prototype.drawHead = function (snakeBody, direction) {
            var head;
            switch (direction) {
                case directions.up: head = elements.headUp; break;
                case directions.down: head = elements.headDown; break;
                case directions.right: head = elements.headRight; break;
                case directions.left: head = elements.headLeft; break;
            }
            drawTile(head, snakeBody[0].x * ELEMENT_SIZE, snakeBody[0].y * ELEMENT_SIZE, ELEMENT_SIZE, ELEMENT_SIZE);
        }

        SnakeCanvas.prototype.reDrawSnake = function (snakeBody, direction) {
            this.drawHead(snakeBody, direction);
            for (var i = 1; i < snakeBody.length; i++) {
                drawTile(elements.snakeBody, snakeBody[i].x * ELEMENT_SIZE, snakeBody[i].y * ELEMENT_SIZE, ELEMENT_SIZE, ELEMENT_SIZE);
            }
        }

        SnakeCanvas.prototype.clearSnake = function (snakeBody) {
            for (var m = 0; m < snakeBody.length; m++) {
                drawTile(elements.playground, snakeBody[m].x * ELEMENT_SIZE, snakeBody[m].y * ELEMENT_SIZE, ELEMENT_SIZE, ELEMENT_SIZE);
            }
        }

        SnakeCanvas.prototype.drawBoard = function () {
            var sizeX = this.boardWidth, sizeY = this.boardHeight;
            for (var i = 0; i < sizeX; i++) {
                for (var j = 0; j < sizeY; j++) {
                    if (j == 0 || i == 0 || i == sizeX - 1 || j == sizeY - 1) {
                        drawTile(elements.border, i * ELEMENT_SIZE, j * ELEMENT_SIZE, ELEMENT_SIZE, ELEMENT_SIZE);
                    } else {
                        drawTile(elements.playground, i * ELEMENT_SIZE, j * ELEMENT_SIZE, ELEMENT_SIZE, ELEMENT_SIZE);
                    }
                    this.tiles++;
                }
            }
            console.log("tiles=" + this.tiles);
        }

        return SnakeCanvas;
    }());



    return {
        getSnakeCanvas: function (boardWidth, boardHeight) {
            if (!snakeCanvasInstance) {
                snakeCanvasInstance = new SnakeCanvas(boardWidth, boardHeight);
            }
            return snakeCanvasInstance;
        }
    }

}();