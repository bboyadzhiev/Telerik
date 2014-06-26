//(function () { 
    
  
    function changeFontColor() {
        var color = document.getElementById('fontColorBox').value;
        var text = document.getElementById("text");
        text.style.color = color;
    }

    function changeBackgroundColor() {
        var color = document.getElementById('bgColorBox').value;
        var text = document.getElementById("text");
        text.style.backgroundColor = color;
    }
//}());