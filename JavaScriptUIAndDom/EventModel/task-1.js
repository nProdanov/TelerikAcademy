function solve() {

    return function (element) {
    var buttonClassElements, contentClassElements, i, len;

    element = checkIfElementIsValid(element);

    buttonClassElements = element.getElementsByClassName('button');
    contentClassElements = element.getElementsByClassName('content');

    for (i = 0, len = buttonClassElements.length; i < len; i += 1) {
        buttonClassElements[i].innerHTML = 'hide';
    }

     element.addEventListener('click', clickButton);

    function clickButton(e) {
        var sender = e.target,
            currentElement = sender,
            foundButtonAfterContent = false,
            checkElementForButtonAfterContent;
        if (currentElement.className !== 'button'){
                return;
            }

        while (true) {
            currentElement = currentElement.nextElementSibling;
            if (!currentElement) {
                return;
            } 

            if (currentElement.className === 'content') {
                while(true){
                    checkElementForButtonAfterContent = currentElement.nextElementSibling;
                    if (!checkElementForButtonAfterContent){
                        break;
                    }

                    if (checkElementForButtonAfterContent.className === 'button'){
                        foundButtonAfterContent = true;
                        break;
                    }
                }
                if (!foundButtonAfterContent){
                    return;
                }
                if (currentElement.style.display === 'none') {
                    currentElement.style.display = '';
                    sender.innerHTML = 'hide';
                }
                else {
                    currentElement.style.display = 'none';
                    sender.innerHTML = 'show';
                }

                return;
            }
        }
    }

    function checkIfElementIsValid(element) {
        if (typeof element === 'string') {
            element = document.getElementById(element);
        }

        if (!(element instanceof HTMLElement)) {
            throw {
                name: 'ElementsIsNeitherIdOrHTMLElement',
                message: 'ElementsIsNeitherIdOrHTMLElement'
            };
        }

        return element;
    }

    };
}