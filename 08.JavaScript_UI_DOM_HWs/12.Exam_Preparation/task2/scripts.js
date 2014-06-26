/// <reference path="jquery.min.js" />
$.fn.tabs = function () {
    var $tabContainer = $(this);
    $tabContainer.addClass('tabs-container');
	hideTabControlContents();
	
	function hideTabControlContents(){
	    $tabContainer.find('.tab-item-content').hide();
	    
	}

	function releaseCurrent() {
	    $('.tab-item.current').removeClass('current');
	}

	$tabs = $('.tab-item');
	$tabs.on('click', function () {
	    hideTabControlContents();
	    releaseCurrent();
	    $(this).addClass('current');
	    $(this).find('.tab-item-content').show();
        $(this)
	    console.log($(this).find('.tab-item-content'));


	})
};