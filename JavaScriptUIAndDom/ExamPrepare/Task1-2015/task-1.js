function solve() {
  return function (selector, isCaseSensitive) {
    var container = document.querySelector(selector);
    if (!container) {
      throw {
        message: 'selector does not match anything'
      };
    }

    container.className = 'items-control';
    container.style.width = '500px';
    container.style.border = '1px solid black';
    container.style.textAlign = 'center';

    var fragment = document.createDocumentFragment();

    var controls = document.createElement('div');
    var text = document.createElement('p');
    text.style.display = 'inline-block';
    var inpunt = document.createElement('input');
    inpunt.style.display = 'inline-block';
    var button = document.createElement('button');
    button.style.backgroundColor = 'lightgray';
    button.style.borderRadius = '3px';
    button.style.border = '1px solid black';
    button.style.height = '30px';
    button.style.marginBottom = '10px';
    button.className = 'button';

    //add controls
    var addControls = controls.cloneNode(true);
    addControls.style.width = '100%';
    addControls.className = 'add-controls';

    var addText = text.cloneNode(true);
    addText.innerHTML = 'Enter text';
    var addInput = inpunt.cloneNode(true);
    var addButton = button.cloneNode(true);
    addButton.innerHTML = 'Add';
    addButton.style.width = '80%';
    addButton.addEventListener('click', function () {
      var target = this;
      var ItemToAdd = target.previousElementSibling.value;
      target.previousElementSibling.value = '';
      var currItem = li.cloneNode(true);
      var currItemText = liText.cloneNode(true);
      currItemText.innerHTML = ItemToAdd;

      currItem.appendChild(currItemText);
      listOfItems.appendChild(currItem);
    }, false);

    addControls.appendChild(addText);
    addControls.appendChild(addInput);
    addControls.appendChild(addButton);

    //Search elements
    var searchControls = controls.cloneNode(true);
    searchControls.className = 'search-controls';
    searchControls.style.borderTop = '1px solid black';
    searchControls.style.borderBottom = '1px solid black';

    var searchText = text.cloneNode(true);
    searchText.innerHTML = 'Search:';
    var searchInput = inpunt.cloneNode(true);
    if (isCaseSensitive) {
      searchInput.addEventListener('keyup', function () {
        var searchingText = this.value;
        var listOfLi = listOfItems.childNodes;
        for (var i = 0, len = listOfLi.length; i < len; i += 1) {
          var currLi = listOfLi[i];
          var currLiText = currLi.firstElementChild.nextElementSibling.innerHTML;
          if (currLiText.indexOf(searchingText) >= 0) {
            currLi.style.display = '';
          }
          else {
            currLi.style.display = 'none';
          }
        }
      }, false);
    }
    else{
       searchInput.addEventListener('keyup', function () {
        var searchingText = this.value;
        var listOfLi = listOfItems.childNodes;
        for (var i = 0, len = listOfLi.length; i < len; i += 1) {
          var currLi = listOfLi[i];
          var currLiText = currLi.firstElementChild.nextElementSibling.innerHTML;
          if (currLiText.toLowerCase().indexOf(searchingText.toLowerCase()) >= 0) {
            currLi.style.display = '';
          }
          else {
            currLi.style.display = 'none';
          }
        }
      }, false);
    }


    searchControls.appendChild(searchText);
    searchControls.appendChild(searchInput);

    //Result elements
    var resultControls = controls.cloneNode(true);
    resultControls.className = 'result-controls'; 'result-controls'
    var listOfItems = document.createElement('ul');
    listOfItems.className = 'items-list';
    listOfItems.style.listStyleType = 'none';
    listOfItems.style.paddingLeft = '100px';
    listOfItems.addEventListener('click', function (ev) {
      var target = ev.target;
      var parentElement = target.parentElement;
      if (target.tagName === 'BUTTON' && parentElement.tagName === 'LI') {
        parentElement.parentElement.removeChild(parentElement);
      }
    }, false);

    var li = document.createElement('li');
    li.className = 'list-item';
    li.style.borderBottom = '1px solid black';
    li.style.textAlign = 'left';
    var liButton = button.cloneNode(true);
    liButton.innerHTML = 'X';
    liButton.style.width = '30px';
    liButton.style.height = '30px';

    var liText = document.createElement('h2');
    liText.style.margin = '10px';
    liText.style.display = 'inline-block';
    li.appendChild(liButton);

    searchControls.appendChild(listOfItems);

    fragment.appendChild(addControls);
    fragment.appendChild(searchControls);
    fragment.appendChild(resultControls);

    container.appendChild(fragment);
  };
}

module.exports = solve;