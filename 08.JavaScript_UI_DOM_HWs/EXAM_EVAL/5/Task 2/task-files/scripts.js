$.fn.gallery = function (columns) {
  var $thisGallery = $(this);
  $parentNode = $thisGallery;

  console.log($thisGallery );

  //$this.addClass('image-container');
	$thisGallery.find('.image-container img')
		.on('click', function (ev) {
			var src = $(this).attr('src');
			console.log("booo" + src);
			console.log($thisGallery.find('.selected').find('.current-image').attr('src'))  

	});
};