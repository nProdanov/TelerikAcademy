var app = app || {};

(function () {
    app.routing = function () {
        navigo = new Navigo(null, true);

        navigo
        .on('/home', () => {
            app.pageController.homePage();
        })
        .on('/register', () =>{
            app.usersController.registerUser();
        })
        .on('/login', ()=>{
            app.usersController.loginUser();
        })
        .on('/logout', ()=>{
            app.usersController.logoutUser();
        })
        .on('', ()=>{
            window.location.replace('#/home');
        })
        .resolve();
    };
})();