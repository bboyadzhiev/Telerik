$.fn.gallery = function (columns) {
    if (columns == null) {
        columns = 4;
    }

    columns = parseInt(columns);

    var $Gallery = $(this);
    $Gallery.addClass('gallery');

    $Gallery.css("width", ((columns * 250) + columns * 10) + 'px');
    var $imagesItems = $Gallery.find('.image-container>img');

    $Gallery.on('click', '.image-container>img', function (ev) {
        //$Gallery.addClass('disabled-background');

        var $clickedElement = $(this);

       // $clickedElement.addClass('selected');
        var $currentImage = $Gallery.find('img#current-image');
        var currentImageScr = $clickedElement.attr('src');
        $currentImage.attr('src', currentImageScr);

        var $nextImage = $Gallery.find('img#next-image');
        var $clickedElementParent = $clickedElement.parent();
        var nextImageScr;

        if ($clickedElementParent.is(':last-child')) {
            nextImageScr = $('.image-container').children('img').attr('src');
        }
        else {
            nextImageScr = $clickedElement.parent().next('.image-container').children('img').attr('src');
        }
        $nextImage.attr('src', nextImageScr);


        var $prevImage = $Gallery.find('img#previous-image');
        var prevImageScr;
        if ($clickedElementParent.is(':first-child')) {
            prevImageScr = $('.image-container:last').children('img').attr('src');
            console.log("first" + prevImageScr);
        }
        else {
            prevImageScr = $clickedElement.parent().prev('.image-container').children('img').attr('src');
            console.log("else" + prevImageScr);
        }
 
        $prevImage.attr('src', prevImageScr);

        var $imagesItems = $Gallery.find('.image-container');
        for (var i = 0; i < $imagesItems.length; i++) {
            var $currentImageContainer = $($imagesItems[i]);
            $currentImageContainer.addClass('blurred');
        }
        //$Gallery.addClass('disabled-background');
    });
};