function solve() {

  return function (selector, items) {
    var container,
      preview,
      previewImgHeader,
      previewImg,
      aside,
      inputHeader,
      input,
      listOfItems,
      li,
      imgHeader,
      img,
      currLi,
      currItem,
      currHeader,
      currImg,
      i,
      len;

    container = document.querySelector(selector);
    if (!container) {
      throw {
        message: 'Selector does not select anything'
      };
    }

    preview = document.createElement('div');
    preview.style.textAlign = 'center';
    preview.setAttribute('id', 'preview-div');
    preview.className = 'image-preview';
    preview.style.width = '70%';
    preview.style.display = 'inline-block';
    preview.style.cssFloat = 'left';

    previewImgHeader = document.createElement('h1');
    previewImgHeader.innerHTML = items[0].title;
    previewImg = document.createElement('img');
    previewImg.src = items[0].url;
    previewImg.style.width = '80%';
    previewImg.style.borderRadius = '5px';

    aside = document.createElement('div');
    aside.style.display = 'inline-block';
    aside.style.width = '25%';
    aside.style.textAlign = 'center';

    inputHeader = document.createElement('h3');
    inputHeader.innerHTML = 'Filter';
    input = document.createElement('input');
    input.style.width = '60%';
    input.addEventListener('keyup', function (ev) {
      var text = ev.target.value,
        liChildren = listOfItems.childNodes,
        currLi,
        currHeader,
        i,
        len;

      for (i = 0, len = liChildren.length; i < len; i += 1) {
        currLi = liChildren[i];
        currHeader = currLi.firstElementChild.innerHTML;
        if (currHeader.toLowerCase().indexOf(text.toLowerCase()) >= 0) {
          currLi.style.display = '';
        }
        else {
          currLi.style.display = 'none';
        }
      }
    }, false);

    listOfItems = document.createElement('ul');
    listOfItems.style.listStyleType = 'none';
    listOfItems.style.height = '600px';
    listOfItems.style.overflowY = 'scroll';
    listOfItems.addEventListener('click', function (ev) {
      var target = ev.target,
        clickedHeader,
        clickedImgSrc;

      if (target.tagName === 'IMG') {
        clickedHeader = target.previousElementSibling.innerHTML;
        clickedImgSrc = target.src;

        previewImgHeader.innerHTML = clickedHeader;
        previewImg.src = clickedImgSrc;
      }
      else if (target.tagName === 'H3') {
        clickedHeader = target.innerHTML;
        clickedImgSrc = target.nextElementSibling.src;

        previewImgHeader.innerHTML = clickedHeader;
        previewImg.src = clickedImgSrc;
      }
      else if (target.tagName === 'LI') {
        clickedHeader = target.firstElementChild.innerHTML;
        clickedImgSrc = target.firstElementChild.nextElementSibling.src;

        previewImgHeader.innerHTML = clickedHeader;
        previewImg.src = clickedImgSrc;
      }
    }, true);

    listOfItems.addEventListener('mouseover', function (ev) {
      var target = ev.target;

      if (target.tagName === 'IMG' || target.tagName === 'H3') {
        target.parentElement.style.backgroundColor = 'lightgray';
        target.parentElement.style.cursor = 'pointer';
      }
      else if (target.tagName === 'LI') {
        target.style.backgroundColor = 'lightgray';
        target.style.cursor = 'pointer';
      }
    }, false);

    listOfItems.addEventListener('mouseout', function (ev) {
      var target = ev.target;

      if (target.tagName === 'IMG' || target.tagName === 'H3') {
        target.parentElement.style.backgroundColor = '';
      }
      else if (target.tagName === 'LI') {
        target.style.backgroundColor = '';
      }
    }, false);

    li = document.createElement('li');
    li.className = 'image-container';
    imgHeader = document.createElement('h3');
    img = document.createElement('img');
    img.style.width = '80%';
    img.style.borderRadius = '5px';
    for (i = 0, len = items.length; i < len; i += 1) {
      currLi = li.cloneNode(true);
      currItem = items[i];
      currHeader = imgHeader.cloneNode(true);
      currHeader.innerHTML = currItem.title;
      currImg = img.cloneNode(true);
      currImg.src = currItem.url;

      currLi.appendChild(currHeader);
      currLi.appendChild(currImg);
      listOfItems.appendChild(currLi);
    }

    aside.appendChild(inputHeader);
    aside.appendChild(input);
    aside.appendChild(listOfItems);

    preview.appendChild(previewImgHeader);
    preview.appendChild(previewImg);

    container.appendChild(preview);
    container.appendChild(aside);
  };
}

module.exports = solve;