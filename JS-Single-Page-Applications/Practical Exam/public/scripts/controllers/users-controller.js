var app = app || {};

(function () {
    class UsersController {
        registerUser() {
            app.templater.get('register-page')
                .then((template) => {
                    $('#content').html(template());
                })
                .then(() => {
                    $('#btn-register').on('click', function () {
                        let pass = $('#tb-password').val();
                        let passConfirm = $('#tb-password-confirm').val();
                        if (pass === passConfirm) {
                            let user = {
                                username: $('#tb-username').val(),
                                password: $('#tb-password').val()
                            },
                                isValid = true;

                            try {
                                app.validator.validateUsername(user.username);
                                app.validator.validatePassword(user.password);
                            }
                            catch (err) {
                                app.notificator.error(err.message);
                                isValid = false;
                            }

                            if (isValid) {
                                app.usersModel.register(user)
                                    .then((res) => {
                                        app.notificator.success(`${res.result.username} registered Successfully`);
                                        window.location.replace('#/login');
                                    }, (err) => {
                                        let message = JSON.parse(err.responseText).result.err;
                                        app.notificator.error(message);
                                    },
                                    function (err) {
                                        console.log(err);
                                    });
                            }

                        }
                        else {
                            app.notificator.error('Passwords dont match');
                        }
                    });
                });
        }

        loginUser() {
            app.templater.get('login-page')
                .then((template) => {
                    $('#content').html(template());
                })
                .then(() => {
                    $('#btn-login').on('click', function () {
                        let user = {
                            username: $('#tb-username').val(),
                            password: $('#tb-password').val()
                        };
                        app.usersModel.login(user)
                            .then((res) => {
                                $('#page').addClass('logged-in');
                                app.notificator.success(`${res.result.username} signed in!`);
                                window.location.replace('#/home');
                            },
                            function (err) {
                                app.notificator.error('Invalid username or password');
                            });
                    });
                });
        }

        logoutUser() {
            app.usersModel.logout()
                .then(() => {
                    $('#page').removeClass('logged-in');
                    app.notificator.success('Sign out successfull');
                    window.location.replace('#/home');
                });
        }

        isUserLoggedIn() {
            return app.usersModel.isLoggedIn();
        }

        getUserProfile(name) {
            let data;
            app.usersModel.getProfileInfo(name)
                .then((res) => {
                    let userInfo = res.result,
                        userMaterials = userInfo.userMaterials,
                        materialsWant = userMaterials.filter((mat) => {
                            return mat.category === 'want-to-watch';
                        }),
                        materialsWatching = userMaterials.filter((mat) => {
                            return mat.category === 'watching';
                        }),
                        materialsWatched = userMaterials.filter((mat) => {
                            return mat.category === 'watched';
                        });
                    data = {
                        name: userInfo.username,
                        materialsWant,
                        materialsWatched,
                        materialsWatching
                    };

                    return app.templater.get('profile-page');
                })
                .then((template) => {
                    $('#content').html(template(data));
                });
        }

        getMyProfile() {
            let userName, data;
            app.usersModel.getLoggedUsername()
                .then((resUsername) => {
                    userName = resUsername;

                    return app.usersModel.getMyLinkedMaterials();
                })
                .then((res) => {
                    let userMaterials = res.result,
                        materialsWant = userMaterials.filter((mat) => {
                            return mat.category === 'want-to-watch';
                        }),
                        materialsWatching = userMaterials.filter((mat) => {
                            return mat.category === 'watching';
                        }),
                        materialsWatched = userMaterials.filter((mat) => {
                            return mat.category === 'watched';
                        });
                    data = {
                        name: userName,
                        materialsWant,
                        materialsWatching,
                        materialsWatched
                    };
                    return app.templater.get('my-profile');
                })
                .then((template)=>{
                    $('#content').html(template(data));
                });
        }
    }

    app.usersController = new UsersController();
})();