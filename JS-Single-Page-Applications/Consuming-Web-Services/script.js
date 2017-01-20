(function () {
    let url = 'http://localhost:8886/api/people';

    let db = (function () {
        function save(data) {
            let promise = new Promise(function (resolve, reject) {
                $.ajax(url, {
                    method: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(data),
                    success: function (response) {
                        resolve(response.data);
                    },
                    error: function (err) {
                        let errMessage = JSON.parse(err.responseText).data.err;
                        reject(errMessage);
                    }
                });
            });

            return promise;
        }

        function load() {
            let promise = new Promise(function (resolve, reject) {
                $.getJSON(url, function (data) {
                    resolve(data);
                })
                    .error(function (err) {
                        reject({
                            message: JSON.parse(err.responseText).err
                        });
                    });
            });

            return promise;
        }

        function searchById(id) {
            let promise = new Promise(function (resolve, reject) {
                $.ajax(url + `/${id}`, {
                    method: 'GET',
                    contentType: 'application/json',
                    success: function (response) {
                        resolve(response.data);
                    },
                    error: function (err) {
                        let errMessage = JSON.parse(err.responseText).data.errMessage;
                        reject(errMessage);
                    }
                });
            });

            return promise;
        }

        return {
            save, load, searchById
        };
    })();

    let peopleList = $('#people-list');
    let personTemplate = $('<li />')
        .addClass('person-item');

    db.load()
        .then(function (data) {
            peopleList.html('');
            data.data.forEach(item => {
                let currLi = personTemplate.clone(true);
                currLi.html(`Name: ${item.name}, Age: ${item.age}`);
                currLi.appendTo(peopleList);
            });
        });

    let $inputName = $('#input-name');
    let $inputAge = $('#input-age');
    let $messageBox = $('#message-box');

    $('#save-btn').on('click', function () {
        let name = $inputName.val();
        let age = +$inputAge.val();

        $inputName.val('');
        $inputAge.val('');

        let data = {
            name, age
        };

        db.save({ name, age })
            .then((item) => {
                let currLi = personTemplate.clone(true);
                currLi.html(`Name: ${item.name}, Age: ${item.age}`);
                currLi.appendTo(peopleList);
                $messageBox.html('Item created Successfuly')
                    .fadeIn(2000, function () {
                        $messageBox.fadeOut(2000, function () {
                            $messageBox.html('');
                        });
                    });
            },
            function (err) {
                $messageBox.html(err)
                    .fadeIn(2000, function () {
                        $messageBox.fadeOut(2000, function () {
                            $messageBox.html('');
                        });
                    });
            });
    });

    let $inputID = $('#input-id');
    let $itemByID = $('#item-by-id');
    $('#btn-search-id').on('click', function () {
        let id = $inputID.val();
        $inputID.val('');
        db.searchById(id)
            .then(function (data) {
                $itemByID.html(`Name: ${data.name}, Age: ${data.age}`);
            },
            function (err) {
                $itemByID.html(err);
            });
    });
})();