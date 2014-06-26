function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector);
    var previewDiv = document.createElement('div');
    var previewHeader = document.createElement('h1');
    var previewImage = document.createElement('img');
    var listDiv = document.createElement('div');
    var list = document.createElement('ul');
    var filter = document.createElement('input');

    previewDiv.style.display = 'inline-block';
    previewDiv.style.width = '70%';
    previewDiv.classList.add('preview-container');
    previewDiv.style.verticalAlign = 'top';
    previewDiv.style.marginRight = '10px';

    previewHeader.classList.add('preview-header');
    previewHeader.style.margin = '0 0 20px 0';
    previewHeader.style.padding = 0;
    previewHeader.style.textAlign = 'center';

    previewImage.classList.add('preview-image');
    previewImage.style.width = '95%';
    previewImage.style.height = 'auto';
    previewImage.style.borderRadius = '20px';

    previewDiv.appendChild(previewHeader);
    previewDiv.appendChild(previewImage);

    listDiv.style.display = 'inline-block';
    listDiv.classList.add('list-container');
    listDiv.style.width = '20%';
    listDiv.style.overflowY = 'auto';
    listDiv.style.height = '600px';

    filter.type = 'text';
    filter.classList.add('images-filter');
    filter.style.width = '90%';
    filter.onchange = onFilterChange;

    list.classList.add('list-images');
    list.style.listStyleType = 'none';

    list.style.margin = 0;
    list.style.padding = 0;

    listDiv.appendChild(filter);
    listDiv.appendChild(list);

    addListItems(list, items);

    container.appendChild(previewDiv);
    container.appendChild(listDiv);
    setPreviewImage(container.querySelector('.list-item:first-of-type'));


    function addListItems(list, items) {
        var itemTemplate = document.createElement('li');
        var itemHeader = document.createElement('h4');
        var itemImage = document.createElement('img');
        var item;

        itemHeader.classList.add('item-header');
        itemHeader.style.margin = 0;
        itemHeader.style.textAlign = 'center';

        itemImage.classList.add('item-image');
        itemImage.style.width = '90%';
        itemImage.style.height = 'auto';
        itemImage.style.borderRadius = '10px';

        itemTemplate.classList.add('list-item');
        itemTemplate.style.textAlign = 'center';
        itemTemplate.appendChild(itemHeader);
        itemTemplate.appendChild(itemImage);

        for (var i = 0; i < items.length; i++) {
            itemHeader.innerHTML = items[i].title;
            itemImage.src = items[i].url;
            item = itemTemplate.cloneNode(true);
            addEventHandlers(item);
            list.appendChild(item);
        }
    }

    function setPreviewImage(listItem) {
        var previewDiv = container.querySelector('.preview-container');
        previewDiv.querySelector('.preview-header').innerHTML = listItem.querySelector('.item-header').innerHTML;
        previewDiv.querySelector('.preview-image').src = listItem.querySelector('.item-image').src;
    }

    function listItemClick() {
        setPreviewImage(this);
    }

    function listItemMouseOver() {
        this.style.backgroundColor = 'silver';
    }

    function listItemMouseOut() {
        this.style.backgroundColor = '';
    }

    function onFilterChange() {
        var listItems = container.querySelectorAll('.list-item');
        var title;
        var filterValue = container.querySelector('.images-filter').value;
        var i;
        var regEx;

        if (!filterValue.trim()) {
            for (i = 0; i < listItems.length; i++) {
                listItems[i].style.display = '';
            }
        }
        else {
            regEx = new RegExp(filterValue, 'im');
            for (i = 0; i < listItems.length; i++) {
                title = listItems[i].querySelector('.item-header').textContent;
                if (!regEx.test(title)) {
                    listItems[i].style.display = 'none';
                }
            }
        }
    }

    function addEventHandlers(item) {
        item.addEventListener('click', listItemClick);
        item.addEventListener('mouseover', listItemMouseOver);
        item.addEventListener('mouseout', listItemMouseOut);
    }
}