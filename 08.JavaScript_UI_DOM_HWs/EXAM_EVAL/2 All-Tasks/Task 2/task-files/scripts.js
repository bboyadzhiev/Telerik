$.fn.gallery = function (cols) {
    var $this = $(this);
    var selector = $this.selector;
    var numberOfCols = cols; 
    $(selector).addClass('gallery');

    var imgContainerWidth = $(selector).find('.image-container').outerWidth(true);
    var containerWidth = numberOfCols * imgContainerWidth;
    var imageCount = $(selector).find('.gallery-list > .image-container').length;
    var firstImageData = $($(selector).find('.gallery-list img')[0]).attr('src');
    var lastImageData = $($(selector).find('.gallery-list img')[imageCount - 1]).attr('src');

    $(selector).css('width', containerWidth);

    $(selector).find('.selected').hide();

    function setPreviousImage(imageId) {
    	if (imageId == 1) {
    		$('#previous-image').attr('src', lastImageData);
    	} else {
    		$('#previous-image').attr('src', $($(selector).find('.gallery-list img')[imageId - 2]).attr('src'));
    	}
    }

    function setNextImage(imageId) {
    	if (imageId == imageCount) {
    		$('#next-image').attr('src', firstImageData);
    	} else {
    		$('#next-image').attr('src', $($(selector).find('.gallery-list img')[imageId]).attr('src'));
    	}
    }

    $(selector).find('.image-container > img').on('click', imgClick);
    function imgClick(e) {
    	if ($(selector).find('.gallery-list').hasClass('disabled-background')) {
    		return;
    	}
    	var imageId = $(this).attr('data-info');
    	var imageData = $(this).attr('src');

    	setPreviousImage(imageId);
    	setNextImage(imageId);

    	$('#current-image').attr('src', imageData);
    	$('#current-image').attr('data-info', imageId);

    	$(selector).find('.selected').show();
    	$(selector).find('.gallery-list').addClass('blurred disabled-background');
    }

    $('#current-image').on('click', currentImageClick);
    function currentImageClick(e) {
    	$(selector).find('.selected').hide();
    	$(selector).find('.gallery-list').removeClass('blurred disabled-background');
    }

    $('#previous-image').on('click', {action: 'prev'}, prevNextImageClick);
    $('#next-image').on('click', {action: 'next'}, prevNextImageClick);
    function prevNextImageClick(e) {
    	var action = e.data.action;
    	var mainImageId = $('#current-image').attr('data-info');

    	if (action == 'prev') {
    		mainImageId--;
    	} else {
    		mainImageId++;
    	}
    	if (mainImageId < 1) {
    		mainImageId = imageCount;
    	} else if (mainImageId > imageCount) {
    		mainImageId = 1;
    	}
    	
    	$('#current-image').attr('data-info', mainImageId);
    	$('#current-image').attr('src', $(this).attr('src'));
    	setPreviousImage(mainImageId);
    	setNextImage(mainImageId);
    }
};