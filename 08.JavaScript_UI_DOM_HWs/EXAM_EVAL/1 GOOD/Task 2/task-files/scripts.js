$.fn.gallery = function (columnsPerRow) {
    var galleryContainerWidth=columnsPerRow*260,
        galleryContainer=$('#gallery').addClass('gallery').css('width',galleryContainerWidth+'px'),
        galleryList=galleryContainer.find('.gallery-list'),
        selectionContainer=$('.selected').hide(),
        allImages=$('.image-container img').click(processClickOnImageTile),
        lastImageIndex=allImages.length-1;

    function processClickOnImageTile(){
        var img=$(this);

        if (!galleryList.hasClass('blurred')){
            galleryList.addClass('blurred');

            showSelectedImage($(img));
        }
    }

    function showSelectedImage(img){
        var previousImage=selectionContainer.find('.previous-image img'),
            currentImage=selectionContainer.find('.current-image img'),
            nextImage=selectionContainer.find('.next-image img');

        setEnlargedImages(img);

        selectionContainer.show();

        currentImage.click(processClickOnEnlargedImage);

        previousImage.click(processSideEnlargedImageClick);

        nextImage.click(processSideEnlargedImageClick);

        function setEnlargedImages(selectedImage){
            var currentImageIndex=selectedImage.attr('data-info');

            previousImage.attr('src','');
            currentImage.attr('src','');
            nextImage.attr('src','');

            if (currentImageIndex==1)
            {
                var previousImageSource=$(allImages[lastImageIndex]).attr('src');
                previousImage.attr('src',previousImageSource);

                setCurrentImage();
                setNextImage();
            }
            else if (currentImageIndex==lastImageIndex+1)
            {
                setPreviousImage();
                setCurrentImage();

                var nextImageSource=$(allImages[0]).attr('src');
                nextImage.attr('src',nextImageSource);
            }
            else
            {
                setPreviousImage();
                setCurrentImage();
                setNextImage();
            }

            function setPreviousImage(){
                var previousImageDiv=selectedImage.parent().prev();
                var previousImageSource=previousImageDiv.children().eq(0).attr('src');
                previousImage.attr('src',previousImageSource);
            }

            function setCurrentImage(){
                var currentImageSource=selectedImage.attr('src');
                currentImage.attr('src',currentImageSource);
            }

            function setNextImage(){
                var nextImageDiv=selectedImage.parent().next();
                var nextImageSource=nextImageDiv.children().eq(0).attr('src');
                nextImage.attr('src',nextImageSource);
            }
        }

        function processClickOnEnlargedImage(){
            galleryList.removeClass('blurred');
            selectionContainer.hide();
        }

        function processSideEnlargedImageClick(){
            var thisImageSrc=$(this).attr('src');

            var correspondingTile=$(allImages.filter('[src="'+thisImageSrc+'"]'));

            setEnlargedImages(correspondingTile);
        }
    }
};