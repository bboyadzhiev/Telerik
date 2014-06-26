function createImagesPreviewer(selector, items) {
	var container = document.querySelector(selector);
	var rightSide = document.createElement('div');
	var leftSide = document.createElement('div');

	container.style.width = '650px';

	rightSide.style.display = 'inline-block';
	rightSide.style.width = '160px';
	rightSide.style.height = '400px';
	rightSide.style.overflow = 'scroll';
	rightSide.style.overflowX = 'hidden';

	leftSide.style.display = 'inline-block';
	leftSide.style.width = '450px';
	leftSide.style.height = '400px';

	container.appendChild(leftSide);
	container.appendChild(rightSide);

	var label = document.createElement('Label');
	label.setAttribute('for', 'filter');
	label.innerHTML = "Filter";
	//label.style.position = 'absolute';
	label.style.padding = '0px 60px';
	rightSide.appendChild(label);

	var filterBox = document.createElement('input');
	filterBox.setAttribute('type', 'text');
    filterBox.setAttribute('name', 'filter');
    filterBox.style.width = '135px';
    rightSide.appendChild(filterBox);

    var animalsImages = [{title: 'Cats',
    						path: 'images/cats.jpg'},
    					{title: 'Cow',
    						path: 'images/cow.jpg'},
    					{title: 'Dogs',
    						path: 'images/dogs.jpg'},
    					{title: 'Eagle',
    						path: 'images/eagle.jpg'},
    					{title: 'Elephant',
    						path: 'images/elephant.jpg'},
    					{title: 'Hamster',
    						path: 'images/hamster.jpg'},
    					{title: 'Horse',
    						path: 'images/horse.jpg'},
    					{title: 'Lion',
    						path: 'images/lion.jpg'},
    					{title: 'Rabbits',
    						path: 'images/rabbits.jpg'},
    					{title: 'Rhinos',
    						path: 'images/rhinos.jpg'},
    					{title: 'Squirrel',
    						path: 'images/squirrel.jpg'},
    					{title: 'Tigers',
    						path: 'images/tigers.jpg'}
    					];

    var animalsUl = document.createElement('ul');
    animalsUl.style.listStyleType = 'none';
    animalsUl.style.display = 'inline';
    //animalsUl.style.paddingTop = '50px';

    for(var i = 0; i < animalsImages.length; i+=1){
    	var titleLi = document.createElement('li');

    	titleLi.innerHTML = '<b>' + animalsImages[i].title + '</b>';
    	titleLi.style.textAlign = 'center';
    	if (i === 0){
    		titleLi.style.marginTop = '-20px';
    	}

    	var pictureLi = document.createElement('img');

    	pictureLi.setAttribute('src', animalsImages[i].path);
    	pictureLi.style.width = '130px';
    	pictureLi.style['-webkit-border-radius'] = '5px';
    	pictureLi.style.borderRadius = '5px';

		titleLi.appendChild(pictureLi);
    	animalsUl.appendChild(titleLi);
    }

    rightSide.appendChild(animalsUl);

    var selectedImage = null;

    function onImageMouseover(ev) {
		if (selectedImage !== this) {
			this.style.background = 'pink';
		}
	}

	function onImageMouseout(ev) {
		if (selectedImage !== this) {
			this.style.background = '';
		}
	}

	function onImageClick(ev, element) {
		if (selectedImage) { 
			selectedImage.style.background = '';
		}
		if (selectedImage && selectedImage === this) {
			selectedImage = null;
		} else {
			leftSide.innerHTML = '';

			var bigImage = document.createElement('img');
			
			for (var i = 0; i < animalsImages.length; i+=1){
				if (this.innerText === animalsImages[i].title){
					bigImage.setAttribute('src', animalsImages[i].path);
				}
			}
			bigImage.style.width = '400px';
			bigImage.style['-webkit-border-radius'] = '5px';
    		bigImage.style.borderRadius = '5px';
    		bigImage.style.position = 'absolute';
    		bigImage.style.left = '25px';
    		bigImage.style.top = '80px';

    		var headerTitle = document.createElement('h2');
    		headerTitle.innerHTML = this.innerText;
    		headerTitle.style.position = 'absolute';
    		headerTitle.style.top = '10px';
    		headerTitle.style.left = '190px';

    		leftSide.appendChild(headerTitle);
    		leftSide.appendChild(bigImage);

			selectedImage = this;
		}
	}

	var liElements = document.getElementsByTagName('li');

	for (var i = 0, len = liElements.length; i < len; i+=1) {
		liElements[i].addEventListener('click', onImageClick);
		liElements[i].addEventListener('mouseover', onImageMouseover);
		liElements[i].addEventListener('mouseout', onImageMouseout);
	}
}