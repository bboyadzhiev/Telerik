$.fn.gallery = function (columns) {
    var $this = $(this);
    numberOfColumns = columns;
    $this.addClass('gallery');
    $this.css("width", numberOfColumns * 260 + "px");
    $galleryList = $this.find(".gallery-list");
    $selectedList = $this.find(".selected");
    $selectedList.hide();

    $galleryList.find('.image-container').on('click', function () {
        var $currentImage = $(this);
        $('.previous-image').remove();
        $('.current-image').remove();
        $('.next-image').remove();
        $selectedList.show();
        $selectedList.addClass('disabled-background');
        $galleryList.addClass('blurred');
        $currentImage.prev().clone().appendTo('.selected').removeClass('image-container').addClass('previous-image');
        $currentImage.clone().appendTo(".selected").removeClass('image-container').addClass('current-image');
        $currentImage.next().clone().appendTo('.selected').removeClass('image-container').addClass('next-image');

        $selectedList.find('.current-image').on('click', function () {
            $selectedList.hide();
            $selectedList.removeClass('disabled-background');
            $galleryList.removeClass('blurred');

        });

        $selectedList.find('.next-image').on('click', function () {
            $this = $(this);
            $this.removeClass('next-image').addClass('current-image');
            $this.prev().remove();
            $this.prev().remove();

        });

        $selectedList.find('.previous-image').on('click', function () {
            $this = $(this);
            $this.removeClass('previous-image').addClass('current-image');
            $this.next().remove();
            $this.next().remove();

        });
       // $selectedList.find('.current-image').css('vertical-align', 'middle');
    });
    
    

    

    
};