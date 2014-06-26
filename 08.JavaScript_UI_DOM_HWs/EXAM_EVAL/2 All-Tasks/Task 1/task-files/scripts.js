
function createImagesPreviewer(selector, items) {
	var container = document.querySelector(selector);
	var docFragment = document.createDocumentFragment();
	var left = document.createElement('div');
	var right = document.createElement('div');

	left.style.width = '400px';
	left.style.height = '500px';
	left.style.float = 'left';
	left.style.paddingLeft = '10px';
	left.style.paddingRight = '10px';

	right.style.width = '150px';
	right.style.height = '500px';
	right.style.float = 'left';
	right.style.overflowY = 'scroll';
	right.style.overflowX = 'hidden';
	right.style.paddingLeft = '10px';
	right.style.paddingRight = '10px';
	right.style.textAlign = 'center';

	var filterBox = document.createElement('div');
	var filterBoxText = document.createTextNode('Filter');
	var filterBoxInput = document.createElement('input');
	filterBoxInput.setAttribute('type', 'text');
	filterBoxInput.style.width = '100%';
	filterBoxInput.addEventListener('keyup', filterInputChange);
	right.appendChild(filterBoxText);
	right.appendChild(filterBoxInput);

	function filterInputChange(e) {
		var text = this.value;
		var oldUl = document.getElementsByTagName('ul')[0];
		right.removeChild(oldUl);
		var thumbs = generateThums(text);
		right.appendChild(thumbs);
	}

	function generateThums(filter) {
		var ul = document.createElement('ul');
		ul.style.listStyleType = 'none';
		ul.style.margin = '0';
		ul.style.padding = '0';
		ul.style.textAlign = 'center';
		ul.setAttribute('id', 'thumbs-list');

		var liDocFragment = document.createDocumentFragment();
		for (var i = 0; i < items.length; i++) {

			if (filter.length > 0) {
				if (items[i].title.toLowerCase().indexOf(filter.toLowerCase()) < 0) {
					continue;
				}
			}

			var li = document.createElement('li');
			li.setAttribute('data-src', items[i].url);
			li.setAttribute('data-title', items[i].title);

			var title = document.createElement('strong');
			title.innerHTML = items[i].title;
			var img = document.createElement('img');
			img.setAttribute('src', items[i].url);
			img.setAttribute('class', 'thumb');
			img.style.width = '100%';
			img.style.borderRadius = '10px';

			li.addEventListener('mouseover', function (e) {
				this.style.backgroundColor = '#ccc';
			});

			li.addEventListener('mouseout', function (e) {
				this.style.backgroundColor = '';
			});

			li.addEventListener('click', thumbClick);

			li.appendChild(title);
			li.appendChild(img);
			liDocFragment.appendChild(li);
		}
		ul.appendChild(liDocFragment);
		return ul;
	}

	function thumbClick(e) {
		var mainImage = document.getElementById('gallery-main-image');
		var mainText = document.getElementById('gallery-main-text');
		mainImage.setAttribute('src', this.getAttribute('data-src'));
		mainText.innerHTML = this.getAttribute('data-title');
	}

	var thumbs = generateThums('');
	right.appendChild(thumbs);

	var initialTextH1 = document.createElement('h1');
	initialTextH1.setAttribute('id', 'gallery-main-text');
	var initialText = document.createTextNode(items[0].title);
	initialTextH1.style.textAlign = 'center';
	initialTextH1.appendChild(initialText);
	left.appendChild(initialTextH1);

	var initialImage = document.createElement('img');
	initialImage.setAttribute('src', items[0].url);
	initialImage.setAttribute('id', 'gallery-main-image');
	initialImage.style.width = '100%';
	initialImage.style.borderRadius = '30px';
	left.appendChild(initialImage);

	docFragment.appendChild(left);
	docFragment.appendChild(right);
	container.appendChild(docFragment);
}