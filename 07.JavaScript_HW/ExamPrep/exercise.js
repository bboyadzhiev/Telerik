function dictonary() {
    var myArray = new Array(),
        myObject = { 'a': 100, 'c': 200 };

    myArray["a"] = 100;
    myArray["c"] = 200;

    for (var el in myArray) {
        console.log(el);
    }
    console.log();

    
    for (var el in myObject) {
        console.log(el);
    }
    var tet = '1, 2, 4, 5';

    var arr = [], arr2 = [];

    arr = tet.split(', ');

    for (var i = 0; i < arr.length; i++) {
        arr2.push(parseInt(arr[i]));
    }

    console.log(arr);
    console.log(arr2);

    function charArrToIntArr(charArr) {
        var intArr = [];

        for (var i = 0; i < charArr.length; i++) {
            intArr.push(parseInt(charArr[i]));
        }
        return intArr;
    }

    function remove(arr, element) {
      
        for (var i = arr.length - 1; i >= 0; i--) {
            if (arr[i] === element) {
                arr.splice(i, 1);
            }
        }
        return arr;
    }

    console.log(remove(arr, '2'));

}

dictonary();