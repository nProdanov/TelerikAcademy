var app = app || {};

(function () {
    class Notificator {
        success(msg) {
            toastr.success(msg);
        }

        error(msg) {
            toastr.error(msg);
        }
    }

    app.notificator = new Notificator();
})();