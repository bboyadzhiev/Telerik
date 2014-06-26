/**
 *1. Assign all the possible JavaScript literals to different variables.
 */


var variables = {
	integer : 4,
	float : 45.6,
	float2 : 4.56e1,
	string : "John Doe",
	boolean : true,
	undef : undefined,
	nulled : null
};
	
var quotedVariable = "\"How you doin'?\" Joey said.";

function printVariables(){
	for ( var variable in variables) {
		document.writeln( variable + " = " + variables[variable]);
		document.writeln("<br />");
	}
}

function quotedVar() {
	document.writeln("quotedVar = " + quotedVariable);
}

function typeOfLiterals(){
	for ( var variable in variables) {
		document.writeln("\"" + variable + "\" is of type " + typeof(variables[variable]));
		document.writeln("<br />");
	}
	document.writeln("\"variables\" is of type " + typeof(variables));
}

