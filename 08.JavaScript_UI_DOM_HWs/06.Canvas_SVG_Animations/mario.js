(function () {
var pattern = new Image();
var svgNameSpace = 'http://www.w3.org/2000/svg';
var svg = document.getElementById('svgElement');
svg.setAttribute('width', window.innerWidth);
svg.setAttribute('height', window.innerHeight);
//function animate() {
    
    //requestAnimationFrame(drawMario);
//}

function createRect(x, y, width, height, fill, stroke, sw) {
    var rect;
    rect = document.createElementNS(svgNameSpace, 'rect');
    rect.setAttribute('x', x);
    rect.setAttribute('y', y);
    rect.setAttribute('width', width);
    rect.setAttribute('height', height);
    rect.setAttribute('fill', fill);
    rect.setAttribute('stroke', stroke);
    rect.setAttribute('stroke-width', sw);
    return rect;
}

function createPath(points, fill, stroke, sw) {
    var path;
    path = document.createElementNS(svgNameSpace, 'path');
    path.setAttribute('d', points);
    path.setAttribute('fill', fill);
    path.setAttribute('stroke', stroke);
    path.setAttribute('stroke-width', sw);
    return path;
}

function createCircle(x, y, r, fill, stroke, sw) {
    var circle;
    circle = document.createElementNS(svgNameSpace, 'circle');
    circle.setAttribute('cx', x);
    circle.setAttribute('cy', y);
    circle.setAttribute('r', r);
    circle.setAttribute('fill', fill);
    circle.setAttribute('stroke', stroke);
    circle.setAttribute('stroke-width', sw);
    return circle;
}

function createText(x, y, content, size, fill, stroke, sw, ff) {
    var text = document.createElementNS(svgNameSpace, 'text');
    text.setAttribute('font-family', ff);
    text.setAttribute('x', x);
    text.setAttribute('y', y);
    text.setAttribute('font-size', size);
    text.textContent = content;
    text.setAttribute('fill', fill);
    text.setAttribute('stroke', stroke);
    text.setAttribute('stroke-width', sw);
    return text;
}

function createImage(x, y, width, height, link) {
    var image = document.createElementNS(svgNameSpace, 'image');
    image.setAttributeNS('http://www.w3.org/1999/xlink', 'href', link);
    image.setAttribute('x', x);
    image.setAttribute('y', y);
    image.setAttribute('width', width + 'px');
    image.setAttribute('height', height + 'px');
    return image;
}


var frameNumber = 0;
var position = 0;

var bgobjects = [{
        type: 'path',
        definition: 'M35.3979 14.5162c8.71738,-28.9586 31.1215,-1.2749 31.1215,2.13814 0,5.2009 -14.894,9.41867 -33.2597,9.41867 -18.3657,0 -33.2597,-4.21776 -33.2597,-9.41867 0,-2.4379 5.03862,-16.7275 17.177,-2.50624 -4.71771,-24.2505 17.6712,-12.7186 18.2208,0.368095z', // x y r
        fill: '#ffffff',
        stroke: '#000000',
        sw: 1,
        transform: 'matrix(2, 0, 0, 2, 400, 2)'
}, {
        type: 'path',
        definition: 'M22.2929 14.2548c-8.71738,-28.9586 -22.2929,-3.433 -22.2929,-0.0199524 0,3.9031 8.59548,17.8469 15.2472,8.48486 0,10.688 16.8885,6.57067 23.1162,0.713095 10.1705,10.1705 28.1559,-4.80971 28.1559,-9.19795 0,-2.4379 -9.30657,-14.1288 -21.445,0.0924762 4.71771,-24.2505 -22.2318,-13.1592 -22.7814,-0.0725238z', // x y r
        fill: '#ffffff',
        stroke: '#000000',
        sw: 1,
        transform: 'matrix(2, 0, 0, 2, 130, 20)'
}];


function drawSVGGroup(group, svgElement) {
    var x = 0;
    var y = 0;
    for (var i = 0; i < group.length; i++) {
       
            var dims = group[i].definition.split(" ");
            var figure;

            switch (group[i].type) {
                case 'rect': figure = createRect(dims[0], dims[1], dims[2], dims[3], group[i].fill, group[i].stroke, group[i].sw); break;
                case 'circle': figure = createCircle(dims[0], dims[1], dims[2], group[i].fill, group[i].stroke, group[i].sw); break;
                case 'path':
                    figure = createPath(group[i].definition, group[i].fill, group[i].stroke, group[i].sw);
                    break;
                case 'text': figure = createText(dims[0], dims[1], group[i].content, group[i].size, group[i].fill, group[i].stroke, group[i].sw, group[i].fontfamily); break;
                case 'image': figure = createImage(dims[0], dims[1], dims[2], dims[3], group[i].link); break;
            }

           if (group[i].transform) {
               figure.setAttribute('transform', 'translate(' + x + ', ' + y + ') ' + group[i].transform);
           } else {
               figure.setAttribute('transform', 'translate(' + x + ', ' + y + ')');
           }

            svgElement.appendChild(figure);
        
    }
}

function drawMario() {
    
    var canvas = document.getElementById('mycanvas');
    var ctx = canvas.getContext('2d'); 
    canvas.setAttribute('width', window.innerWidth);
    canvas.setAttribute('height', window.innerHeight);
    //ctx.fillStyle = 'rgba(0,0,0,0.4)';
    //ctx.strokeStyle = 'rgba(0,153,255,0.4)';
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.save();

    ctx.translate(position, 10);
    switch (frameNumber) {
        case 0: pattern.src = 'sprites/0.jpg'; break;
        case 1: pattern.src = 'sprites/1.png'; break;
        case 2: pattern.src = 'sprites/2.png'; break;
        case 3: pattern.src = 'sprites/3.png'; break;
    }

    pattern.setAttribute("width", "60px");
    ctx.drawImage(pattern, 0, canvas.height-100, 40, 40);
    ctx.restore();

    frameNumber++;
    if (frameNumber == 4) {
        frameNumber = 0;
    }
    position += 2;
    if (position > canvas.width) {
        position = 0;
    }

    //requestAnimationFrame(drawMario);
}

drawSVGGroup(bgobjects, svg);
setInterval(drawMario, 100);
}());