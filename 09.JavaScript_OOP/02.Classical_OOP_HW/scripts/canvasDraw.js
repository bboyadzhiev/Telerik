function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

var Canvas = (function () {
    function Canvas(canvasId) {
        if (!(this instanceof arguments.callee)) {
            return new CanvasDraw(canvasId);
        }
        console.log('new Canvas created');
        this.canvas = document.getElementById(canvasId);
    }

    Canvas.prototype.Line = function (x1, y1, x2, y2) {
        console.log('new Line added');
        var ctx = this.canvas.getContext('2d'),
            color;
        color = getRandomInt(0, 16777215);
        ctx.lineWidth = 2;
        ctx.strokeStyle = "#" + color.toString(16);
        ctx.beginPath();
        ctx.moveTo(x1, y1);
        ctx.lineTo(x2, y2);
        ctx.stroke();
    }

    Canvas.prototype.Circle = function (x, y, radius) {
        console.log('new Circle added');
        var ctx = this.canvas.getContext('2d'),
            color;
        ctx.beginPath();
        ctx.lineWidth = 2;
        color = getRandomInt(0, 16777215);
        ctx.strokeStyle = "#" + color.toString(16);
        ctx.arc(x, y, radius, 0, 2 * Math.PI);
        color = getRandomInt(0, 16777215);
        ctx.fillStyle = "#" + color.toString(16);
        ctx.fill();
        ctx.stroke();
    }

    Canvas.prototype.Rect = function (x, y, width, height) {
        console.log('new Rect added');
        var ctx = this.canvas.getContext('2d'),
            color;
        color = getRandomInt(0, 16777215);
        ctx.lineWidth = 2;
        color = getRandomInt(0, 16777215);
        ctx.strokeStyle = "#" + color.toString(16);
        color = getRandomInt(0, 16777215);
        ctx.fillStyle = "#" + color.toString(16);
        ctx.beginPath();
        ctx.rect(x, y, width, height);
        ctx.fill();
        ctx.stroke();
    }

    return Canvas;
}());