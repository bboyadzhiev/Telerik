/// <reference path="jquery.min.js" />
$.fn.gallery = function (columns) {
    var $galery = $("#gallery"),
        $selected = $(".selected"),
        width = $();

    if (typeof columns === "undefined") {
        columns = 4;
    }

    $galery.addClass("gallery");
    $galery.width(columns * 260);
    $selected.hide();
    $selected.addClass("clearfix");

    $("#previous-image").click(selectImage);
    $("#current-image").click(closeGalery);
    $("#next-image").click(selectImage);
    $(".image-container").children("img").click(openGalery);

    function openGalery() {
        var $this = $(this);

        if ($selected.css("display") === "none") {
            changeSelectedImg($this);

            $(".image-container").children().addClass("blurred");
            $selected.show();
            $selected.children().addClass("disabled-background");
        }
    }

    function closeGalery() {
        $selected.children().removeClass("disabled-background");
        //$selected.find("div").removeClass("disabled-background");
        $selected.hide();
        $(".image-container").children().removeClass("blurred").click(openGalery);
    }

    function selectImage() {
        var $this = $(this),
            currentImageSrc = $this.attr("src"),
            $selectedImage;

        $selectedImage = $(".gallery-list img").filter(function () {
            return $(this).attr('src') === currentImageSrc;
        });

        changeSelectedImg($selectedImage);
    }

    function nextImage() {
        var $this = $(this),
            currentImageSrc = $this.attr("src"),
            $selectedImage;

        $selectedImage = $(".gallery-list img").filter(function () {
            return $(this).attr('src') === currentImageSrc;
        });

        changeSelectedImg($selectedImage);
    }

    function changeSelectedImg($selectedImg) {
        var previousImageSrc = $selectedImg.parent().prev().children("img").attr("src"),
            currentImageSrc = $selectedImg.attr("src"),
            nextImageSrc = $selectedImg.parent().next().children("img").attr("src");

        if (typeof previousImageSrc === "undefined") {
            previousImageSrc = currentImageSrc;
        }
        if (typeof nextImageSrc === "undefined") {
            nextImageSrc = currentImageSrc;
        }

        $("#previous-image").attr("src", previousImageSrc);
        $("#current-image").attr("src", currentImageSrc);
        $("#next-image").attr("src", nextImageSrc);
    }
};