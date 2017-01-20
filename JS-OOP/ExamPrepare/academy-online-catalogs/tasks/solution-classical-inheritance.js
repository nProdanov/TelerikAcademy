'use strict';
function solve() {
    var Item,
        Book,
        Media,
        Catalog,
        BookCatalog,
        MediaCatalog,
        validator,
        CONSTANTS = {
            OPT_NAME: 'Value',
            MIN_NAME_LENGTH: 2,
            MIN_DURATION: 1,
            MIN_GENRE_LENGTH: 2,
            MIN_RAITNG: 1,
            MAX_GENRE_LENGTH: 20,
            MAX_RATING: 5,
            MAX_NAME_LENGTH: 40,
            POSSIBLE_ISBN_LENGTH: [10, 13],

        },
        ERR_MSGS = {
            UNDEFINED: ' must not be an undefined',
            NULL: ' must not be null',
            STRING: ' must be a string',
            OBJECT: ' must be an object',
            NUM: ' must be a number',
            RANGE: ' must be in a range ',
            ONLY_DIGITS: ' must contains only digits',
            ISBN_LENGTH: 'ISBN length must be exactly 10 or 13 symbols',

        };

    function compare(firstParam, isFirstDescending, secondParam) {
        return function (first, second) {
            if (isFirstDescending) {
                if (first[firstParam] < second[firstParam]) {
                    return -1;
                }
                else if (first[firstParam] > second[firstParam]) {
                    return 1;
                }
            }

            if (second !== undefined) {
                if (first[secondParam] < second[secondParam]) {
                    return -1;
                }
                else if (first[secondParam] > second[secondParam]) {
                    return 1;
                }
            }

            return 0;
        };
    }


    function functionForFindItems(obj) {
        return function (el) {
            var isPass = true;

            for (let attr in obj) {
                if (obj[attr] !== el[attr]) {
                    isPass = false;
                    break;
                }
            }
            return isPass;
        };
    }

    validator = (function () {
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

    Item = (function (parent) {
        var currItemId = 0,
            item = Object.create(parent);

        Object.defineProperty(item, 'init', {
            value: function (name, description) {
                this.name = name;
                this.description = description;
                this._id = ++currItemId;

                return this;
            }
        });

        Object.defineProperty(item, 'name', {
            get: function () {
                return this._name;
            },
            set: function (val) {
                validator.validateIfNameValid(val);
                this._name = val;
            }
        });

        Object.defineProperty(item, 'description', {
            get: function () {
                return this._description;
            },
            set: function (val) {
                validator.validateIfValidString(val, 'Description of item');
                this._description = val;
            }
        });

        Object.defineProperty(item, 'id', {
            get: function () {
                return this._id;
            }
        });

        return item;
    })({});

    Book = (function (parent) {
        var book = Object.create(parent);

        Object.defineProperty(book, 'init', {
            value: function (name, isbn, genre, description) {
                parent.init.call(this, name, description);
                this.genre = genre;
                this.isbn = isbn;

                return this;
            },
        });

        Object.defineProperty(book, 'isbn', {
            get: function () {
                return this._isbn;
            },
            set: function (val) {
                validator.validateISBN(val);
                this._isbn = val;
            }
        });

        Object.defineProperty(book, 'genre', {
            get: function () {
                return this._genre;
            },
            set: function (val) {
                validator.validateIfValidString(val, 'Genre');
                validator.validateIfNumberInRange(
                    val.length,
                    'Genre length',
                    CONSTANTS.MIN_GENRE_LENGTH,
                    CONSTANTS.MAX_GENRE_LENGTH);

                this._genre = val;
            }
        });

        return book;
    })(Item);

    Media = (function (parent) {
        var media = Object.create(parent);

        Object.defineProperty(media, 'init', {
            value: function (name, rating, duration, description) {
                parent.init.call(this, name, description);
                this.rating = rating;
                this.duration = duration;

                return this;
            },
        });

        Object.defineProperty(media, 'duration', {
            get: function () {
                return this._duration;
            },
            set: function (val) {
                validator.validateIfValidNumber(val, 'Duration');
                validator.validateIfNumberInRange(
                    val,
                    'Duration',
                    CONSTANTS.MIN_DURATION,
                    Number.MAX_VALUE);

                this._duration = val;
            }
        });

        Object.defineProperty(media, 'rating', {
            get: function () {
                return this._rating;
            },
            set: function (val) {
                validator.validateIfValidNumber(val, 'Rating');
                validator.validateIfNumberInRange(
                    val,
                    'Rating',
                    CONSTANTS.MIN_RAITNG,
                    CONSTANTS.MAX_RATING);

                this._rating = val;
            }
        });

        return media;
    })(Item);

    Catalog = (function (parent) {
        var currCatalogId = 0,
            catalog = Object.create(parent);

        Object.defineProperty(catalog, 'init', {
            value: function (name) {
                this.name = name;
                this._id = ++currCatalogId;
                this._items = [];
                return this;
            },
        });

        Object.defineProperty(catalog, 'name', {
            get: function () {
                return this._name;
            },
            set: function (val) {
                validator.validateIfNameValid(val);

                this._name = val;
            }
        });

        Object.defineProperty(catalog, 'id', {
            get: function () {
                return this._id;
            },
        });

        Object.defineProperty(catalog, 'items', {
            get: function () {
                // this._items.sort(compare);
                return this._items;
            },
        });

        Object.defineProperty(catalog, 'add', {
            value: function (...args) {
                var that = this;
                if (Array.isArray(args[0])) {
                    args = args[0];
                }
                validator.validateIfUndefined(args);

                if (args.length === 0) {
                    throw new Error('Passing at least one item to add is required');
                }

                args.forEach(function (item) {
                    that.validateAddingItem(item, 'Adding item');
                    that._items.push(item);
                });

                return this;
            },
        });

        Object.defineProperty(catalog, 'validateAddingItem', {
            value: function (val, name) {
                name = name || CONSTANTS.OPT_NAME;
                validator.validateIfUndefined(val, name);
                validator.validateIfObject(val, name);
                validator.validateIfUndefined(val.id, 'Id of Item');
                validator.validateIfUndefined(val.name, 'Name of Item');
                validator.validateIfUndefined(val.description, 'Description of Item');
            }
        });

        Object.defineProperty(catalog, 'find', {
            value: function (val) {
                var itemsToShow;
                validator.validateIfUndefined(val, 'Options for find');
                validator.validateIfNull(val, 'Options for find');

                if (typeof val === 'object') {
                    itemsToShow = this.items.filter(functionForFindItems(val));

                    return itemsToShow;
                }
                else {
                    validator.validateIfValidNumber(val, 'Id for find');
                    itemsToShow = this.items.filter(item => { return item.id === val; });

                    if (itemsToShow.length !== 0) {
                        return itemsToShow[0];
                    }
                    else {
                        return null;
                    }
                }
            },
        });

        Object.defineProperty(catalog, 'search', {
            value: function (pattern) {
                var itemsToShow;
                validator.validateIfValidString(pattern);
                itemsToShow = this.items.filter(el => {
                    return (el.name.toLowerCase().indexOf(pattern.toLowerCase()) >= 0 ||
                        el.description.toLowerCase().indexOf(pattern.toLowerCase()) >= 0);
                });

                return itemsToShow;
            },
        });

        return catalog;
    })({});

    BookCatalog = (function (parent) {
        var bookCatalog = Object.create(parent);

        Object.defineProperty(bookCatalog, 'init', {
            value: function (name) {
                parent.init.call(this, name);

                return this;
            },
        });

        Object.defineProperty(bookCatalog, 'validateAddingItem', {
            value: function (val, name) {
                parent.validateAddingItem.call(this, val, name);
                validator.validateIfUndefined(val.isbn, 'ISBN of adding book');
                validator.validateIfUndefined(val.genre, 'Genre of adding book');
            },
        });

        Object.defineProperty(bookCatalog, 'getGenres', {
            value: function () {
                var itemsToShow = [];

                itemsToShow = this.items
                    .map(book => { return book.genre; })
                    .filter((genre, ind) => itemsToShow.indexOf(genre, ind + 1) < 0);

                return itemsToShow;
            },
        });

        return bookCatalog;
    })(Catalog);

    MediaCatalog = (function (parent) {
        var mediaCatalog = Object.create(parent);

        Object.defineProperty(mediaCatalog, 'init', {
            value: function (name) {
                parent.init.call(this, name);
                return this;
            },
        });

        Object.defineProperty(mediaCatalog, 'validateAddingItem', {
            value: function (val, name) {
                parent.validateAddingItem.call(this, val, name);
                validator.validateIfUndefined(val.duration, 'Duration of media to add');
                validator.validateIfUndefined(val.rating, 'Rating of media to add');
            },
        });

        Object.defineProperty(mediaCatalog, 'getTop', {
            value: function (count) {
                var itemsToShow;

                validator.validateIfValidNumber(count, 'Count');
                if (count < 1) {
                    throw new Error('Count must be greater than 1');
                }

                itemsToShow = this._items
                    .slice()
                    .sort(compare('rating'))
                    .slice(0, count)
                    .map(item => {
                        return {
                            id: item.id,
                            name: item.name
                        };
                    });

                return itemsToShow;
            },
        });

        Object.defineProperty(mediaCatalog, 'getSortedByDuration', {
            value: function () {
                var itemsToShow;

                itemsToShow = this._items
                    .slice()
                    .sort(compare('duration', 'id', true));

                return itemsToShow;
            },
        });

        return mediaCatalog;
    })(Catalog);

    return {
        getBook: function (name, isbn, genre, description) {
            return Object.create(Book).init(name, isbn, genre, description);
        },
        getMedia: function (name, rating, duration, description) {
            return Object.create(Media).init(name, rating, duration, description);
        },
        getBookCatalog: function (name) {
            return Object.create(BookCatalog).init(name);
        },
        getMediaCatalog: function (name) {
            return Object.create(MediaCatalog).init(name);
        }
    };
}

var book, catalog, books = [], findResult;
catalog = solve().getBookCatalog('catalog');
var b1 = {
    id: (1),
    name: 'Ko staa e manqk',
    isbn: '1234567890',
    genre: ('generic'),
    description: 'utils.valid.getDescription()'
};

catalog.items.push(b1);
for (let i = 0; i < 10; i += 1) {
    book = {
        id: (i + 10),
        name: 'myName',
        isbn: '1234567890',
        genre: ('generic' + i),
        description: 'utils.valid.getDescription()'
    };

    books.push(book);
    catalog.items.push(book);
}
let pattern = b1.description.substr(3, 6);
findResult = catalog.search(pattern);

module.exports = solve;