var app = app || {};

(function () {
    function getReadableMaterialStatus(status, data) {
        switch (status) {
            case 'want-to-watch':
                data.want = false;
                data.watching = true;
                data.watched = true;
                return 'Want to watch';
            case 'watching':
                data.want = true;
                data.watching = false;
                data.watched = true;
                return 'Currently watching';
            case 'watched':
                data.want = true;
                data.watching = true;
                data.watched = false;
                return 'Already watched';
        }
    }

    class MaterialsController {
        loadAllMaterials() {
            let data;
            app.materialsModel.getAll()
                .then((res) => {
                    data = { materials: res.result };
                    return app.templater.get('home-page');
                })
                .then((template) => {
                    $('#content').html(template(data));
                });
        }

        getSearchPage(){
            app.templater.get('search-page')
                .then((template)=>{
                    $('#content').html(template());
                })
                .then(()=>{
                    $('#btn-search').on('click', function(){
                        let searchpattern = $('#tb-search').val();
                        debugger;
                        window.location.replace(`#/home/?filter=${searchpattern}`);
                    });
                });
        }

        searchMaterial(param){
            debugger;
            console.log(param);
        }

        getDetailedMaterialsInfo(materialId) {
            let data, isLoggedIn;
            app.materialsModel.getMaterialInfo(materialId)
                .then((res) => {
                    data = res.result;
                    isLoggedIn = $('#page').hasClass('logged-in');
                    if (isLoggedIn) {
                        return app.usersModel.getMyLinkedMaterials();
                    }
                })
                .then((res) => {
                    if (isLoggedIn) {
                        let usersMaterials = res.result;
                        let foundMaterial = usersMaterials.find((mat) => {
                            return mat.id === data.id;
                        });
                        if (foundMaterial) {
                            data.status = getReadableMaterialStatus(foundMaterial.category, data);
                        }
                        else {
                            data.status = 'No current status';
                            data.want = true;
                            data.watching = true;
                            data.watched = true;
                        }
                    }
                    return app.templater.get('material-single-page');

                })
                .then((template) => {
                    $('#content').html(template(data));
                })
                .then(() => {
                    $('.status-changer').on('click', '.change-status', function () {
                        let status = $(this).attr('data-status');
                        let materialId = $('#title').attr('data-id');
                        app.usersModel.changeMaterialStatus(materialId, status)
                            .then(() => {
                                location.reload();
                            });
                    });

                    $('#send-comment').on('click', function () {
                        let comment = $('#tb-comment').val();
                        let materialID = $('#title').attr('data-id');
                        app.usersModel.addCommentToMaterial(materialID, comment)
                            .then((res) => {
                                location.reload();
                            });
                    });
                });
        }

        addMaterial() {
            app.templater.get('add-material')
                .then((template) => {
                    $('#content').html(template());
                })
                .then(() => {
                    $('#btn-add-material').on('click', function () {
                        let title = $('#tb-title').val();
                        let description = $('#tb-description').val();
                        let img = $('tb-img').val();
                        let material = { title, description, img };

                        app.usersModel.addMaterial(material)
                            .then((res)=>{
                                let resMaterial = res.result;
                               window.location.replace(`#/materials/${resMaterial.id}`);
                            });

                    });
                });
        }
    }



    app.materialsController = new MaterialsController();
})();