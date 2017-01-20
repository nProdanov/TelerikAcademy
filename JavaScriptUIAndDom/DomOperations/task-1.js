module.exports = function solve() {

    return function (element, contents) {
        
        checkIsParamIsValid(element);
        checkIsParamIsValid(contents);

        element = checkElementIsValid(element);
        checkIsContentsIsValid(contents);

        element.innerHTML = '';

        appendContentsToElement(element, contents);

        function appendContentsToElement(element, contents) {
            var div, divToAdd, len, i;
            div = document.createElement('div');

            for (i = 0, len = contents.length; i < len; i += 1) {
                divToAdd = div.cloneNode(true);
                divToAdd.innerHTML = contents[i];
                element.appendChild(divToAdd);
            }
        }

        function checkElementIsValid(element) {
            if (typeof element === 'string') {
                element = document.getElementById(element);
            }

            if (!(element instanceof HTMLElement)) {
                throw {
                    name: 'InvalidElementOrIDPassed',
                    message: 'IvalidElementOrIDPassed'
                };
            }

            return element;
        }

        function checkIsContentsIsValid(contents) {
            var i, len;

            if (!Array.isArray(contents)) {
                throw {
                    name: 'ContentsIsNotAnArray',
                    message: 'ContentIsNotAnArray'
                };
            }

            for (i = 0, len = contents.length; i < len; i += 1) {
                if (typeof contents[i] !== 'string' && typeof contents[i] !== 'number') {
                    throw {
                        name: 'ContentIsNeitherNumberOrString',
                        message: 'ContentIsNeitherNumberOrString'
                    };
                }
            }
        }

        function checkIsParamIsValid(param) {
            if (param === undefined || param === null) {
                throw {
                    name: 'InvalidParamPassed',
                    message: 'IvalidParamPassed'
                };
            }
        }
    };
};


// solve('root', ['content', 'content', 'content', 'content', 'content', 'content', 'content', 'content', 'content', 'content', 'content', 'content', 'content', 'content', 'content']);