$.fn.gallery = function (columns) {
	var $this = this,
		$parentNode = $this;

	$this.addClass('gallery');

	var imageContainer = $('.gallery .image-container');
	var imageMargin = imageContainer.outerWidth(true) - imageContainer.outerWidth();
	var imageDimensions = $this.find('.image-container img').width() + imageMargin;

	var $currentImage = $parentNode.find('.selected #current-image');
	var $previousImage = $parentNode.find('.selected #previous-image');
	var $nextImage = $parentNode.find('.selected #next-image');
	var lengthOfGallery = $(".image-container img").length;

	if(!columns){
		columns = 4;
	}

	$this.width(imageDimensions * columns);

	$this.find('.selected').hide();

	$this.find('.image-container img')
		.on('click', function (ev) {
			var $this = $(this);
			var imageId = $this.data('info');

			changeImageIndex(imageId);

			$parentNode.find('.image-container').addClass('blurred');
			$parentNode.find('gallery-list').addClass('disabled-background');
		});

		$this.find('.selected .current-image')
		.on('click', function (ev) {
			$parentNode.find('.selected').hide();
			$parentNode.find('.image-container').removeClass('blurred');
		});

		$this.find('.selected .previous-image img')
		.on('click', function (ev) {
			var $this = $(this);
			var imageId = parseInt(($this.attr('src')).substr(5,2));

			changeImageIndex(imageId);
		});

		$this.find('.selected .next-image img')
		.on('click', function (ev) {
			var $this = $(this);
			var imageId = parseInt(($this.attr('src')).substr(5,2));

			changeImageIndex(imageId);
		});

		function changeImageIndex(imageId){
			$currentImage.attr('src', 'imgs/' + imageId + '.jpg');
			
			if ((imageId -  1) < 1){
				$previousImage.attr('src', 'imgs/' + lengthOfGallery + '.jpg');
			}
			else{
				$previousImage.attr('src', 'imgs/' + (imageId - 1) + '.jpg');
			}

			if ((imageId + 1) > lengthOfGallery){
				$nextImage.attr('src', 'imgs/' + 1 + '.jpg');
			}
			else{
				$nextImage.attr('src', 'imgs/' + (imageId + 1) + '.jpg');
			}
			$parentNode.find('.selected').show();
		}
};