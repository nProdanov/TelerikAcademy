var app = app || {};

(function () {
    const STORAGE_AUTH_KEY = 'STORAGE_AUTH_KEY';
    const STORAGE_USERNAME = 'STORAGE_USERNAME';

    function getReadyRegisterLoginOptions(user) {
        let options = {
            data: {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            }
        };

        return options;
    }

    class UsersModel {
        register(user) {
            let promise = new Promise((resolve, reject) => {
                let url = 'api/users',
                    options = {
                        data: {
                            username: user.username,
                            password: user.password
                        }
                    };
                app.requester.post(url, options)
                    .then((res) => {
                        resolve(res);
                    }, (err) => {
                        reject(err);
                    });
            });

            return promise;
        }

        login(user) {
            let promise = new Promise((resolve, reject) => {
                let url = 'api/users/auth';
                let options = {
                    data: {
                        username: user.username,
                        password: user.password

                    }
                };

                app.requester.put(url, options)
                    .then((res) => {
                        localStorage.setItem(STORAGE_AUTH_KEY, res.result.authKey);
                        localStorage.setItem(STORAGE_USERNAME, res.result.username);
                        resolve(res);
                    }, (err) => {
                        reject(err);
                    });
            });

            return promise;
        }

        logout() {
            let promise = new Promise((resolve, reject) => {
                localStorage.removeItem(STORAGE_AUTH_KEY);
                localStorage.removeItem(STORAGE_USERNAME);
                resolve();
            });

            return promise;
        }

        isLoggedIn() {
            let promise = new Promise((resolve, reject) => {
                resolve(!!localStorage.getItem(STORAGE_AUTH_KEY));
            });

            return promise;
        }

        getProfileInfo(name) {
            let promise = new Promise((resolve, reject) => {
                let url = `api/profiles/${name}`;

                app.requester.get(url)
                    .then(resolve, reject);
            });

            return promise;
        }

        getMyLinkedMaterials() {
            let promise = new Promise((resolve, reject) => {
                let url = 'api/user-materials';
                let options = {
                    headers: {
                        'x-auth-key': localStorage.getItem(STORAGE_AUTH_KEY)
                    }
                };
                app.requester.get(url, options)
                    .then(resolve, reject);
            });

            return promise;
        }

        getLoggedUsername() {
            let promise = new Promise((resolve, reject) => {
                resolve(localStorage.getItem(STORAGE_USERNAME));
            });

            return promise;
        }

        changeMaterialStatus(materialId, status) {
            let promise = new Promise((resolve, reject) => {
                let url = 'api/user-materials';
                let headers = { 'x-auth-key': localStorage.getItem(STORAGE_AUTH_KEY) };
                let data = {
                    id: materialId,
                    category: status
                };

                let options = { data, headers };

                app.requester.put(url, options)
                    .then(resolve, reject);
            });

            return promise;
        }

        addCommentToMaterial(materialId, comment) {
            let promise = new Promise((resolve, reject) => {
                let url = `api/materials/${materialId}/comments`;
                let headers = { 'x-auth-key': localStorage.getItem(STORAGE_AUTH_KEY) };
                let data = { commentText: comment };

                let options = { data, headers };

                app.requester.put(url, options)
                    .then(resolve, reject);
            });

            return promise;
        }

        addMaterial(material) {
            let promise = new Promise((resolve, reject) => {
                let url = 'api/materials';
                let headers = { 'x-auth-key': localStorage.getItem(STORAGE_AUTH_KEY) };
                let options = {
                    headers,
                    data: material
                };

                app.requester.post(url, options)
                    .then(resolve, reject);
            });

            return promise;
        }
    }

    app.usersModel = new UsersModel();
})();