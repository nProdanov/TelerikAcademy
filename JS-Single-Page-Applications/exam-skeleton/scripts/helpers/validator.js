var app = app || {};

(function () {
    function checkIsString(text, param) {
        if (!text || typeof text !== 'string') {
            throw new Error(`${param} must be a string`);
        }
    }

    function checkIfTextIsWithCorrectLength(text, param) {
        let length = text.length;
        if (length < 6 || 30 < length) {
            throw new Error(`${param} length must be between 6 and 30 symbols`);
        }
    }

    function checkIfUsernameOnlyAllowedSymbols(text) {
        let pattern = /^[a-zA-Z0-9_.]+/;
        if (!pattern.test(text)) {
            throw new Error('Username must contains only lower or upper case symbols, "." or "_"');
        }
    }

    function checkIsURL(text) {
        var urlregex = new RegExp(
            "^(http:\/\/www.|https:\/\/www.|ftp:\/\/www.|www.){1}([0-9A-Za-z]+\.)");
        if (!urlregex.test(text)) {
            throw new Error('Must be valid url');
        }
    }

    class Validator {
        validateUsername(username) {
            checkIsString(username, 'Username');
            checkIfTextIsWithCorrectLength(username, 'Username');
            checkIfUsernameOnlyAllowedSymbols(username);
        }

        validateImgUrl(url) {
            checkIsString(url, 'url');
            checkIsURL(url);
        }
    }

    app.validator = new Validator();
})();