/// <reference path="jquery-2.1.1.js" />
(function () {
  

    var $galleryContainer = $('#galleryDiv'),
        $galleryItems = $('.gallery-item'),
        $prevButton = $('#prevButton'),
        $nextButton = $('#nextButton')[0];

    var timer;
    var SLIDER_INTERVAL = 5000, HOLD_INTERVAL = 6000;
    var currentInterval = SLIDER_INTERVAL;

    $galleryItems.first().addClass('visible');
    //$galleryItems.attr('style', "display: none");

    function hideItem($visibleItem) {
        $visibleItem.removeClass('visible');
      //  $visibleItem.attr('style', "display: none");
    }

    function showNext() {
        var $visibleItem = $('.gallery-item.visible');
        hideItem($visibleItem);
       
        if ($galleryItems.index($visibleItem) == $galleryItems.length - 1) {
            $galleryItems.first()
                .addClass('visible');
              //  .removeAttr('style');
        } else {
            $visibleItem.next().addClass('visible');
          //  $visibleItem.next().removeAttr('style');
        }
    }

    function showPrev() {
        var $visibleItem = $('.gallery-item.visible');
        hideItem($visibleItem);

        if ($galleryItems.index($visibleItem) == 0) {
            $galleryItems.last()
                .addClass('visible');
            //    .removeAttr('style');
        } else {
            $visibleItem.prev().addClass('visible');
          //  $visibleItem.prev().removeAttr('style');
        }
    }

    function holdTimer() {
        console.log('Slide has been holded for ' + HOLD_INTERVAL + ' milliseconds');
        clearInterval(timer);
        currentInterval = HOLD_INTERVAL;
        timer = setInterval(continueSlider, currentInterval);
    }

    function continueSlider() {
        console.log('Slide started!');
        clearInterval(timer);
        currentInterval = SLIDER_INTERVAL;
        timer = setInterval(showNext, currentInterval);
    }


    $(nextButton).on("click", function () {
        holdTimer();
        showNext();
    });
   
    $(prevButton).on("click", function () {
        holdTimer();
        showPrev();
    });
    
    continueSlider();
}());