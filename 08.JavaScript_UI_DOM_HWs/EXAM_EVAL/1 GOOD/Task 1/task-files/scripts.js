function createImagesPreviewer(selector, items) {
    var previewerContainer=document.querySelector(selector),
        previewEnlargedImageDiv=document.createElement('div'),
        sideContentDiv=document.createElement('div'),
        filterTextInput=document.createElement('input'),
        filterText=document.createElement('h4'),
        basicImageDiv=document.createElement('div'),
        basicTitle=document.createElement('h4'),
        basicImage=document.createElement('img');

    setPreviewEnlargedImageDivProperties();
    setSideContentDivProperties();
    setFilterTextInputProperties();
    setFilterTextProperties();
    setBasicImageDivProperties();
    styleBasicImage();
    styleBasicTitle();
    appendElementsInternally();
    makeImageTiles();
    buildPreviewerContent();
    addEventListeners();
    appendPreviewerToDOM();
    introduceFilterFunctionality();

    function setPreviewEnlargedImageDivProperties(){
        previewEnlargedImageDiv.style.margin='0';
        previewEnlargedImageDiv.style.width='55%';
        previewEnlargedImageDiv.style.textAlign='center';
        previewEnlargedImageDiv.style.display='inline-block';
        previewEnlargedImageDiv.style.float='left';
    }

    function setSideContentDivProperties(){
        sideContentDiv.style.margin='0';
        sideContentDiv.style.marginLeft='20px';
        sideContentDiv.style.width='25%';
        sideContentDiv.style.height='800px';
        sideContentDiv.style.overflow='scroll';
        sideContentDiv.style.display='inline-block';
        sideContentDiv.style.textAlign='center';
        sideContentDiv.classList.add('tilesContainer');
    }

    function setFilterTextInputProperties(){
        filterTextInput.type='text';
        filterTextInput.style.width='90%';
        filterTextInput.style.margin='0';
        filterTextInput.style.marginBottom='5px';
        filterTextInput.style.height='20px';
    }

    function setBasicImageDivProperties(){
        basicImageDiv.style.textAlign='center';
        basicImageDiv.style.margin='0';
        basicImageDiv.style.width='100%';
        basicImageDiv.style.textAlign='center';
    }

    function setFilterTextProperties(){
        filterText.innerText='Filter';
        filterText.style.margin='5px 0px';
        filterText.style.fontSize='22px';
    }

    function styleBasicImage(){
        basicImage.style.width='90%';
        basicImage.style.height='auto';
        basicImage.style.margin='0';
        basicImage.style.borderRadius='15px';
    }

    function styleBasicTitle(){
        basicTitle.style.margin='0';
        basicTitle.style.fontSize='22px';
    }

    function buildPreviewerContent() {
        var previewerTitle=basicTitle.cloneNode(true),
            previewerImage=basicImage.cloneNode(true);

        previewerTitle.style.fontSize='50px';
        previewerTitle.style.margin='30px 0px';
        previewerTitle.style.marginTop='20px';

        previewerImage.style.width='95%';
        previewerImage.style.margin='0';
        previewerImage.style.borderRadius='30px';

        previewEnlargedImageDiv.appendChild(previewerTitle);
        previewEnlargedImageDiv.appendChild(previewerImage);

        specifyCustomPropertiesForTile(previewEnlargedImageDiv,items[0].title,items[0].url);
    }

    function makeImageTiles(){
        for (var i = 0; i < items.length; i++) {
            var currentAnimalItem=items[i],
                currentTitle=currentAnimalItem.title,
                currentUrl=currentAnimalItem.url;

            var currentTile=basicImageDiv.cloneNode(true);

            var tileDiv=specifyCustomPropertiesForTile(currentTile,currentTitle,currentUrl);

            sideContentDiv.appendChild(tileDiv);
        }
    }

    function addEventListeners(){
        sideContentDiv.addEventListener('mouseover',function(e) {
            recolorTarget(e.target,'lightgrey');
        });

        sideContentDiv.addEventListener('mouseout',function(e) {
            recolorTarget(e.target,'white');
        });

        sideContentDiv.addEventListener('click',function(e) {
            processElementClick(e.target);
        })
    }

    function introduceFilterFunctionality() {
        filterTextInput.onkeydown = filterImages;
        filterTextInput.onkeyup = filterImages;
        filterTextInput.onkeypress = filterImages;

        function filterImages() {
            var content=sideContentDiv.children;

            if (this.value.length<1)
            {
                showAllImages(content);
            }
            else
            {
                hideOrShowFilteredContent(content,this.value.toLowerCase());
            }
        }
    }

    function hideOrShowFilteredContent(content,filterText){
        for (var i = 0; i < content.length; i++) {
            if (content[i].tagName=='DIV'){
                var currentTitle=content[i].children[0].innerHTML;
                var titleToLower=currentTitle.toLowerCase();

                if (titleToLower.indexOf(filterText)===-1){
                    content[i].style.display='none';
                }
                else if (titleToLower.indexOf(filterText)!==-1&&content[i].style.display=='none'){
                    content[i].style.display='block';
                }
            }
        }
    }

    function showAllImages(content){
        for (var i = 0; i < content.length; i++) {
            if (content[i].tagName=='DIV'){
                content[i].style.display='block';
            }
        }
    }

    function specifyCustomPropertiesForTile(tileDiv,title,url){
        var divTitle=tileDiv.children[0];
        divImage=tileDiv.children[1];

        divTitle.innerText=title;
        divImage.setAttribute('src',url);
        divImage.setAttribute('alt',title);

        return tileDiv;
    }

    function processElementClick(target){
        if(target.tagName=='IMG'){
            setImagePreview(target);
        }
        else if (target.tagName=='H4'){
            var image= target.parentNode.children[1];
            setImagePreview(image);
        }
        else if(target.tagName=='DIV'&&!target.classList.contains('tilesContainer')){
            var image= target.children[1];
            setImagePreview(image);
        }
    }

    function recolorTarget(target,color){
        if(target.tagName=='IMG'||target.tagName==='H4'){
            target.parentNode.style.backgroundColor=color;
        }
        else if(target.tagName=='DIV'&&! target.classList.contains('tilesContainer')){
            target.style.backgroundColor=color;
        }
    }

    function setImagePreview(image){
        var imageTitle= image.alt;
        var imageSource= image.src;

        specifyCustomPropertiesForTile(previewEnlargedImageDiv,imageTitle,imageSource);
    }

    function appendElementsInternally(){
        basicImageDiv.appendChild(basicTitle);
        basicImageDiv.appendChild(basicImage);
        sideContentDiv.appendChild(filterText);
        sideContentDiv.appendChild(filterTextInput);
    }

    function appendPreviewerToDOM(){
        var contentFrag=document.createDocumentFragment();

        contentFrag.appendChild(previewEnlargedImageDiv);
        contentFrag.appendChild(sideContentDiv);

        previewerContainer.appendChild(contentFrag);
    }




}