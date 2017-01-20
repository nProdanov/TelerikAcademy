var app = app || {};

(function () {
    class MaterialsModel{
        getAll(){
            let promise = new Promise((resolve, reject)=>{
                let url = 'api/materials';

                app.requester.get(url)
                    .then(resolve, reject);
            });

            return promise;
        }

        getMaterialInfo(id){
            let promise = new Promise((resolve, reject)=>{
                let url = `api/materials/${id}`;

                app.requester.get(url)
                    .then(resolve, reject);
            });

            return promise;
        }
    }

    app.materialsModel = new MaterialsModel();
})();