(function () {

    var center = {
        x: window.innerWidth / 2,
        y: window.innerHeight / 2
    },
         radius = 150,
         angle = 0,
         point = {
             radius: 5,
             x: 0,
             y: 0
         };

    var divsCount = getRandomInt(3, 10);

    contentDiv = document.getElementById("whirlDiv");

    var div = document.createElement("div");

    div.innerHTML = "div";
    div.style.position = "absolute";
    div.style.width = "100px";
    div.style.height = "100px";
    div.style.border = ' 2px solid black';

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }


    function movePoint(trajectory) {
        return {
            x: trajectory.x + trajectory.radius * Math.cos(trajectory.angle),
            y: trajectory.y + trajectory.radius * Math.sin(trajectory.angle)
        };
    }

    function createDivs() {
        var  divColor, divBGColor,
            borderWidth,
            borderRadius,
            borderColor;

        for (var i = 0; i < divsCount; i++) {
            divColor = getRandomInt(0, 16777215);
            divBGColor = getRandomInt(0, 16777215);
            div.style.backgroundColor = "#" + divBGColor.toString(16);
            div.style.color = "#" + divColor.toString(16);
            contentDiv.appendChild(div.cloneNode(true));
        }
    }

    function RotateDivs() {
        var div = contentDiv.firstChild;
        angle += 0.05;
        var pointsCount = contentDiv.childElementCount;

        // found rotation alorithm in canvas demos and transformed it for divs
        for (var i = 0; i < pointsCount; i += 1) {
            var newPoint = movePoint({
                x: center.x,
                y: center.y,
                radius: radius,
                angle: angle + i * 2 * Math.PI / pointsCount
            });
            
            div.style.left = newPoint.x+"px";
            div.style.top = newPoint.y + "px";    
            div = div.nextSibling;
        }

    }

    createDivs();
    setInterval(RotateDivs, 100);
}());