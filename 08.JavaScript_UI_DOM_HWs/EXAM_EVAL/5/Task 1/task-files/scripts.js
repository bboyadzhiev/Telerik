function createImagesPreviewer(selector, items) {
	var container = document.querySelector(selector);
	var mainBox = document.createElement('div');
	var mainBoxTitle = document.createElement('h1')
	var mainBoxContent = document.createElement('img');
	var sideBar = document.createElement('div');
	var imageContainer = document.createElement('div');

	var smallImage = document.createElement('div');
	var smallImageTitle = document.createElement('strong');
	var smallImageContent = document.createElement('img');
	var filterBox  =  document.createElement('div');
	var filterName = document.createElement('div');
	var filterForm = document.createElement('form');
	var filterInput = document.createElement('input');
	var filteredAnimals = animals.slice(0);


	filterName.innerHTML = 'Filter';
	filterName.style.display = 'block';
	filterName.style.background = 'white';
	filterName.style.textAlign = 'center';
	filterName.style.color = 'black';
	filterBox.style.margin = '0';
	filterBox.style.padding = '0';
	filterBox.style.marginLeft = 'auto';
	filterBox.style.marginRight = 'auto';
	filterInput.setAttribute('name', 'filterInputString');
	filterInput.setAttribute('type', 'text');
	filterInput.setAttribute('type', 'text');
	filterInput.setAttribute('id', 'read-string');
	imageContainer.setAttribute('id', 'image-container');
	imageContainer.style.margin = '0';
	imageContainer.style.padding = '0';
	smallImage.style.margin = '0';
	smallImage.style.padding = '0';
	smallImageContent.style.margin = '0';
	smallImageContent.style.padding = '0';	
	smallImageTitle.style.margin = '0';
	smallImageTitle.style.padding = '0';



	mainBox.style.width = '800px';
	
	mainBox.style.display = 'inline-block';
	sideBar.style.display = 'inline-block';
	sideBar.style.position = 'absolute';
	sideBar.style.left = '700px';



	smallImageContent.style.width = '120px';
	smallImageContent.style['border-radius'] = '10px';
	smallImageTitle.style.display = 'block';
	smallImageTitle.style.textAlign = 'center';
	smallImageTitle.style.color = 'black';


	smallImageTitle.className = 'im-title';
	smallImageContent.className = 'thumbnail';

	smallImage.appendChild(smallImageTitle);
	smallImage.appendChild(smallImageContent);


	mainBox.style.width = '700px';
	mainBoxContent.style.width = '500px';
	mainBoxContent.style['border-radius'] = '20px';
	mainBox.style.position = 'fixed';
	//mainBox.style.overflow = 'scroll';

	mainBoxTitle.style.display = 'block';
	mainBoxTitle.style.textAlign = 'center';
	mainBoxTitle.style.color = 'black';
	//smallImageTitle.style.borderBottom = '1px solid purple';


	mainBoxTitle.className = 'im-title-big';
	mainBoxContent.className = 'thumbnail-big';
	smallImage.appendChild(smallImageTitle);
	smallImage.appendChild(smallImageContent);

	mainBox.appendChild(mainBoxTitle);
	mainBox.appendChild(mainBoxContent);

	//initialize first image!
	var currentSelection = items[0];
	var curUrl = currentSelection.url;
	var curTitle = currentSelection.title;
	function updateSelection (urlIn, titleIn){
		mainBoxContent.src = urlIn;
		mainBoxTitle.innerHTML = titleIn;	
	}
	updateSelection(curUrl, curTitle);//now run it


	function loadImages (items) {
		var imagesToLoad = [];
		for (var i = 0; i < items.length; i++) {
			smallImageContent.src =  items[i].url;
			smallImageTitle.innerHTML = items[i].title;
			imagesToLoad.push(smallImage.cloneNode(true));
		}
		return imagesToLoad;
	}


	function onBoxMouseover(ev) {
		this.style.background = '#CACACA';
	}

	function onBoxMouseout(ev) {
		this.style.background = '';
	}

	//update element
	function onBoxClick(ev) {
		var titleToChange  = this.querySelector('.im-title');
		titleToChange = titleToChange .innerHTML;
		var urlToChange = this.querySelector('.thumbnail');
		urlToChange = urlToChange.src;
		updateSelection(urlToChange,titleToChange  );
	}
	//try filtering
	function onFilterImages() {
		//var inputString = document.getElementById('read-string');
		var inputString = document.getElementsByTagName("input")[0].value;

		if (!inputString||!filteredAnimals){
			filteredAnimals = animals.slice(0);
			return;
		}
		inputString = inputString.toLowerCase();
		filteredAnimals = [];
		for (var i = 0; i < animals.length; i++) {
			var compString = animals[i].title;
			compString = compString.toLowerCase()
			console.log(compString + ".<-comp string input string->." + inputString);
			if(compString.indexOf(inputString)>=0){
				filteredAnimals.push(animals[i]);
			}
		}
		newTiles = loadImages(filteredAnimals);		
		for (var k = 0; k < filteredAnimals.length; k ++){
			console.log("filtered  " + filteredAnimals[k].title + "  filteredAnimals");
		}
		if (!inputString||!filteredAnimals){
			filteredAnimals = animals.slice(0);
			ReplaceImageContainer(filteredAnimals);
			return;
		}
		ReplaceImageContainer(filteredAnimals);

	}
	function ReplaceImageContainer (arrayImages){
		var newImageContainer = document.createElement('div');
		newImageContainer.setAttribute('id', 'image-container');

		for (var i = 0; i < arrayImages.length; i ++ ) {
			arrayImages[i].addEventListener('click', onBoxClick);
			arrayImages[i].addEventListener('mouseover', onBoxMouseover);
			arrayImages[i].addEventListener('mouseout', onBoxMouseout);
			newImageContainer.appendChild(arrayImages[i]);
		}
		var objectContainer = document.getElementById('image-container');
		if ((newImageContainer)&&(objectContainer)){
			console.log(objectContainer.parentNode);
			console.log(objectContainer);
			console.log(newImageContainer);
			//var objectContainer = objectContainer.parentNode.replaceChild(objectContainer, newImageContainer);
			objectContainer.parentNode.firstElementChild.outerHTML  = objectContainer.parentNode.firstElementChild.outerHTML.replace(objectContainer, newImageContainer);
		}
		console.log(objectContainer);

		//forceRedraw();

	}

	var arrayImages = loadImages(filteredAnimals)
	var docFragment = document.createDocumentFragment();
	for (var i = 0; i < arrayImages.length; i += 1) {
		imageContainer.appendChild(arrayImages[i]);
		arrayImages[i].addEventListener('click', onBoxClick);
		arrayImages[i].addEventListener('mouseover', onBoxMouseover);
		arrayImages[i].addEventListener('mouseout', onBoxMouseout);
	}
	filterForm.appendChild(filterInput);
	filterBox.appendChild(filterName);
	filterBox.appendChild(filterForm);
	sideBar.appendChild(filterBox);
	sideBar.appendChild(imageContainer);
	docFragment.appendChild(mainBox);
	docFragment.appendChild(sideBar);
	filterInput.addEventListener('keyup', onFilterImages);
	container.appendChild(docFragment);

}


var forceRedraw = function(element){

    if (!element) { return; }

    var n = document.createTextNode(' ');
    var disp = element.style.display;  // don't worry about previous display style

    element.appendChild(n);
    element.style.display = 'none';

    setTimeout(function(){
        element.style.display = disp;
        n.parentNode.removeChild(n);
    },20); // you can play with this timeout to make it as short as possible
}

	

