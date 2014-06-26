/**
 * 
 */
// 1. Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.
function swapIntegers() {
	var int1 = parseInt(document.getElementById("int1TB").value), 
		int2 = parseInt(document.getElementById("int2TB").value);

	if (int1 > int2) {
		int2 = int2 - int1;
		int1 = int1 + int2;
		int2 = int1 - int2;
		alert("After comparison, the second integer holds the bigger value: " + int2);
	} else {
		alert("Condition not met!");
	}
}

// 2. Write a script that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.
function calculateProduct() {
	var real1 = parseFloat(document.getElementById("real21TB").value),
		real2 = parseFloat(document.getElementById("real22TB").value), 
		real3 = parseFloat(document.getElementById("real23TB").value);

	var positive = true; // using bool to hold the sign
	if (real1 < 0) {
		positive = !positive; // invert the sign
	}
	if (real2 < 0) {
		positive = !positive; // invert the sign
	}
	if (real3 < 0) {
		positive = !positive; // invert the sign
	}
	alert("Product is " + (positive ? "positive!" : "negative!"));
}

// 3. Write a script that finds the biggest of three integers using nested if statements.
function biggestOf3Ints() {
	var int1 = parseInt(document.getElementById("int31TB").value), 
		int2 = parseInt(document.getElementById("int32TB").value), 
		int3 = parseInt(document.getElementById("int33TB").value);

	if (int1 > int2) {
		if (int1 > int3) {
			alert("The first integer is the biggest: " + int1);
		} else {
			if (int1 == int3) {
				alert("The first and third integers are the biggest & are equal: " + int1 +" and " + int3);
			}
		}
	} else {
		if (int2 > int1) {
			if (int2 > int3) {
				alert("The second integer is the biggest: " + int2);
			} else {
				if (int2 == int3) {
					alert("The second and third integers are the biggest & are equal: " + int2 +" and " + int3);
				} else {
					alert("The third integer is the biggest: " + int3);
				}
			}
		} else {
			if (int1 == int3) {
				alert("All the integers are equal !!!");
			} else {
				if (int3 > int1) {
					alert("The third integer is the biggest: " + int3);
				} else {
					alert("The first two integers are the biggest & are equal :  " + int1 +" and " + int2);
				}
			}
		}
	}
}

// 4. Sort 3 real values in descending order using nested if statements.
function sort3Reals() {
	var real1 = parseFloat(document.getElementById("real41TB").value),
		real2 = parseFloat(document.getElementById("real42TB").value), 
		real3 = parseFloat(document.getElementById("real43TB").value);

	if (real1 > real2) {
        if (real1 > real3) {
        	alert("1. first  " + real1);
            if (real2>real3)  {
            	alert("2. second " + real2);
            	alert("3. third  " + real3);
            } else {
            	alert("2. third  " + real3);
            	alert("3. second " + real2);
            }
        } else {
        	alert("1. third  " + real3);
        	alert("2. first  " + real1);
        	alert("3. second " + real2);
        }
    } else {// real2 > real1
        if (real2 > real3) {
        	alert("1. second " + real2);
            if (real1>real3) {
            	alert("2. first  " + real1);
            	alert("3. third  " + real3);
            } else {
            	alert("2. third  " + real3);
            	alert("3. first  " + real1);
            }
        } else {
        	alert("1. third  " + real3);
        	alert("2. second " + real2);
        	alert("3. first  " + real1);
        }
    }
}

function toEnglishString(){
	var int = parseInt(document.getElementById("int51TB").value),
		a = "";
	
	switch (int.toString())
    {
        case '0': a = "Zero"; break;
        case '1': a = "One"; break;
        case '2': a = "Two"; break;
        case '3': a = "Three"; break;
        case '4': a = "Four"; break;
        case '5': a = "Five"; break;
        case '6': a = "Six"; break;
        case '7': a = "Seven"; break;
        case '8': a = "Eight"; break;
        case '9': a = "Nine"; break;
        default: a="Not a single digit!";  break;
    }
	alert(a);
}

