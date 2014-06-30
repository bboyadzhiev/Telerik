var movingShapes = (function () {
    var contentDiv = document.getElementById("whirlDiv"),
        div = document.createElement("div"),
        divs = [];

    var RECTS_ACCELERATION = 2,
        RECT_ROTATION_WIDTH = 600,
        RECT_ROTATION_HEIGHT = 350,
        pathLength = 2 * RECT_ROTATION_WIDTH + 2 * RECT_ROTATION_HEIGHT,
        DIV_WIDTH = 100;
    DIV_HEIGHT = 100;

    var center = {
        x: window.innerWidth / 2 - DIV_WIDTH,
        y: window.innerHeight / 2 - DIV_HEIGHT
    },
         radius = 150,
         angle = 0,
         point = {
             radius: 5,
             x: 0,
             y: 0
         };

    var maxTop = center.y - (RECT_ROTATION_HEIGHT / 2),
           maxBottom = center.y + (RECT_ROTATION_HEIGHT / 2),
           maxLeft = center.x - (RECT_ROTATION_WIDTH / 2),
           maxRight = center.x + (RECT_ROTATION_WIDTH / 2);


    var rectTrajectory = document.createElement("div");
    rectTrajectory.style.width = RECT_ROTATION_WIDTH + 'px';
    rectTrajectory.style.height = RECT_ROTATION_HEIGHT + 'px';
    rectTrajectory.innerHTML = "rectTrajectory";
    rectTrajectory.style.border = '1px solid black';
    rectTrajectory.style.position = "absolute";
    rectTrajectory.style.top = maxTop + DIV_HEIGHT / 2 + 'px';
    rectTrajectory.style.left = maxLeft + DIV_WIDTH / 2 + 'px';
    contentDiv.appendChild(rectTrajectory.cloneNode(true));


    var divsNumber = 0;
    function add(type) {
        setupDiv(div);
        div.classList.remove('ellipse');
        div.classList.remove('rect');
        div.classList.add(type);
        div.innerHTML += divsNumber;
        divsNumber++;
        contentDiv.appendChild(div.cloneNode(true));
        resetRectDivsPositions(pathLength);
    }

    function setupDiv(div) {
        var divColor,
            divBGColor,
            borderWidth,
            borderRadius,
            borderColor;

        divColor = getRandomInt(0, 16777215);
        divBGColor = getRandomInt(0, 16777215);

        //border
        borderWidth = getRandomInt(1, 20);
        borderRadius = getRandomInt(1, 50);
        borderColor = getRandomInt(0, 16777215);

        div.innerHTML = "div";
        div.style.position = "absolute";
        div.style.width = DIV_WIDTH + "px";
        div.style.height = DIV_HEIGHT + "px";

        div.style.backgroundColor = "#" + divBGColor.toString(16);
        div.style.color = "#" + divColor.toString(16);

        div.style.border = borderWidth + 'px solid #' + borderColor.toString(16);
        div.style.borderRadius = borderRadius + "px";

    }

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function movePoint(trajectory) {
        return {
            x: trajectory.x + trajectory.radius * Math.cos(trajectory.angle),
            y: trajectory.y + trajectory.radius * Math.sin(trajectory.angle)
        };
    }

    function rotateEllipseDivs(contentDiv) {
        var ellipseDivs = contentDiv.querySelectorAll('.ellipse');
        if (ellipseDivs) {
            angle += 0.05;

            var pointsCount = ellipseDivs.length;
            for (var i = 0; i < pointsCount; i++) {
                var div = ellipseDivs[i];
                var newPoint = movePoint({
                    x: center.x,
                    y: center.y,
                    radius: radius,
                    angle: angle + i * 2 * Math.PI / pointsCount
                });
                div.style.left = newPoint.x + "px";
                div.style.top = newPoint.y + "px";
            }
        }
    }

    // calculates divs initial position starting from 
    // [center - width/2 , center - height/2]
    function resetRectDivsPositions(pathLength) {
        var rectDivs = contentDiv.querySelectorAll('.rect');
        if (rectDivs) {
            var rectsCount = rectDivs.length;
            var offset = pathLength / rectsCount;

            for (var rectNum = 0; rectNum < rectsCount; rectNum++) {
                var div = rectDivs[rectNum];
                var distance = offset * rectNum;

                // top of rectangle trajectory
                if (distance <= RECT_ROTATION_WIDTH) {
                    div.setAttribute('direction', 'right');
                    div.style.top = maxTop + "px";
                    div.style.left = maxLeft + distance + "px";
                }

                // right side of rectangle trajectory
                if (distance > RECT_ROTATION_WIDTH && distance <= RECT_ROTATION_WIDTH + RECT_ROTATION_HEIGHT) {
                    div.setAttribute('direction', 'down');
                    div.style.top = maxTop + (distance - RECT_ROTATION_WIDTH) + "px";
                    div.style.left = maxRight + "px";
                }

                // bottom side of rectangle trajectory
                if (distance > (RECT_ROTATION_WIDTH + RECT_ROTATION_HEIGHT) && distance <= (2 * RECT_ROTATION_WIDTH + RECT_ROTATION_HEIGHT)) {
                    div.setAttribute('direction', 'left');
                    div.style.top = maxBottom + "px";
                    div.style.left = (maxRight - (distance - RECT_ROTATION_WIDTH - RECT_ROTATION_HEIGHT)) + "px";
                }

                // left side of rectangle trajectory
                if (distance > (2 * RECT_ROTATION_WIDTH + RECT_ROTATION_HEIGHT)) {
                    div.setAttribute('direction', 'up');
                    div.style.top = (maxBottom - (distance - 2 * RECT_ROTATION_WIDTH - RECT_ROTATION_HEIGHT)) + "px";
                    div.style.left = maxLeft + "px";
                }
            }
        }
    }

    function rotateRectDivs(contentDiv) {
        var rectDivs = contentDiv.querySelectorAll('.rect');
        var left, top;
        if (rectDivs.length > 0) {

            for (var i = 0; i < rectDivs.length; i++) {
                var direction = rectDivs[i].getAttribute('direction');
                left = parseInt(rectDivs[i].style.left);
                top = parseInt(rectDivs[i].style.top);
                switch (direction) {
                    case 'left': left = left - RECTS_ACCELERATION; break;
                    case 'down': top = top + RECTS_ACCELERATION; break;
                    case 'right': left = left + RECTS_ACCELERATION; break;
                    case 'up': top = top - RECTS_ACCELERATION; break;
                }
                rectDivs[i].style.left = left + 'px';
                rectDivs[i].style.top = top + 'px';

                if ((top > maxBottom) && (direction == 'down')) {
                    rectDivs[i].setAttribute('direction', 'left');
                }
                if ((top < maxTop) && (direction == 'up')) {
                    rectDivs[i].setAttribute('direction', 'right');
                }
                if ((left > maxRight) && (direction == 'right')) {
                    rectDivs[i].setAttribute('direction', 'down');
                }
                if ((left < maxLeft) && (direction == 'left')) {
                    rectDivs[i].setAttribute('direction', 'up');
                }
            }
        }
    }

    function rotateDivs() {
        rotateEllipseDivs(contentDiv);
        rotateRectDivs(contentDiv);
    }

    setInterval(rotateDivs, 100);
    console.log('maxleft:' + maxLeft);
    console.log('maxTop:' + maxTop);
    console.log('maxRight:' + maxRight);
    console.log('maxBottom:' + maxBottom);

    return {
        add: add
    }

}());