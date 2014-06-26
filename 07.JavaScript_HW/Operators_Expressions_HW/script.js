/**
 * 
 */
function isEven(n) {
   return (n % 2 == 0);
};

function evenOrOdd() {
	var val = document.getElementById("inputValue1").value;
	if (val == parseInt(val)){
		isEven(val) && (val % 2 == 0) ? alert(val + " is an even number") : alert(val + " is an odd number"); 
	}
	else {
		alert(val + " is not an integer number!");
	}
};

function divisibleBy5And7(){
	var val = document.getElementById("inputValue2").value;
	if (val == parseInt(val)){
		val % 5 == 0 && val % 7 == 0 ? alert(val + " can be divided (without reminder) by 5 & 7") : alert(val + " can't be divided (without reminder) by 5 & 7"); 
	}
	else {
		alert(val + " is not an integer number!");
	}
};

function calculateArea(){
	var width = document.getElementById("widthValue").value,
		height = document.getElementById("heightValue").value;
		width >= 0 && height >= 0 ? alert("Rectangle's area is " + width*height) : alert("Incorrect value entered!");
}

function check3rdDigitRtL(){
	var val = document.getElementById("threeDigitValue").value;
	if (val == parseInt(val)){
		(val % 100 != 0) && ((parseInt(val/100) - 7) % 10 == 0) ? alert("true") : alert("false"); 
	}
	else {
		alert(val + " is not an integer number!");
	}
}

function withinCirlceTest(){
	var xCoord = document.getElementById("xCoordTB").value,
		yCoord = document.getElementById("yCoordTB").value;
	if (xCoord == parseFloat(xCoord) && yCoord == parseFloat(yCoord)){
	var isWithin = (xCoord * xCoord + yCoord * yCoord) <= 5 * 5;
	
	alert( "The Point" + ( isWithin ? " is ":" in NOT ") + "within the circle K(O, 5)");
	}
	else {
		alert("Bad input!");
	}
}


function isPrimeNumber(){
	var i = document.getElementById("primeTB").value;
	if (i == parseInt(i) && i>=0){
		var notPrime = !(i == 1 || i == 2 || i == 3 || i == 5 || i == 7) && ( i % 2 == 0 || i % 3 == 0 || i % 5 == 0 || i % 7 == 0);
		alert("The integer number " + ( notPrime ? " is NOT ":" is ") + "prime!" );
	}
	else {
		alert(i + " is not a positive integer number!");
	}
}

function getTrapezoidArea(){
	var base1 = document.getElementById("base1TB").value,
		base2 = document.getElementById("base2TB").value,
		height = document.getElementById("heightTB").value;
	
	var trapezoidArea = (base1 / 2 + base2 / 2) * height;
	
	alert("The trapezoid's area is : " + trapezoidArea);
}

function withinCirlceOutsideRectangleTest(){
	var xCoord = document.getElementById("xCoord2TB").value,
		yCoord = document.getElementById("yCoord2TB").value,
		circleXCoord = 1,
		circleYCoord = 1,
	    circleRadius = 3,
	    rectTop = 1,
	    rectLeft = -1,
	    rectWidth = 6,
	    rectHeight = 2;
	
	if (xCoord == parseFloat(xCoord) && yCoord == parseFloat(yCoord)){
	var isWithin = 
		((xCoord < rectLeft) || (xCoord > (rectWidth - rectLeft)) || (yCoord > rectTop) || (yCoord < (rectTop - rectHeight)))
		&& // Using Pythagoras method for the circle
		(((xCoord - circleXCoord) * (xCoord - circleXCoord) + (yCoord - circleYCoord) * (yCoord - circleYCoord)) <= (circleRadius * circleRadius));
	
	alert( "The Point" + ( isWithin ? " is ":" in NOT ") + "within (K((1,1), 3) U R((1,-1), 6 , 2)");
	}
	else {
		alert("Bad input!");
	}
}


