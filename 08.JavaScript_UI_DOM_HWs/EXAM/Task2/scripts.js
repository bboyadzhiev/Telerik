/// <reference path="jquery.min.js" />
$.fn.gallery = function (cols) {
    var columns = (cols || 4);
    $(this).addClass('gallery');
    var $disableDiv = $('<div></div>');
    var $blurDiv = $('<div></div>');
       
    $('.gallery').prepend($disableDiv);
    $('.gallery').prepend($blurDiv);
   
    $('.selected').hide();
   
    var containerWidth = parseInt($('.image-container').css('width'));

   $('.gallery-list').css('width', ((containerWidth + 10) * columns) + 'px');
   
   function setCurrent(currentImage, current) {
       $this = $(current);

       var nextImage = currentImage + 1,
           prevImage = currentImage - 1;

       if (currentImage === 12) {
           nextImage = 1;

       }
       if (currentImage === 1) {
           prevImage = 12;
       }

       $('.selected .current-image img').attr('src', $this.attr('src'))
          .attr('data-info', currentImage);

       $('.selected .previous-image img')
          .attr('src', $('.image-container img[data-info="' + prevImage + '"]').attr('src'))
          .attr('data-info', prevImage);

       $('.selected .next-image img')
           .attr('src', $('.image-container img[data-info="' + nextImage + '"]').attr('src'))
           .attr('data-info', nextImage);
   }

   $('.image-container img').on('click', function () {
       $this = $(this);
       var currentImage = parseInt($this.attr('data-info'));

       setCurrent(currentImage, $this);

       $('.selected').show();

       $disableDiv.addClass('disabled-background');
       $blurDiv.addClass('blurred');
   });

   $('.previous-image img').on('click', function () {
       $this = $(this);
       
       var currentImage = parseInt($this.attr('data-info'));

       setCurrent(currentImage, $this);
   });

   $('.next-image img').on('click', function () {
       $this = $(this);

       var currentImage = parseInt($this.attr('data-info'));
       setCurrent(currentImage, $this);
   });

   $('.current-image img').on('click', function () {
       $('.selected').hide();
       $disableDiv.removeClass('disabled-background');
       $blurDiv.removeClass('blurred');

   });
};