var app = app || {};

(function () {
    app.usersController.isUserLoggedIn()
        .then((isLoggedIn)=>{
            if(isLoggedIn){
                $('#page').addClass('logged-in');
            }

            app.routing();
        });
    

    
})();