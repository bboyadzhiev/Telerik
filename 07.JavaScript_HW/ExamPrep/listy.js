function Solve(args) {
    
    String.prototype.killWhiteSpace = function() {
        return this.replace(/\s/g, '');
    };

    String.prototype.reduceWhiteSpace = function() {
        return this.replace(/\s+/g, ' ');
    };

    var definitions = [];

    for (var i = 0; i < args.length; i++) {
        var currentDefinition = '',
            currentChar = '',
            currentExpression = '',
            currentOperation = '';
       
        if (args[i].toString().substr(0, 3) === 'def') {
            currentDefinition = args[i].toString().substr(4);
            var foundFunc = false;

            var defName = '';
            defName = currentDefinition.split(' ')[0];

            if (currentDefinition.indexOf("sum") >0 ) {
                foundFunc = true;
                currentExpression = currentDefinition.substr(currentDefinition.indexOf("sum") + 3);
                currentOperation = 'sum';
            }
            if (currentDefinition.indexOf("min") > 0) {
                foundFunc = true;
                currentExpression = currentDefinition.substr(currentDefinition.indexOf("min") + 3);
                currentOperation = 'min';
            }
            if (currentDefinition.indexOf("max") > 0) {
                foundFunc = true;
                currentExpression = currentDefinition.substr(currentDefinition.indexOf("max") + 3);
                currentOperation = 'max';
            }
            if (currentDefinition.indexOf("avg") > 0) {
                foundFunc = true;
                currentExpression = currentDefinition.substr(currentDefinition.indexOf("avg") + 3);
                currentOperation = 'avg';
            }
            if (!foundFunc) {
                currentExpression = currentDefinition.substr(currentDefinition.indexOf('['));
            }
      
            definitions.push([defName, currentOperation, currentExpression]);
        }

        for (var c = 0; c < args[i].length; c++) {
            currentChar = args[i][c];
            if (currentChar == ' ') {
                continue;
            }
            switch (currentChar) {
                default:

            }
            
        }
    }

    console.log(definitions);
    function calculate() {
        for (var def in definitions) {
            //if 
        }


    }

}

var zeroTestArr =  ['def func sum[5, 3, 7, 2, 6, 3]',
                        'def func2 [5, 3, 7, 2, 6, 3]',
                        'def func3 min[func2]',
                        'def func4 max[5, 3, 7, 2, 6, 3]',
                        'def func5 avg[5, 3, 7, 2, 6, 3]',
                        'def func6 sum[func2, func3, func4 ]',
                        'sum[func6, func4]'];

Solve(zeroTestArr);