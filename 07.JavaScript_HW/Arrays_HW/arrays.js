/**
 * 
 */

function enterArray(array) {
	for (var index = 0; index < array.length; index++) {
		array[index] = parseFloat(prompt('Enter element ' + index + ':', 0));
	}
}

function printArray(array){
	var res = "{" + array[0];
	for (var i = 1; i < array.length; i++)
	{
		res += ", " + array[i];
	}
	res += "}";
	return res;
}

function charArrToIntArr(charArr) {
    var intArr = [];

    for (var i = 0; i < charArr.length; i++) {
        intArr.push(parseInt(charArr[i]));
    }
    return intArr;
}


function arraysTask1(){
	var array = new Array(20),
		out = document.getElementById("task1Out");
	
	for (var int = 0; int < array.length; int++) {
		array[int] = 5 * int;
		out.innerHTML += array[int] + ' ';
		console.log(array[int]);
	}
}


function lexCompareArrays(array1, array2){
	
	var min = Math.min(array1.length,array2.length); // Getting the size of the smaller array.

    var found = false; 
    
    // Checking for the first condition - char by char comparison
    for (var  i = 0; i < min; i++)
    {
        if (array1[i] < array2[i])
        {
            found = true; 
            return r = "The first array is lexicographically first by direct char comparison!";
            break;
        }
        else
        {
            if (array1[i] > array2[i]) // If a corresponding char in array2 is "before" the one in array1
            {
                found = true; 
                return r = "The second array is lexicographically first by direct char comparison!";
                break; // and break, as we don't need to check any further
            }
        }
    }
    
    // If not found by the first condition, then checking for smaller size or equality of the arrays
    if (!found) 
    {
        if (array1.length>array2.length)
        {
        	return r = "The second array is lexicographically first by size!";
        }
        else
        {
            if (array1.length<array2.length)
            {
            	return r = "The first array is lexicographically first by size!";
            }
            else
            {
            	return r = "The arrays are lexicographically equal!";
            }
        }
    }
}

function task2(){
	var string1 = document.getElementById("string21TB").value,
	string2 = document.getElementById("string22TB").value,
	out = document.getElementById("task2Out");
	
	out.innerHTML = lexCompareArrays(string1, string2);
}



function task3(){
	var array = new Array(parseInt(document.getElementById("task3ArraySizeTB").value)),
		out = document.getElementById("task3Out");
	
	enterArray(array);
	
	out.innerHTML = maxSequenceOfEqual(array);
}

function maxSequenceOfEqual(array){
	var testElement = array[0],
    	testSequence = 0,
    	maxSequence = 0,
    	element = 0;
	
    for (var i = 0; i < array.length; i++)
    {
            if (array[i] == testElement)
            {
                testSequence++;
            }
            else
            {
                testSequence = 1;
                testElement = array[i]; 
            }
            if (maxSequence < testSequence)
            {
                maxSequence = testSequence;
                element = testElement;
            }
    }
   	
    var res = "The array is " +printArray(array)+"<br />";
    
    res += "The maximal sequence of equal elements is {" + element;
    
    for (var i = 1; i < maxSequence; i++)
    {
        res += ", "+element;
    }
    
    res += "}";
    
    return res;
}



function task4(){
	var array = new Array(parseInt(document.getElementById("task4ArraySizeTB").value)),
		out = document.getElementById("task4Out");
	
	enterArray(array);
	
	out.innerHTML = maxIncreasingSequence(array);
}

function maxIncreasingSequence(array){
	var testElement = array[0],
    	testSequence = [], //array
    	maxSequence = [], // array
    	testSequenceCount = 0,
    	maxSequenceCount = 0,
    	res = "";
	
	testSequence.push(testElement);
	
	for (var i = 0; i < array.length; i++)
    {
        if (array[i] > testElement)
        {
            testSequenceCount++;
            testElement = array[i];
            testSequence.push(testElement);
        }
        else
        {
            testSequenceCount = 1;
            testElement = array[i];
            testSequence = [];
            testSequence.push(testElement);
        }
        
        if (maxSequenceCount < testSequenceCount)
        {
            maxSequenceCount = testSequenceCount;
            maxSequence = [];
            for (var elem in testSequence)
            {
                maxSequence.push(testSequence[elem]);
              //  res += " "+ elem;
            }
            //res += " ";
        }        
    }
	
	res = "The array is " +printArray(array)+"<br />";
  
	res += "The maximal sequence of encreasing elements is {" + maxSequence[0];
	for (var i = 1; i < maxSequence.length; i++)
	{
		res += ", " + maxSequence[i] ;
	}
	res += "}";

	return res;
}


