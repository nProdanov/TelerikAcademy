(function () {
    let getPosition = function () {
        let posPromise = new Promise(function (resolve, reject) {
            navigator.geolocation.getCurrentPosition((pos) => {
                resolve(pos);
            });
        });

        function parseCoords(pos) {
            return {
                latitude: pos.coords.latitude,
                longitude: pos.coords.longitude
            };
        }

        function setMapSrc(coords) {
            let src = `http://maps.googleapis.com/maps/api/staticmap?center=${coords.latitude},${coords.longitude}&zoom=16&size=500x500&sensor=false`;
            let map = document.getElementById('map');
            map.setAttribute('src', src);
        }

        posPromise
            .then(parseCoords)
            .then(setMapSrc);
    };

    let button = document.getElementById('get-position');
    button.addEventListener('click', getPosition);

})();
