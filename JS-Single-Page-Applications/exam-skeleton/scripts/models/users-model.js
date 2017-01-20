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
                let url = 'api/users';
                let registerOptions = getReadyRegisterLoginOptions(user);
                app.requester.post(url, registerOptions)
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
                let loginOptions = getReadyRegisterLoginOptions(user);

                app.requester.put(url, loginOptions)
                    .then((res) => {
                        localStorage.setItem(STORAGE_AUTH_KEY, res.authKey);
                        localStorage.setItem(STORAGE_USERNAME, res.username);
                        resolve(res);
                    }, (err) => {
                        reject(err);
                    });
            });

            return promise;
        }

        logout(){
            let promise = new Promise((resolve, reject)=>{
                localStorage.removeItem(STORAGE_AUTH_KEY);
                localStorage.removeItem(STORAGE_USERNAME);
                resolve();
            });

            return promise;
        }

        isLoggedIn(){
            let promise = new Promise((resolve, reject)=>{
                resolve(!!localStorage.getItem(STORAGE_AUTH_KEY));
            });

            return promise;
        }
    }

    app.usersModel = new UsersModel();
})();