function task5(){
	var array = new Array(parseInt(document.getElementById("task5ArraySizeTB").value)),
	out = document.getElementById("task5Out");

	enterArray(array);
	
	out.innerHTML = selectionSort(array);
}

function selectionSort(array){
	
var minIndex,
 	temp,
 	n = array.length;

	for (var i = 0; i < n - 1; i++)
	{
		minIndex = i;
		for (var j = i + 1; j < n; j++)
		{
			 if (array[j] < array[minIndex])
			 {
			     minIndex = j;
			 }
			 if (minIndex != i)
			 {
			     temp = array[minIndex];
			     array[minIndex] = array[i];
			     array[i] = temp;
			 }
	     }
	 }
	
	var res = "The sorted array is " +printArray(array)+"<br />";
	return res;
}

function task6(){
	var array = new Array(parseInt(document.getElementById("task6ArraySizeTB").value)),
	out = document.getElementById("task6Out");

	enterArray(array);
	
	out.innerHTML = mostFrequent(array);
}

function mostFrequent(array){
	var numbers = [],
		count = [],
		found = false;
	
	numbers.push(array[0]);
	count.push(0);
	
	for (var i = 0; i < array.length; i++)
    {
        for (var j = 0; j < numbers.length; j++)
        {
            if (numbers[j]==array[i])
            {
                found = true;
                count[j]++;
                break;
            }
            else
            {
                found = false;
            }
        }
        
        if (!found)
        {
            numbers.push(array[i]);
            count.push(1);
        }
    }
	
	var element = numbers[0],
		times = count[0];
	
    for (var i = 0; i < numbers.length; i++)
    {
        if (times<count[i])
        {
            element = numbers[i];
            times = count[i];
        }
    }
    
    var res = "The array is " + printArray(array) + "<br />";
    res += "The most common element is "+element+ " (found " + times + " times) in the array";
    
    return res;
}

function task7(){
	var array = new Array(parseInt(document.getElementById("task7ArraySizeTB").value)),
		target = parseInt(document.getElementById("task7TargetTB").value),
		out = document.getElementById("task7Out");

	enterPresortedArray(array);
	
	out.innerHTML = printArray(array) + "<br />";
	
	out.innerHTML += binarySearch(array, target);
}

function enterPresortedArray(array){
	var inputNumber = 0, lastNumber = 0;
	for (var index = 0; index < array.length; index++) {
		if (index == 0) 
		{
			inputNumber = parseFloat(prompt('Enter element ' + index + ':', 0));
			lastNumber = inputNumber;
		}
		else 
		{
			inputNumber = parseFloat(prompt("Enter the next integer >= " + lastNumber + ":", 0));
		}
		
		if (inputNumber >= lastNumber)
        {
         array[index]= inputNumber;
         lastNumber = inputNumber;  
        }
        else
        {
            alert("Bag integer! Array should be pre-sorted!");
            return 0;
        }
	}
}


function binarySearch(array, target){
	var max = array.length - 1,
     	min = 0,
     	position=-1;
	while (max >= min)
	{
		// calculate the midpoint for roughly equal partition
		var  middle = parseInt(((max - min) / 2) + min);
		
		if (array[middle] == target)
		{
			position = middle;	// key found at index middle
			break;
		}

		else	// determine which subarray to search
		{
			if (array[middle] < target)
			{
				min = middle + 1; // change min index to search upper subarray
			}
			else
			{
				max = middle - 1;	// change max index to search lower subarray
			}
		}
	}
	
	var res = "";
	
    if (position == -1) // key was not found
    {
        res = "Elment "+ target + " not found in the array!";
    }
    else
    {
    	res = "Element "+ target + ", found at position " + position;
    }
    
    return res;
}

