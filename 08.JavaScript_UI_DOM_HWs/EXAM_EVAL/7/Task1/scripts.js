function createImagesPreviewer(selector, animals) {
    var container = document.querySelector(selector);
    var previewDiv = document.createElement('div');
    var filterInput = document.createElement('input');
    var labelForInput = document.createElement("Label");
    labelForInput.setAttribute("for", filterInput);
    labelForInput.innerHTML = "Filter";
    var body = document.body;
    body.appendChild(labelForInput);

    var previewAnimalTitle = document.createElement('strong');
    var previewAnimalImage = document.createElement('img');
    previewAnimalTitle.innerHTML = animals[0].title;

    previewDiv.id = "preview";
    previewDiv.style.cssFloat="left";
    previewDiv.style.width = "600px";
    previewDiv.style.height = "600px";
    previewAnimalImage.style.width = "400px";
    previewAnimalImage.style.height = "400px";
    previewDiv.appendChild(previewAnimalImage);
    previewDiv.appendChild(previewAnimalTitle);
    
    previewAnimalImage.src = animals[0].url;

    var currentAnimalBox = document.createElement('div');
    var currentAnimalTitle = document.createElement('strong');
    var currentAnimalContent = document.createElement('div');
    var currentAnimalImage = document.createElement('img');

    //set styles
    currentAnimalImage.style.width = '120px';
    currentAnimalImage.style.height = '120px';
    currentAnimalBox.dispay = "block";
    currentAnimalBox.style.cssFloat="right";

    currentAnimalBox.appendChild(currentAnimalTitle);
    currentAnimalContent.appendChild(currentAnimalImage);
    currentAnimalBox.appendChild(currentAnimalContent);

    function createAnimalDivs(animals) {
        var animalBoxes = [];
        for (var i = 0; i < animals.length; i += 1) {
            currentAnimalTitle.innerHTML = animals[i].title;
            currentAnimalImage.src = animals[i].url;
            animalBoxes.push(currentAnimalBox.cloneNode(true));
        }

        return animalBoxes;
    }

    var animalBoxes = createAnimalDivs(animals);
    var docFragment = document.createDocumentFragment();
    docFragment.appendChild(previewDiv);
    docFragment.appendChild(filterInput);

    for (var i = 0; i < animalBoxes.length; i += 1) {
        docFragment.appendChild(animalBoxes[i]);
    }
    container.appendChild(docFragment);
}
