/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="libs/require.js" />
(function () {
	require.config({
		paths: {
		    "jquery": "libs/jquery-2.0.3",
            "custom": "libs/custom"
		}
	});

	require(["jquery", "custom"], function ($, C) {
		$("html").append("module loaded");
	});

	

}());