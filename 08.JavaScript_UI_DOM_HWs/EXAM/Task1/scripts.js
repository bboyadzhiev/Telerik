function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector);

    var mainDiv = document.createElement('div');
    var sidePrevDiv = document.createElement('div');
    var bigPicDiv = document.createElement('div');
    var bigPicture = document.createElement('img');

    var sidePrevUL = document.createElement('ul');
    var smallPicLI = document.createElement('li');
    var smallPic = document.createElement('img');

    var selectBox = document.createElement('input');
    //var smallPicURL = document.createElement('img');
    var smallPicTitle = document.createElement('strong');

    const MAINDIV_W = 550, MAINDIV_H = 370;
    const SMALLPIC_W = 120, SMALLPIC_H = 90;

    const BIGDIV_W = 350, BIGDIV_H = 260;

    mainDiv.style.display = "inline-block";
    mainDiv.style.border = "1px solid black";
    mainDiv.style.width = MAINDIV_W + 'px';
    mainDiv.style.height = MAINDIV_H + 'px';
    mainDiv.style.verticalAlign = 'center';

    sidePrevDiv.style.border = "1px solid black";
    sidePrevDiv.style.float = "left";
    sidePrevDiv.style.display = "inline-block";
    sidePrevDiv.style.width = (MAINDIV_W - BIGDIV_W - 20) + 'px';
    sidePrevDiv.style.height = (MAINDIV_H - 20) + 'px';
    sidePrevDiv.style.overflow = "scroll";

    bigPicDiv.className = 'bigPicture';
    bigPicDiv.style.border = "1px solid black";
    bigPicDiv.style.width = BIGDIV_W + 'px';
  //  bigPicDiv.style.height = BIGDIV_H + 'px';
   // bigPicDiv.style.marginTop = '0px'
  //  bigPicDiv.style.verticalAlign = 'center';
    //bigPicDiv.style.marginBottom = ((MAINDIV_H - BIGDIV_H) / 2) + 'px';
    //bigPicDiv.style.paddingBottom = ((MAINDIV_H - BIGDIV_H) / 2) + 'px';
    bigPicDiv.style.display = "inline-block";
    bigPicture.src = items[0].url;
    bigPicture.style.width = BIGDIV_W + 'px'

    bigPicDiv.appendChild(bigPicture);
    var selectTitle = document.createElement('span');
    selectTitle.innerHTML = 'Filter';
    selectBox.type = "text";

    container.appendChild(mainDiv);

    mainDiv.appendChild(bigPicDiv);
    mainDiv.appendChild(sidePrevDiv);

    sidePrevDiv.classNAme = 'sidePrev';
    sidePrevDiv.align = 'center';
    sidePrevDiv.appendChild(selectTitle);
    sidePrevDiv.appendChild(selectBox);
    sidePrevDiv.appendChild(sidePrevUL);

    sidePrevUL.className = 'sidePrevUL';
    sidePrevUL.style.overflow = "none";
   // sidePrevUL.appendChild(smallPicLI);

    smallPicLI.className = 'smallPicLI';
    smallPicLI.style.listStyleType = 'none';
    smallPicLI.style.textAlign = 'center';
    smallPicLI.appendChild(smallPicTitle);
    smallPicLI.appendChild(smallPic);

    smallPicTitle.className = 'smallPicTitle';
    smallPicTitle.style.textAlign = 'center';
    smallPic.className = 'smallPic';
    smallPic.style.width = SMALLPIC_W + 'px';
   
    function createPrevPics(items) {
        var picContainers = [];
        for (var i = 0; i < items.length; i++) {
            smallPic.src = items[i].url;
            smallPicTitle.innerHTML = items[i].title;

            picContainers.push(smallPicLI.cloneNode(true));
            
        }
        return picContainers;
    }

    function addPicToContainer(i) {
        var picContainers = [];
        smallPic.src = items[i].url;
        smallPicTitle.innerHTML = items[i].title;

        picContainers.push(smallPicLI.cloneNode(true));
        return picContainers;
    }

    var smallpicsItems = null;//createPrevPics(items);

    function createSidePreviewer(smallpicsItems) {
        for (var i = 0; i < smallpicsItems.length; i++) {
            smallpicsItems[i].addEventListener('click', onSelectImage);
            smallpicsItems[i].addEventListener('mouseover', onmouseover);
            smallpicsItems[i].addEventListener('mouseout', onmouseout);
            sidePrevUL.appendChild(smallpicsItems[i]);
        }
    }

    function clearSidePreview() {
        while (sidePrevUL.firstChild) {
            sidePrevUL.removeChild(sidePrevUL.firstChild);
        }
    }

    selectBox.addEventListener('change', onSelectChange);
    function onSelectChange(ev) {
        var text = this.value;
        clearSidePreview();
        smallpicsItems = null;
        if (text !== null) {
            var selectedItems = [];
            for (var i = 0; i < items.length; i++) {
                        var title = items[i].title;
                        if (title.search(text) != -1) {
                            selectedItems.push(items[i]);
                            console.log('found');
                        }
            }
            if (selectedItems.length > 0) {
                smallpicsItems = createPrevPics(selectedItems);
                createSidePreviewer(smallpicsItems);
            }
            console.log(text);
        } else {
            smallpicsItems = createPrevPics(items);
            createSidePreviewer(smallpicsItems);
        }
        
    }

    function onmouseover(ev) {
        this.style.background = "#dddddd";
        
    }

    function onmouseout(ev) {
        this.style.background = "#ffffff";
    }

    function onSelectImage(ev) {
        var src = this.querySelector('img').getAttribute('src')
        bigPicture.src = src;
    }

    onSelectChange();
  
}