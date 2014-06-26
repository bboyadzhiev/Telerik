(function () {

    var divsCount = Math.floor((Math.random() * 100) + 1);

    contentDiv = document.body;

    var div = document.createElement("div");

    div.innerHTML = "div";
    div.style.position = "absolute";

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function createDivs() {
        var absoluteX, absoluteY, width, height, color, divColor, divBGColor,
            borderWidth,
            borderRadius,
            borderColor;

        for (var i = 0; i < divsCount; i++) {           
            absoluteX = getRandomInt(0, window.innerWidth);
            absoluteY = getRandomInt(0, window.innerHeight);
            width = getRandomInt(20, 100);
            height = getRandomInt(20, 100);
            divColor = getRandomInt(0, 16777215);
            divBGColor = getRandomInt(0, 16777215);
            
            //border
            borderWidth = getRandomInt(1, 20);
            borderRadius = getRandomInt(1, 50);
            borderColor = getRandomInt(0, 16777215);

            div.style.width = width + "px";
            div.style.height = height + "px";
            div.style.left = absoluteX + "px";
            div.style.top = absoluteY + "px";
            div.style.backgroundColor = "#" + divBGColor.toString(16);
            div.style.color = "#" + divColor.toString(16);

            div.style.border = borderWidth + 'px solid #' + borderColor.toString(16);
            div.style.borderRadius = borderRadius + "px";

            contentDiv.appendChild(div.cloneNode(true));
        }
    }

    createDivs();
}());