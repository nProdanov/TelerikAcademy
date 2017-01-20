var app = app || {};

(function () {
    function send(method, url, options) {
        options = options || {};
        debugger;
        let headers = options.headers || {},
            data = options.data || undefined;

        let promise = new Promise((resolve, reject) => {
            $.ajax(url, {
                method,
                contentType: 'application/json',
                data: JSON.stringify(data),
                headers,
                success: function (response) {
                    resolve(response);
                },
                error: function (err) {
                    reject(err);
                }

            });
        });

        return promise;
    }

    class Requester {

        get(url, options) {
            return send('GET', url, options);
        }

        post(url, options) {
            return send('POST', url, options);
        }

        put(url, options) {
            return send('PUT', url, options);
        }

        del(url, options) {
            return send('POST', url, options);
        }
    }

    app.requester = new Requester();
})();