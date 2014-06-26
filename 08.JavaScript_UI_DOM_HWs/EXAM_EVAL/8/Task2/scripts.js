$.fn.gallery = function (columns) {
    var imageWidth;

    columns = columns || 4;
    this.addClass('gallery');
    imageWidth = this.find('.image-container').outerWidth(true);
    this.width(columns * imageWidth);
    this.find('.selected').hide();
    this.on('click', '.image-container img', onImageClick);
    this.on('click', '.selected img', onZoomedClick);


    function onImageClick() {
        var $this = $(this);
        var $selectedDiv = $this.closest('.gallery').find('.selected');
        var $currentImage;
        var $prevImage;
        var $nextImage;
        var $zoomedImage = $this.closest('.gallery').find('.zoomed');

        if ($zoomedImage.length) {
            return;
        }

        $this.addClass('zoomed');
        $currentImage = $selectedDiv.show().find('#current-image');
        setImageSource($currentImage, $this.attr('src'));
        $prevImage = $selectedDiv.find('#previous-image');
        setImageSource($prevImage, getPrevImage($this).attr('src'));
        $nextImage = $selectedDiv.find('#next-image');
        setImageSource($nextImage, getNextImage($this).attr('src'));
        // background blur & disable
        $this.closest('.gallery').find('.image-container img').addClass('blurred');
    }

    function onZoomedClick() {
        var $this = $(this);
        var $galery;
        var $zoomedImage;

        if ($this.parent().hasClass('current-image')) {
            $this.closest('.selected').hide();
            $galery = $this.closest('.gallery');
            $galery.find('.zoomed').removeClass('zoomed');
            $galery.find('.image-container img').removeClass('blurred');
        }
        else {
            $zoomedImage = $this.closest('.gallery').find('.zoomed').first();
            $zoomedImage.removeClass('zoomed');
            if ($this.parent().hasClass('previous-image')) {
                getPrevImage($zoomedImage).click();
            }
            else {
                getNextImage($zoomedImage).click();
            }
        }

    }

    function getNextImage(image) {
        if ($(image).parent().next().length) {
            return $(image).parent().next().find('img');
        }
        else {
            return image.closest('.gallery').find('.image-container').first().find('img');
        }
    }

    function getPrevImage(image) {
        if ($(image).parent().prev().length) {
            return $(image).parent().prev().find('img');
        }
        else {
            return image.closest('.gallery').find('.image-container').last().find('img');
        }
    };

    function setImageSource(image, source) {
        image.attr('src', source);
    }
}

