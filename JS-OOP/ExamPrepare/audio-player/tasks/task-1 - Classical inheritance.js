function solve() {
    var module = (function () {
        var playable,
            validator,
            CONSTANTS = {
                MIN_POSITIVE_NUMBER: 1,
                MIN_TEXT_LENGTH: 3,
                MAX_TEXT_LENGTH: 25,
                MAX_RATING_NUM: 5,
                OPT_NAME: 'Value'

            },
            ERR_MSGS = {
                UNDEFINED: ' must not be an undefined',
                NULL: ' must not be null',
                OBJ: ' must be an object',
                STRING: ' must be a string',
                NUM: ' must be a number',
                RANGE: ' must be in a range ',
                POSITIVE_NUM: ' must be a positive number',
                NON_NEGATIVE_NUM: ' must be a non negative number',
                COUNT_PLAYABLES: 'Count of playables is less than wanted to show',
                PlAYLIST: ' must be an instance of Playlist'
            };


        function sortingFunction(first, second) {
            var firstParam,
                secondParam;

            if (first.title === undefined) {
                firstParam = 'name';
            }
            else {
                firstParam = 'title';
            }

            secondParam = 'id';

            if (first[firstParam] < second[firstParam]) {
                return - 1;
            }
            else if (first[firstParam] > second[firstParam]) {
                return 1;
            }

            if (first[secondParam] < second[secondParam]) {
                return - 1;
            }
            else if (first[secondParam] > second[secondParam]) {
                return 1;
            }
            else {
                return 0;
            }
        }

        function getElOfCollectionByInd(collection, ind) {
            if (ind < 0) {
                return null;
            }
            else {
                return collection[ind];
            }
        }

        function checkObjOrNumber(val) {
            if (typeof val === 'number') {
                return val;
            }
            else {
                return val.id;
            }
        }

        function checkForIndexOfElementInCollectionByID(collection, id) {
            var i, len;

            for (i = 0, len = collection.length; i < len; i += 1) {
                var currEl = collection[i];
                if (currEl.id === id) {
                    return i;
                }
            }

            return -1;
        }

        validator = {
            validateIfUndefined: function (val, name) {
                name = name || CONSTANTS.OPT_NAME;
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
                this.validateIfUndefined(val, name);

                if (typeof val !== 'object') {
                    throw new Error(name + ERR_MSGS.OBJ);
                }
            },
            validateIfString: function (val, name) {
                name = name || CONSTANTS.OPT_NAME;

                this.validateIfUndefined(val, name);

                if (typeof val !== 'string') {
                    throw new Error(name + ERR_MSGS.STRING);
                }

                this.validateIfStringLengthInRange(val, name);
            },
            validateIfStringLengthInRange: function (val, name) {
                name = name || CONSTANTS.OPT_NAME;

                if (val.length < CONSTANTS.MIN_TEXT_LENGTH || CONSTANTS.MAX_TEXT_LENGTH < val.length) {
                    throw new Error(name + ERR_MSGS.RANGE + CONSTANTS.MIN_TEXT_LENGTH + ' and ' + CONSTANTS.MAX_TEXT_LENGTH);
                }
            },
            validateIfNumber(val, name) {
                name = name || CONSTANTS.OPT_NAME;

                this.validateIfUndefined(val, name);

                if (typeof val !== 'number') {
                    throw new Error(name + ERR_MSGS.NUM);
                }
            },
            validateIfNonNegativeNumber: function (val, name) {
                name = name || CONSTANTS.OPT_NAME;
                this.validateIfNumber(val, name);

                if (val < 0) {
                    throw new Error(name + ERR_MSGS.NON_NEGATIVE_NUM);
                }
            },
            validateIfPositiveNumber: function (val, name) {
                name = name || CONSTANTS.OPT_NAME;

                this.validateIfNumber(val, name);

                if (val < CONSTANTS.MIN_POSITIVE_NUMBER) {
                    throw new Error(name + ERR_MSGS.POSITIVE_NUM);
                }
            },
            validateIfPositiveNumberInRange(val, max, name) {
                name = name || CONSTANTS.OPT_NAME;
                this.validateIfPositiveNumber(val, name);

                if (val < CONSTANTS.MIN_POSITIVE_NUMBER || max < val) {
                    throw new Error(name + ERR_MSGS.RANGE + CONSTANTS.MIN_POSITIVE_NUMBER + ' and ' + max);
                }
            },
            validatePageAndSize: function (page, size, length) {
                this.validateIfNonNegativeNumber(page, 'Page');
                this.validateIfPositiveNumber(size, 'Size');

                if (page * size > length) {
                    throw new Error(ERR_MSGS.COUNT_PLAYABLES);
                }
            },
            validateIfObjectWithID: function (value, name) {
                name = name || CONSTANTS.OPT_NAME;
                this.validateIfObject(value, name);
                this.validateIfUndefined(value.id);
            },
            validateIfPlaylist: function (value, name) {
                this.validateIfObjectWithID(value, name);

                if (!Array.isArray(value._playables)) {
                    throw new Error(name + ERR_MSGS.PlAYLIST);
                }
            }

        };

        player = (function () {
            var currPlayerID = 0,
                player = Object.create({});

            Object.defineProperty(player, 'init', {
                value: function (name) {
                    this.name = name;
                    this._playlists = [];
                    this._id = ++currPlayerID;
                    return this;
                }
            });

            Object.defineProperty(player, 'id', {
                get: function () {
                    return this._id;
                }
            });

            Object.defineProperty(player, 'name', {
                get: function () {
                    return this._name;
                },
                set: function (val) {
                    validator.validateIfString(val, 'Name of Player');

                    this._name = val;
                }
            });

            Object.defineProperty(player, 'addPlaylist', {
                value: function (val) {
                    validator.validateIfPlaylist(val, 'Playlist to Add');

                    this._playlists.push(val);
                    return this;
                }
            });

            Object.defineProperty(player, 'getPlaylistById', {
                value: function (val) {
                    var elToRerturn,
                        indexOfEl;

                    validator.validateIfNumber(val, 'ID of searching playlist');

                    indexOfEl = checkForIndexOfElementInCollectionByID(this._playlists, val);
                    elToRerturn = getElOfCollectionByInd(this._playlists, indexOfEl);

                    return elToRerturn;
                }
            });

            Object.defineProperty(player, 'removePlaylist', {
                value: function (val) {
                    var elToRemove,
                        id,
                        indexOfEl;
                    validator.validateIfUndefined(val, 'Passed value for remove');

                    id = checkObjOrNumber(val);
                    indexOfEl = checkForIndexOfElementInCollectionByID(this._playlists, id);
                    elToRemove = getElOfCollectionByInd(this._playlists, indexOfEl);
                    validator.validateIfNull(elToRemove, 'Element for remove');

                    this._playlists.splice(indexOfEl, 1);
                    return this;
                }
            });

            Object.defineProperty(player, 'listPlaylists', {
                value: function (page, size) {
                    validator.validatePageAndSize(page, size, this._playlists.length);

                    return this._playlists
                        .slice()
                        .sort(sortingFunction)
                        .splice(page * size, size);

                }
            });

            Object.defineProperty(player, 'contains', {
                value: function (playable, playlist) {
                    validator.validateIfObjectWithID(playable, 'Contains playable');
                    validator.validaIfPlaylist(playlist, 'Contains playlist');

                    if (playlist.getPlayableById(playable.id) === null) {
                        return false;
                    }
                    else {
                        return true;
                    }
                }
            });

            Object.defineProperty(player, 'search', {
                value: function (pattern) {
                    validator.validateIfString(pattern);

                    return this._playlists
                        .slice()
                        .filter(playlist => {
                            return playlist
                                ._playables
                                .slice()
                                .some(playable => {
                                    return playable.title.toLowerCase().indexOf(pattern.toLowerCase()) >= 0;
                                });
                        })
                        .map(element => {
                            return {
                                id: element.id,
                                name: element.name
                            };
                        });
                }
            });

            return player;
        } ());

        playlist = (function () {
            var currPlaylistID = 0,
                playlist;

            playlist = Object.create({});

            Object.defineProperty(playlist, 'init', {
                value: function (name) {
                    this.name = name;
                    this._id = ++currPlaylistID;
                    this._playables = [];
                    return this;
                }
            });

            Object.defineProperty(playlist, 'id', {
                get: function () {
                    return this._id;
                }
            });

            Object.defineProperty(playlist, 'name', {
                get: function () {
                    return this._name;
                },
                set: function (val) {
                    validator.validateIfString(val, 'Name of Playlist');

                    this._name = val;
                }
            });

            Object.defineProperty(playlist, 'addPlayable', {
                value: function (playable) {
                    validator.validateIfObjectWithID(playable, 'Playable for add');

                    this._playables.push(playable);
                    return this;
                }
            });

            Object.defineProperty(playlist, 'getPlayableById', {
                value: function (id) {
                    var indexOfEl, elToReturn;
                    validator.validateIfNumber(id, 'ID for searching');

                    indexOfEl = checkForIndexOfElementInCollectionByID(this._playables, id);
                    elToReturn = getElOfCollectionByInd(this._playables, indexOfEl);

                    return elToReturn;
                }
            });

            Object.defineProperty(playlist, 'removePlayable', {
                value: function (val) {
                    var id,
                        indexOfEl,
                        elToRemove;
                    validator.validateIfUndefined(val);

                    id = checkObjOrNumber(val);

                    indexOfEl = checkForIndexOfElementInCollectionByID(this._playables, id);
                    elToRemove = getElOfCollectionByInd(this._playables, indexOfEl);
                    validator.validateIfNull(elToRemove, 'Playable with passed ID');

                    this._playables.splice(indexOfEl, 1);
                    return this;
                }
            });

            Object.defineProperty(playlist, 'listPlayables', {
                value: function (page, size) {
                    validator.validatePageAndSize(page, size, this._playables.length);

                    return this._playables
                        .slice()
                        .sort(sortingFunction)
                        .splice(page * size, size);
                }
            });

            return playlist;
        } ());

        playable = (function () {
            var currPlayableID = 0,
                playable;

            playable = Object.create({});
            Object.defineProperty(playable, 'init', {
                value: function (title, author) {
                    this.title = title;
                    this.author = author;
                    this._id = ++currPlayableID;
                    return this;
                }
            });

            Object.defineProperty(playable, 'id', {
                get: function () {
                    return this._id;
                }
            });

            Object.defineProperty(playable, 'title', {
                get: function () {
                    return this._title;
                },
                set: function (val) {
                    validator.validateIfString(val, 'Title of Playable');

                    this._title = val;
                }
            });

            Object.defineProperty(playable, 'author', {
                get: function () {
                    return this._author;
                },
                set: function (val) {
                    validator.validateIfString(val, 'Author of Playable');

                    this._author = val;
                }
            });

            Object.defineProperty(playable, 'play', {
                value: function () {
                    return this.id + '. ' + this.title + ' - ' + this.author;
                }
            });

            return playable;
        } ());

        audio = (function (parent) {
            var audio;
            audio = Object.create(parent);

            Object.defineProperty(audio, 'init', {
                value: function (title, author, length) {
                    parent.init.call(this, title, author);
                    this.length = length;
                    return this;
                }
            });

            Object.defineProperty(audio, 'length', {
                get: function () {
                    return this._length;
                },
                set: function (val) {
                    validator.validateIfPositiveNumber(val, 'Audio Length');
                    this._length = val;
                }
            });

            Object.defineProperty(audio, 'play', {
                value: function () {
                    return parent.play.call(this) + ' - ' + this.length;
                }
            });

            return audio;
        } (playable));

        video = (function (parent) {
            var video;
            video = Object.create(parent);

            Object.defineProperty(video, 'init', {
                value: function (title, author, imdbRating) {
                    parent.init.call(this, title, author);
                    this.imdbRating = imdbRating;
                    return this;
                }
            });

            Object.defineProperty(video, 'imdbRating', {
                get: function () {
                    return this._imdbRating;
                },
                set: function (val) {
                    validator.validateIfPositiveNumberInRange(val, CONSTANTS.MAX_RATING_NUM, 'IMDB Video Rating');

                    this._imdbRating = val;
                }
            });

            Object.defineProperty(video, 'play', {
                value: function () {
                    return parent.play.call(this) + ' - ' + this.imdbRating;
                }
            });

            return video;
        } (playable));

        return {
            getPlayer: function (name) {
                return Object.create(player).init(name);
            },
            getPlaylist: function (name) {
                return Object.create(playlist).init(name);
            },
            getAudio: function (title, author, length) {
                return Object.create(audio).init(title, author, length);
            },
            getVideo: function (title, author, imdbRating) {
                return Object.create(video).init(title, author, imdbRating);
            }
        };
    } ());

    return module;
}

module.exports = solve;