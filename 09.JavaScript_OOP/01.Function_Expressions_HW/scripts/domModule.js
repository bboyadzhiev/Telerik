var domModule = (function () {
    var domBuffer = [];

    var appendChild = function (childElement, parentElementSelector) {
        var parent = document.querySelector(parentElementSelector);
        parent.appendChild(childElement);
    }

    var removeGhild = function (parentElementSelector, childElementSelector) {
        var parent = document.querySelector(parentElementSelector);
        var child = parent.querySelector(childElementSelector)
        if (parent && child) {
            parent.removeChild(child);
        }        
    }

    var addHandler = function (domElementsSelector, event, handler) {
        var elements = document.querySelectorAll(domElementsSelector);
        for (var i = 0; i < elements.length; i++) {
            elements[i].addEventListener(event, handler);
        }
    }

    var appendToBuffer = function (containerSelector, element){
        if (domBuffer[containerSelector]) {
            domBuffer[containerSelector].push(element);

            if (domBuffer[containerSelector].length>=100) {
                var container = document.querySelector(containerSelector);
                for (var i = 0; i < domBuffer[containerSelector].length; i++) {
                    container.appendChild(domBuffer[containerSelector][i]);
                }
                domBuffer[containerSelector] = [];
            }

        } else {
            domBuffer[containerSelector] = [];
            domBuffer[containerSelector].push(element);
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeGhild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer
    }

}());