function quadraticEquation(){
	var paramA = parseFloat(document.getElementById("paramATB").value),
		paramB = parseFloat(document.getElementById("paramBTB").value), 
		paramC = parseFloat(document.getElementById("paramCTB").value),
		discriminant = paramB * paramB - 4 * paramA * paramC,
		root1 = 0;
	
	 if (discriminant >= 0) {                                                     
         if (discriminant == 0) {    
        	 if (paramB != 0) {
        		 root1 = ((-paramB) / (2 * paramA));
        		 alert("There is only one real root: x=" + root1);
        	 } else {
        		 alert("This is not an equation!");
        	 }
             
         } else {        	 
             root1 = (-paramB + Math.sqrt(discriminant)) / (2 * paramA);
             var root2 = (-paramB - Math.sqrt(discriminant)) / (2 * paramA);
             alert("There are two real roots: x1="+ root1 + " and x2=" + root2);
         }
     } else {
    	 alert("There are no real roots!");
     }
}

function greatestOfFive(){
	var reals = {
		real1 : parseFloat(document.getElementById("real71TB").value),
		real2 : parseFloat(document.getElementById("real72TB").value), 
		real3 : parseFloat(document.getElementById("real73TB").value),
		real4 : parseFloat(document.getElementById("real74TB").value), 
		real5 : parseFloat(document.getElementById("real75TB").value)
	};
	var greatest = reals.real1;
	
	for ( var index in reals) {
		if(greatest < reals[index]){
			greatest = reals[index];
		}
	}
	alert("Greatest real is " + greatest);
}

function threeDigitNumToString(){
	var i = parseInt(document.getElementById("int81TB").value),
	str = "";
	
	// Hundreds  h = (i/100);
    // Tens t = ((i/10)%10);
    // Ones = (i%10);
    if (i < 0) 
    {
        i = i * (-1);
        str = str + "minus "; 
    }
    var h = parseInt(i / 100);
    if (h > 0)
    {
        switch (h)
        {
            case 1: str = str+"one"; break;
            case 2: str = str+"two"; break;
            case 3: str = str+"three"; break;
            case 4: str = str+"four"; break;
            case 5: str = str+"five"; break;
            case 6: str = str+"six"; break;
            case 7: str = str+"seven"; break;
            case 8: str = str+"eight"; break;
            case 9: str = str+"nine"; break;
            default:
                break;
        }
        str = str + " hundred";
    }

    var t = parseInt((i / 10) % 10);
    // Determing the TENS
    if (t >= 2 ) // Checking for 20+
    {
        if (i > 100)
        {
            str = str + " and "; // If there are hundreds
        }
        switch (t)
        {
            case 1: str = str+"ten"; break;
            case 2: str = str+"twenty"; break;
            case 3: str = str+"thirty"; break;
            case 4: str = str+"forty"; break;
            case 5: str = str+"fifty"; break;
            case 6: str = str+"sixty"; break;
            case 7: str = str+"seventy"; break;
            case 8: str = str+"eighty"; break;
            case 9: str = str+"ninety"; break;
            default:
                break;
        }
        str = str + " ";

    }
    else        // Checking for TEENs :)
    {
        if (t > 0) 
        {
            if (h > 0)
            {
                str = str + " and ";
            }
            switch (i % 10)
            {
                case 0: str = str + "ten"; break;
                case 1: str = str+"eleven"; break;
                case 2: str = str+"twelve"; break;
                case 3: str = str+"thirteen"; break;
                case 4: str = str+"fourteen"; break;
                case 5: str = str+"fifteen"; break;
                case 6: str = str+"sixteen"; break;
                case 7: str = str+"seventeen"; break;
                case 8: str = str+"eighteen"; break;
                case 9: str = str+"nineteen"; break;
                default:
                    break;
            } 
        }
    }
    // Determins the ONES word
    if (((i % 10 > 0) || (i==0)) && ((((i / 10) % 10) >= 2) || (((i / 10) % 10) == 0)))
    {
        if ((((i / 10) % 10) == 0) && (i>100))
        {
            str = str + " and ";  
        }
        switch (i % 10)
        {
            case 0: str = str+"zero"; break;
            case 1: str = str+"one"; break;
            case 2: str = str+"two"; break;
            case 3: str = str+"three"; break;
            case 4: str = str+"four"; break;
            case 5: str = str+"five"; break;
            case 6: str = str+"six"; break;
            case 7: str = str+"seven"; break;
            case 8: str = str+"eight"; break;
            case 9: str = str+"nine"; break;
            default:
                break;
        }
    }
    
    var final = str.substring(0, 1).toUpperCase() + str.substring(1)+".";
   
    alert(final);
}
