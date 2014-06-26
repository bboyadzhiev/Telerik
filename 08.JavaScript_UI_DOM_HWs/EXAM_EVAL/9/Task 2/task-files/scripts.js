/*global jQuery, $*/
$.fn.gallery = function (col) {
    'use strict';

    var $gallery = this,
        images = $gallery.find('.image-container'),
        $selected = $gallery.find('.selected'),
        $galleryList = $gallery.find('.gallery-list'),
        selectedDomImg,
        width,
        selected = false;




    if (col !== undefined && col !== null) {
        width = (col+0.2) * 250;
    } else {
        width = 4.2 * 250;
    }

    $galleryList.css('width', width + 'px');
    console.log(width + 'px');
    $selected.hide();

    $gallery.addClass('gallery');
    $gallery.addClass('clearfix');

    //console.log(gallery);

    function isSelected() {
        var selectedItems = $gallery.find('.selected');
        if (selectedItems) {
            return true;
        }
        return false;
    }

    function blurGallery() {
        if (isSelected()) {
            $gallery.find('.gallery-list').addClass('blurred');
            $gallery.find('.gallery-list').addClass('disabled-background');
        }
    }

    function changeImgUrl(sel, next, prev) {
        var $alreadyCurrentImg = $gallery.find('.current-image'),
            $alreadyNextImg = $gallery.find('.next-image'),
            $alreadyPrevImg = $gallery.find('.previous-image');

        $alreadyCurrentImg.find('img').attr({src: sel});
        $alreadyNextImg.find('img').attr({src: next});
        $alreadyPrevImg.find('img').attr({src: prev});
    }

    images.on('click', function () {
        var $currentImage = $(this),
            newSelectedUrl = $currentImage.find('img').attr('src'),
            newNextUrl = $currentImage.next().find('img').attr('src'),
            newPrevUrl = $currentImage.prev().find('img').attr('src');
        selectedDomImg = $(this);
        changeImgUrl(newSelectedUrl, newNextUrl, newPrevUrl);
        $selected.show();
        blurGallery();
        selected = true;
    });

    var selectedImage = $gallery.find('.current-image');

    selectedImage.on('click', function () {

        if (selected) {
            $selected.hide();
            $gallery.find('.gallery-list').removeClass('blurred');
            $gallery.find('.gallery-list').removeClass('disabled-background');
        }
    });

    var nextImage = $gallery.find('.next-image'),
        prevImage = $gallery.find('.previous-image');

    nextImage.on('click', function () {

        var galleryList = $gallery.find('.gallery-list');
        var currentClickedImg = selectedDomImg.next();
        selectedDomImg = selectedDomImg.next();
        selectedDomImg.trigger('click');

       // if (currentClickedImg === galleryList.last()) {
       //     alert('true');
       // }

    });



    prevImage.on('click', function () {
        selectedDomImg = selectedDomImg.prev();
        selectedDomImg.trigger('click');
    });



};