var
    itemTextArea = document.getElementById('itemTextArea'),
    addItemBtn = document.getElementById('addItemBtn'),
    removeItemBtn = document.getElementById('removeItemBtn'),
    showAllItemsBtn = document.getElementById('showAllItemsBtn'),
    hideItemBtn = document.getElementById('hideItemBtn'),
    todoList = document.getElementById('todoList');

addItemBtn.addEventListener('click', addItem);
showAllItemsBtn.addEventListener('click', showList);
hideItemBtn.addEventListener('click', hideItem);
removeItemBtn.addEventListener('click', removeItem);

function addItem() {
    var todoLi = document.createElement('li');
    var todoCB = document.createElement('input');

   
    todoCB.type = 'checkbox';
    todoLi.appendChild(todoCB);
    todoLi.className = 'todo-item';
    todoLi.classList.add('deletable');
   
    todoLi.appendChild(document.createTextNode(itemTextArea.value));
    todoList.appendChild(todoLi);
}


function showList() {
    var items = document.querySelectorAll('.todo-item.hidden input[type="checkbox"]');
    for (var i = 0; i < items.length; i++) {
        var parent = items[i].parentElement;
        parent.classList.add("deletable");
        parent.classList.remove("hidden");
        parent.style.display = "";
    }
}

function hideItem() {
    var items = document.querySelectorAll('.todo-item input[type="checkbox"]:checked');
    for (var i = 0; i < items.length; i++) {
        var parent = items[i].parentElement;
        items[i].removeAttribute('checked');
        parent.classList.add("hidden");
        parent.classList.remove("deletable");
        parent.style.display = "none";
    }
}

function removeItem() {
    var items = document.querySelectorAll('.todo-item.deletable input[type="checkbox"]:checked');
    for (var i = 0; i < items.length; i++) {
        var parent = items[i].parentElement;
        parent.parentNode.removeChild(parent);
    }
}