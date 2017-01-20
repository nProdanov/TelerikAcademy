/* globals document, window, console */

function solve() {
    return function (selector, initialSuggestions) {
        var container = document.querySelector(selector);
        var suggestions = [] ;
        if (!container) {
            throw {
                message: 'Selector does not select anything'
            };
        }

        
        if (initialSuggestions && initialSuggestions.length > 0) {
            for (var out = 0; out < initialSuggestions.length; out += 1) {
                var isThere = false;
                for (var inner = out + 1; inner < initialSuggestions.length; inner += 1) {
                    var first = initialSuggestions[out].toLowerCase();
                    var second =  initialSuggestions[inner].toLowerCase();
                    if (first === second) {
                        isThere = true;
                        break;
                    }
                }
                if (!isThere) {
                    suggestions.push(initialSuggestions[out]);
                }
            }
        }

        var listOfSuggestions = document.getElementsByClassName('suggestions-list')[0];
        listOfSuggestions.addEventListener('click', function (ev) {
            var target = ev.target;
            if (target.tagName === 'A') {
                input.value = target.innerHTML;
                for (var i = 0, len = links.length; i < len; i += 1) {
                    var currLink = links[i];
                    currLink.parentElement.style.display = 'none';
                }
            }
        }, false);

        var suggestion = document.createElement('li');
        suggestion.className = 'suggestion';
        suggestion.style.display = 'none';
        suggestion.style.borderTop = '1px solid black';
        var link = document.createElement('a');
        link.className = 'suggestion-link';

        for (var i = 0, len = suggestions.length; i < len; i += 1) {
            var currentLiText = suggestions[i];
            var currentLink = link.cloneNode(true);
            var currentSuggestion = suggestion.cloneNode(true);
            currentLink.innerHTML = currentLiText;
            currentSuggestion.appendChild(currentLink);
            listOfSuggestions.appendChild(currentSuggestion);
        }

        var links = document.getElementsByClassName('suggestion-link');

        var input = document.querySelector('.autocomplete .tb-pattern');
        input.addEventListener('keyup', function (ev) {
            var text = ev.target.value;
            for (var i = 0, len = links.length; i < len; i += 1) {
                var currLink = links[i];
                var currLinkText = currLink.innerHTML;
                if (currLinkText.toLowerCase().indexOf(text.toLowerCase()) >= 0 && text !== '') {
                    currLink.parentElement.style.display = '';
                    currLink.style.display = '';

                }
                else {
                    currLink.parentElement.style.display = 'none';
                    currLink.style.display = 'none';

                }
            }



        }, false);

        var addBtn = document.querySelector('.autocomplete .btn-add');
        addBtn.addEventListener('click', function (ev) {
            var target = ev.target;
            var inputValue = target.previousElementSibling.value;
            var isAppear = false;
            if (inputValue && inputValue !== '') {
                for (var i = 0, len = links.length; i < len; i += 1) {
                    var currLink = links[i];
                    var currLinkText = currLink.innerHTML;
                    if (inputValue.toLowerCase() === currLinkText.toLowerCase()) {
                        isAppear = true;
                        break;
                    }

                }
                if (!isAppear) {
                    var currentSuggestionToAdd = suggestion.cloneNode(true);
                    var currentLinkToAdd = link.cloneNode(true);
                    currentLinkToAdd.innerHTML = inputValue;
                    currentSuggestionToAdd.appendChild(currentLinkToAdd);
                    listOfSuggestions.appendChild(currentSuggestionToAdd);
                }

            }

            for (var i = 0, len = links.length; i < len; i += 1) {
                var currLink = links[i];
                var currLinkText = currLink.innerHTML;
                if (currLinkText.toLowerCase().indexOf(inputValue.toLowerCase()) >= 0 && inputValue !== '') {
                    currLink.parentElement.style.display = '';
                    currLink.style.display = '';

                }
                else {
                    currLink.parentElement.style.display = 'none';
                    currLink.style.display = 'none';

                }
            }


        }, false);
    };
}

module.exports = solve;