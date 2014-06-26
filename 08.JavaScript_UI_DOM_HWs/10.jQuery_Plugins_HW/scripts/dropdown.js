/// <reference path="jquery-2.1.1.js" />
(function ($) {
    $.fn.dropdown = function () {
        $this = $(this);

        var $dropdownContainer = $('<div></div>')
                .addClass('dropdown-list-container')
                .insertAfter($this);
        var $dropDownOptions = $('<ul></ul>')
            .addClass('dropdown-list-options')
            .appendTo($dropdownContainer);

        var $options = $this.children();

        $options.each(function () {
            var $option = $(this);
            $('<li>' + $option.text() + '</li>')
                .addClass('dropdown-list-option')
                //.data('data-value', $option.val())
                .attr('data-value', $option.val())
                .appendTo($dropDownOptions);
           
        });
       
        $this.on('change', function () {
            var value = $this.find(":selected").val();
            $('.dropdown-list-option').css('background-color', '');
            var $listOptions = $('.dropdown-list-option[data\-value=\''+value+'\']');
            $listOptions.css('background-color', 'red');
        });

        $('.dropdown-list-option').on('click', function () {
            var liData = $(this).attr('data-value');
            $('#dropdown').children().removeAttr('selected');
            var selector = $('#dropdown option[value="' + liData + '"]').attr('selected', 'selected');

        })
    }
}(jQuery))