function createImagesPreviewer(selector, items) {
    var container = getContainer(selector);

    initialize();

    function initialize() {
        var fragment = document.createDocumentFragment();

        fragment.appendChild(createSelectedContainer());
        fragment.appendChild(createListContainer());

        container.appendChild(fragment);
    }

    function createImageGroup() {
        // Todo: add heading and picture here
    }

    function createSelectedContainer() {
        var selectedContainer = document.createElement('div');

        selectedContainer.id = "selected-container";
        selectedContainer.style.cssFloat = "left";
        selectedContainer.style.textAlign = "center";
        selectedContainer.style.width = "65%";

        selectedContainer.innerHTML = 'selected container';

        return selectedContainer
    }

    function createListContainer() {
        var listContainer = document.createElement('div');

        listContainer.id = "selected-container";
        listContainer.style.cssFloat = "left";
        listContainer.style.textAlign = "center";
        listContainer.style.width = "35%";

        listContainer.innerHTML = 'list container';

        return listContainer;
    }

    function getContainer(selector) {
        var selectorType = selector.substring(0, 1),
            container;

        switch (selectorType) {
            case "#":
                container = document.getElementById(selector.substring(1));
                break;
            case ".":
                container = document.getElementsByClassName(selector.substring(1))[0];
                break;
            default:
                container = document.getElementsByName(selector)[0];
        }

        return container;
    }
}