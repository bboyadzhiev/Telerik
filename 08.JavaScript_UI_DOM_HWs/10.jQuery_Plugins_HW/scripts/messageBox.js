/// <reference path="jquery-2.1.1.js" />
(function ($) {
    $.fn.messageBox = function () {
        $this = $(this);
        $this.hide();
        $this.css('border', '1px solid black');
        $this.css('opacity', 0);
        return $this;

    }

    $.fn.success = function (message) {
        $this = $(this);
        $this.text(message);
        fadeInMessage($this);
        holdMessage($this);
    }

    $.fn.error = function (message) {
        $this = $(this);
        $this.text(message);
        $this.css('background', '#ffdddd');
        fadeInMessage($this);
        holdMessage($this);
    }


    function fadeInMessage(msg) {
        $msg = $(msg);
        $msg.show();
        var interval = setInterval(function () {
            var opacity = parseFloat( $msg.css('opacity'));
            if (opacity < 1) {
                $msg.css('opacity', opacity + 0.1);
            } else {
                clearInterval(interval);
            }
            
        }, 100);
    }
    
    function holdMessage(msg) {
        $msg = $(msg);
        setTimeout(function () {
            fadeOutMessage($msg);
        }, 3000)
    }

    function fadeOutMessage(msg) {
        $msg = $(msg);
        $msg.show();
        var interval = setInterval(function () {
            var opacity = parseFloat($msg.css('opacity'));
            if (opacity > 0) {
                $msg.css('opacity', opacity - 0.1);
            } else {
                $msg.hide();
                clearInterval(interval);
            }
        }, 100);
    }

   
}(jQuery))