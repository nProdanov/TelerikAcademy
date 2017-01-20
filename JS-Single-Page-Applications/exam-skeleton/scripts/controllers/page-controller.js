var app = app || {};

(function () {
    class PageController {
        homePage() {
            app.templater.get('home-page')
                .then((template) => {
                    $('#content').html(template());
                });
        }
    }

    app.pageController = new PageController();
})();