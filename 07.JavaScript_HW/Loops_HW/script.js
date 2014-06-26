/**
 * 
 */
function print1ToN() {
	var n = parseInt(document.getElementById("int11TB").value),
		el = document.getElementById("result1");
	for (var i = 1; i <= n; i++)
    {
        el.innerHTML+=" " + i;
    }
}

function print1ToNnotDivisibleBy3And7() { // ;-) 
	var n = parseInt(document.getElementById("int21TB").value),
		el = document.getElementById("result2");
	
	for (var i = 1; i <= n; i++)
    {
        if (((i%3) != 0) & ((i%7) != 0))
        {
        	el.innerHTML+=" " + (i);
        }
    }
}

function minAndMaxOfN(){
	var n = parseInt(document.getElementById("int31TB").value),
		minText = document.getElementById("minResultSpan"),
		maxText = document.getElementById("maxResultSpan"),
		sequenceSpan = document.getElementById("sequence"),
		sequenceStr = "Sequence of " + n + " numbers:";
	
	for (var i = 1; i <= n; i++)
    {
        var m = parseFloat(prompt("Enter number: ", 0));
        sequenceStr += " " + (m);
        if (i == 1)        // Initializing max and min 
        {
            max = m;
            min = m;
        }
        if(max<m)          // Defining the maximum number  
        {
            max = m;
        }
        if (min>m)         // Defining the minimum number 
        {
            min = m;
        }
    }
	sequenceSpan.innerHTML = sequenceStr;
	minText.innerHTML = 'Minimal number in sequence is ' + min;
	maxText.innerHTML = 'Maximal number in sequence is ' + max;
}


function findSmallestAndLargest(obj){
	var log = document.getElementById("log"), 
		smallest = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~",
		largest = "";
	
	log.innerHTML += "<h3> " + obj +"</h3><br />";
	
	for (var prop in obj) {
		//log.innerHTML += object[property] + "<br />";
        if (obj[prop] < smallest) {
            smallest = obj[prop];
        }
    }
	
	 for (var prop in obj) {
         if (obj[prop] > largest) {
             largest = obj[prop];
         }
     }
	
	log.innerHTML += "Smallest: '" + smallest + "'" + "<br />";
	log.innerHTML += "Largest: '" + largest + "'" + "<br />";
}

function lex(){
	findSmallestAndLargest(document);
	findSmallestAndLargest(window);
	findSmallestAndLargest(navigator);
}

function lex2(){
	var log = document.getElementById("log"), 
	smallest = "",	
	largest = null; 
	
	var objects = {
			object1: document,
			object2: window,
			object3: navigator
		};

	for (var currentObject in objects){
		log.innerHTML += "<h3> " + objects[currentObject] +"</h3><br />";
		for ( var firstProp in objects[currentObject]) {
			//log.innerHTML += objects[currentObject][firstProp] + "<br />";
			if (smallest > objects[currentObject][firstProp]){
				smallest = objects[currentObject][firstProp];
			}
			if (largest < objects[currentObject][firstProp]){
				largest = objects[currentObject][firstProp];
			}
			
			for (var secondProp in objects[currentObject]){
				
				if (smallest > objects[currentObject][secondProp]) {
					smallest = objects[currentObject][secondProp];   
		        }
		
		        if (largest < objects[currentObject][secondProp]) { 
		            largest = objects[currentObject][secondProp];
		        }
			}
		}
	
	log.innerHTML += "Smallest: '" + smallest + "'" + "<br />";
	log.innerHTML += "Largest: '" + largest + "'" + "<br />";
	}
}