var app = app || {};

(function () {
    app.routing = function () {
        navigo = new Navigo(null, true);

        navigo
            .on('/home/filter=:pattern', (params) => {
                debugger;
                app.materialsController.searchMaterial(params.pattern);
            })
            .on('/home', () => {
                app.materialsController.loadAllMaterials();
            })
            .on('/register', () => {
                app.usersController.registerUser();
            })
            .on('/login', () => {
                app.usersController.loginUser();
            })
            .on('/logout', () => {
                app.usersController.logoutUser();
            })
            .on('/add-material', () => {
                if ($('#page').hasClass('logged-in')) {
                    app.materialsController.addMaterial();

                }
                else {
                    window.location.replace('#/home');
                }
            })
            .on('/materials/:id', (params) => {
                app.materialsController.getDetailedMaterialsInfo(params.id);
            })
            .on('/profiles/:name', (params) => {
                app.usersController.getUserProfile(params.name);
            })
            .on('/search', () => {
                app.materialsController.getSearchPage();
            })
            .on('/my-profile', () => {
                if ($('#page').hasClass('logged-in')) {
                    app.usersController.getMyProfile();
                }
                else {
                    window.location.replace('#/home');
                }
            })
            .on('', () => {
                window.location.replace('#/home');
            })
            .resolve();
    };
})();