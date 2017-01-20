var app = app || {};
var handlebars = window.handlebars || window.Handlebars;

(function () {
    class Templater {
        get(name) {
            let url = `./templates/${name}.handlebars`;
            var promise = new Promise((resolve, reject) => {
                $.get(url, (html) => {
                    let template = handlebars.compile(html);
                    resolve(template);
                });
            });

            return promise;
        }
    }

    app.templater = new Templater();
})();