'use strict';
function solve() {
    let CONSTANTS = {
        OPT_NAME: 'Value',
        MIN_NAME_LENGTH: 2,
        MIN_DURATION: 1,
        MIN_GENRE_LENGTH: 2,
        MIN_RAITNG: 1,
        MAX_GENRE_LENGTH: 20,
        MAX_RATING: 5,
        MAX_NAME_LENGTH: 40,
        POSSIBLE_ISBN_LENGTH: [10, 13]
    };
    let ERR_MSGS = {
        UNDEFINED: ' must not be an undefined',
        NULL: ' must not be null',
        STRING: ' must be a string',
        OBJECT: ' must be an object',
        NUM: ' must be a number',
        RANGE: ' must be in a range ',
        ONLY_DIGITS: ' must contains only digits',
        ISBN_LENGTH: 'ISBN length must be exactly 10 or 13 symbols'
    };

    let validator = (function () {
        return {
            validateIfUndefined: function (val, name) {
                if (val === undefined) {
                    throw new Error(name + ERR_MSGS.UNDEFINED);
                }
            },
            validateIfNull: function (val, name) {
                name = name || CONSTANTS.OPT_NAME;
                if (val === null) {
                    throw new Error(name + ERR_MSGS.NULL);
                }
            },
            validateIfObject: function (val, name) {
                name = name || CONSTANTS.OPT_NAME;
                if (typeof val !== 'object') {
                    throw new Error(name + ERR_MSGS.OBJECT);
                }
            },
            validateIfValidString: function (val, name) {
                name = name || CONSTANTS.OPT_NAME;
                this.validateIfUndefined(val, name);
                if (typeof val !== 'string' || val.length === 0) {
                    throw new Error(name + ERR_MSGS.STRING);
                }
            },
            validateIfValidNumber: function (val, name) {
                name = name || CONSTANTS.OPT_NAME;
                this.validateIfUndefined(val, name);
                if (typeof val !== 'number') {
                    throw new Error(name + ERR_MSGS.NUM);
                }
            },
            validateIfNumberInRange: function (val, name, min, max) {
                name = name || CONSTANTS.OPT_NAME;
                this.validateIfValidNumber(val, name);
                if (val < min || max < val) {
                    throw new Error(name + ERR_MSGS.RANGE + min + ' and ' + max);
                }
            },
            validateIfNameValid: function (val) {
                this.validateIfValidString(val, 'Name');
                this.validateIfNumberInRange(
                    val.length,
                    'Name length',
                    CONSTANTS.MIN_NAME_LENGTH,
                    CONSTANTS.MAX_NAME_LENGTH);
            },
            validateISBN: function (val) {
                validator.validateIfValidString(val, 'ISBN');

                if (val.length !== CONSTANTS.POSSIBLE_ISBN_LENGTH[0] &&
                    val.length !== CONSTANTS.POSSIBLE_ISBN_LENGTH[1]) {
                    throw new Error(ERR_MSGS.ISBN_LENGTH);
                }

                if (!(/^\d+$/.test(val))) {
                    throw new Error('ISBN' + ERR_MSGS.ONLY_DIGITS);
                }
            },
            validateIfItemLikeObject: function (val, name) {
                name = name || CONSTANTS.OPT_NAME;
                this.validateIfUndefined(val, name);
                this.validateIfObject(val, name);
                this.validateIfUndefined(val.id, 'Id of Item');
                this.validateIfUndefined(val.name, 'Name of Item');
            }
        };
    })();

    let item = (function () {
        let currItemId = 0;

        class Item {
            constructor(description, name) {
                this.description = description;
                this.name = name;
                this._id = ++currItemId;
            }

            get description() {
                return this._description;
            }

            set description(value) {
                validator.validateIfValidString(value, 'Description of the item');

                this._description = value;
            }

            get name() {
                return this._name;
            }

            set name(value) {
                validator.validateIfValidString(value, 'Name of the item');
                validator.validateIfNumberInRange(
                    value.length,
                    'Lenght of the name of item',
                    CONSTANTS.MIN_NAME_LENGTH,
                    CONSTANTS.MAX_NAME_LENGTH);
                this._name = value;
            }

            get id() {
                return this._id;
            }
        }

        return Item;
    })();

    let book = (function () {
        class Book extends item {
            constructor(name, isbn, genre, description) {
                super(description, name);
                this.isbn = isbn;
                this.genre = genre;
            }

            get isbn() {
                return this._isbn;
            }

            set isbn(value) {
                validator.validateISBN(value);
                this._isbn = value;
            }

            get genre() {
                return this._genre;
            }

            set genre(value) {
                validator.validateIfValidString(value, 'Genre of the book');
                validator.validateIfNumberInRange(
                    value.length,
                    'Lenght of the genre of book',
                    CONSTANTS.MIN_GENRE_LENGTH,
                    CONSTANTS.MAX_GENRE_LENGTH);
                this._genre = value;
            }
        }

        return Book;
    })();

    let media = (function () {
        class Media extends item {
            constructor(name, rating, duration, description) {
                super(description, name);
                this.rating = rating;
                this.duration = duration;
            }

            get rating() {
                return this._rating;
            }

            set rating(value) {
                validator.validateIfNumberInRange(value, 'Rating of the media', CONSTANTS.MIN_RAITNG, CONSTANTS.MAX_RATING);
                this._rating = value;
            }

            get duration() {
                return this._duration;
            }

            set duration(value) {
                validator.validateIfNumberInRange(
                    value,
                    'Duration of the media',
                    CONSTANTS.MIN_DURATION,
                    Number.MAX_VALUE);

                this._duration = value;
            }
        }

        return Media;
    })();

    let catalog = (function () {
        let currCatalogId = 0;

        class Catalog {
            constructor(name) {
                this.name = name;
                this._id = ++currCatalogId;
                this._items = [];
            }

            get name() {
                return this._name;
            }

            set name(value) {
                validator.validateIfValidString(value, 'Name of the catalog');
                validator.validateIfNumberInRange(
                    value.length,
                    'Lenght of the name of catalog',
                    CONSTANTS.MIN_NAME_LENGTH,
                    CONSTANTS.MAX_NAME_LENGTH);
                this._name = value;
            }

            get id() {
                return this._id;
            }

            get items() {
                return this._items;
            }

            add(...itemsToAdd) {
                if (itemsToAdd.length === 0) {
                    throw new Error('Invalid items to add');
                }
                if (Array.isArray(itemsToAdd[0])) {
                    itemsToAdd = itemsToAdd[0];
                }

                itemsToAdd.forEach(this._validateAddingItem);

                this._items.push(...itemsToAdd);
                return this;
            }

            _validateAddingItem(item) {
                validator.validateIfItemLikeObject(item, 'Item to add');
            }

            find(options) {
                validator.validateIfUndefined(options, 'Options for searching');
                // validator.validateIfNull(options, 'Options for searching');
                if (typeof options === 'number') {
                    let searchingId = options;
                    let itemToShow = this._items.find(item => item.id === searchingId);
                    if (itemToShow === undefined) {
                        return null;
                    }
                    else {
                        return itemToShow;
                    }
                }
                else if (options !== null && typeof options === 'object') {
                    let objectWithProps = options;
                    let itemsToShow = this._items
                        .slice()
                        .filter(item => {
                            let isPass = true;
                            for (let prop in objectWithProps) {
                                if (item[prop] === undefined || item[prop] !== objectWithProps[prop]) {
                                    isPass = false;
                                    break;
                                }
                            }
                            return isPass;
                        });

                    return itemsToShow;
                }
                else {
                    throw new Error('Options for searching are invalid');
                }
            }

            search(pattern) {
                validator.validateIfValidString(pattern);
                validator.validateIfNumberInRange(
                    pattern.length,
                    'Length of the pattern',
                    1,
                    Number.MAX_VALUE);

                let patternToLower = pattern.toLowerCase();
                let itemsToShow = this._items
                    .slice()
                    .filter(item => {
                        let isPass = false;
                        let isContainInName = item.name.toLowerCase().indexOf(patternToLower) >= 0;
                        let isContainInDescription = item.description.toLowerCase().indexOf(patternToLower) >= 0;
                        if (isContainInName || isContainInDescription) {
                            isPass = true;
                        }

                        return isPass;
                    });

                return itemsToShow;
            }
        }

        return Catalog;
    })();

    let bookCatalog = (function () {
        class BookCatalog extends catalog {
            constructor(name) {
                super(name);
            }

            _validateAddingItem(item) {
                super._validateAddingItem(item);
                validator.validateIfUndefined(item.isbn, 'Isbn of adding book');
                validator.validateIfUndefined(item.genre, 'Genre of adding book');
            }

            getGenres() {
                let genresToShow = this._items
                    .map(item => item.genre)
                    .filter(function onlyUnique(value, index, self) {
                        return self.indexOf(value) === index;
                    });

                return genresToShow;
            }
        }

        return BookCatalog;
    })();

    let mediaCatalog = (function () {
        function sortingFunc(first, second) {
            if (first.duration < second.duration) {
                return 1;
            }

            if (first.duration > second.duration) {
                return -1;
            }

            if (first.id < second.id) {
                return -1;
            }

            if (first.id > second.id) {
                return 1;
            }
            else {
                return 0;
            }
        }

        class MediaCatalog extends catalog {
            constructor(name) {
                super(name);
            }

            _validateAddingItem(item) {
                super._validateAddingItem(item);
                validator.validateIfUndefined(item.rating, 'Rating of adding media');
                validator.validateIfUndefined(item.duration, 'Duration of adding media');
            }

            getTop(count) {
                validator.validateIfNumberInRange(count, 'Count', 1, Number.MAX_VALUE);
                let itemsToShow = this._items
                    .map(item => {
                        return {
                            id: item.id,
                            name: item.name
                        };
                    })
                    .slice(0, count);

                return itemsToShow;
            }

            getSortedByDuration() {
                let itemsToShow = this._items
                    .sort(sortingFunc);

                return itemsToShow;
            }
        }

        return MediaCatalog;
    })();

    return {
        getBook: function (name, isbn, genre, description) {
            return new book(name, isbn, genre, description);
        },
        getMedia: function (name, rating, duration, description) {
            return new media(name, rating, duration, description);
        },
        getBookCatalog: function (name) {
            return new bookCatalog(name);
        },
        getMediaCatalog: function (name) {
            return new mediaCatalog(name);
        }
    };
}

module.exports = solve;