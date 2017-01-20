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
                            }
                            catch (err) {
                                app.notificator.error(err.message);
                                isValid = false;
                            }

                            if (isValid) {
                                app.usersModel.register(user)
                                    .then((res) => {
                                        app.notificator.success('Registered Successfully');
                                        window.location.replace('#/login');
                                    }, (err) => {
                                        app.notificator.error(err);
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
                                app.notificator.success(`${res.username} signed in!`);
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
    }

    app.usersController = new UsersController();
})();