/*jslint browser=true */
function createImagesPreviewer(selector, items) {
    'use strict';
    var div = document.createElement('div'),
        panelDiv = document.createElement('div'),
        img = document.createElement('img'),
        orgImg = document.createElement('img'),
        p = document.createElement('p'),
        wrapper = document.querySelector(selector),
        textInputBox = document.createElement('input'),
        elementsLength = items.length,
        docFragment = document.createDocumentFragment(),
        imgContainer,
        currentItem,
        lastValue = String.empty,
        panel,
        i;
    p.style.fontWeight = 'bold';
    p.style.fontSize = '2em';

    orgImg.style.width = '500px';
    orgImg.style.borderRadius = '20px';

    function createImageContainer() {
        imgContainer = div.cloneNode(false);

    }

    function createPanel() {
        panel = div.cloneNode(false);
        textInputBox.setAttribute('type', 'text');
        textInputBox.classList.add('input-type-text');
        panel.appendChild(textInputBox);
        panel.className = 'panel';


        for (i = 0; i < elementsLength; i += 1) {
            var generatedImg = img.cloneNode(false),
                imgDivContainer = panelDiv.cloneNode(false),
                pDivContainer = p.cloneNode(false);
            // IMG CONTAINER STYLE
            imgDivContainer.style.width = '220px';
            pDivContainer.style.fontSize = '0.8em';
            pDivContainer.style.margin = '0 auto';
            //END

            generatedImg.setAttribute('src', items[i].url);
            generatedImg.setAttribute('img-title', items[i].title);
            pDivContainer.innerHTML = items[i].title;
            imgDivContainer.appendChild(pDivContainer);
            imgDivContainer.appendChild(generatedImg);
            //EVENTS
            generatedImg.addEventListener('click', function () {
                var bigImg = orgImg.cloneNode(false),
                    currentImg = imgContainer.querySelector('img'),
                    currentP = imgContainer.querySelector('p'),
                    newP = p.cloneNode(false);

                if (currentImg) {
                    imgContainer.removeChild(currentImg);
                }

                if (currentP) {
                    imgContainer.removeChild(currentP);
                }

                bigImg.setAttribute('src', this.getAttribute('src'));
                newP.innerHTML = this.getAttribute('img-title');
                newP.style.textAlign = 'center';
                imgContainer.appendChild(newP);
                imgContainer.appendChild(bigImg);
            }, false);

            imgDivContainer.addEventListener('mouseover', function () {
                this.style.backgroundColor = '#CCC';
            });

            imgDivContainer.addEventListener('mouseout', function () {
                this.style.backgroundColor = '#FFF';
            });


            // END EVENTS
            docFragment.appendChild(imgDivContainer);
        }

        panel.appendChild(docFragment);
    }

    function applyStyleToImg() {
        img.style.width = '190px';
        img.style.borderRadius = '10px';
    }

    function applyStyleToPanel() {
        panel.style.width = '220px';
        panel.style.display = 'inline-block';
        panel.style.height = '450px';
        panel.style.textAlign = 'center';
        panel.style.margin = '0';
        panel.style.padding = '0';
        panel.style.display = 'inline-block';
        panel.style.position = 'absolute';
        panel.style.top = 0;
        panel.style.left = 800 - 220 + 'px';
        panel.style.overflow = 'auto';
    }

    function applyStyleToImageContainer() {
        imgContainer.style.width = '450px';
        imgContainer.style.margin = '0';
        imgContainer.style.padding = '0';
    }

    function applyStyleToWrapper() {
        wrapper.style.width = '800px';
        wrapper.style.height = '450px';
        wrapper.style.margin = '0';
        wrapper.style.padding = '0';
        wrapper.style.position = 'relative';
    }


    function addEventListenerToText() {
        textInputBox.addEventListener('keyup', function () {
            var value = this.value.toLowerCase(),
                currentDivs = panel.querySelectorAll('div'),
                imgName;
            if (lastValue === String.empty) {
                lastValue = value;
            }

            if (lastValue.length < value.length) {
                for (var k = 0; k < currentDivs.length; k++) {
                    imgName = currentDivs[k].querySelector('img').getAttribute('img-title').toLowerCase();
                    //console.log(imgName.indexOf(value));

                    if (imgName.indexOf(value) < 0) {

                        currentDivs[k].style.display = 'none';
                    }
                }
            } else if (lastValue.length > value.length) {
                for (var k = 0; k < currentDivs.length; k++) {
                    currentDivs[k].style.display = 'inline-block';
                }

                for (var k = 0; k < currentDivs.length; k++) {
                    imgName = currentDivs[k].querySelector('img').getAttribute('img-title').toLowerCase();
                    //console.log(imgName.indexOf(value));

                    if (imgName.indexOf(value) < 0) {

                        currentDivs[k].style.display = 'none';
                    }
                }


            } else if (value === null || value === undefined || value === '') {
                for (var k = 0; k < currentDivs.length; k++) {
                    currentDivs[k].style.display = 'inline-block';
                }
            }

            lastValue = value;
        });
    }

    function fireEvent(obj, evt) {

        var fireOnThis = obj;
        if (document.createEvent) {
            var evObj = document.createEvent('MouseEvents');
            evObj.initEvent(evt, true, false);
            fireOnThis.dispatchEvent(evObj);

        } else if (document.createEventObject) {
            var evObj = document.createEventObject();
            fireOnThis.fireEvent('on' + evt, evObj);
        }
    }

    applyStyleToImg();
    createImageContainer();
    createPanel();
    applyStyleToWrapper();
    applyStyleToPanel();
    applyStyleToImageContainer();
    wrapper.appendChild(imgContainer);
    wrapper.appendChild(panel);
    addEventListenerToText();
    fireEvent(panel.querySelector('img'), 'click');

}