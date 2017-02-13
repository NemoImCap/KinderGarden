var core = angular.module("core", ["LocalStorageModule", "smart-table", "ngHelperBusy", 'ui.bootstrap'])
    .constant('keyCodes', {
        esc: 27,
        space: 32,
        enter: 13,
        tab: 9,
        backspace: 8,
        shift: 16,
        ctrl: 17,
        alt: 18,
        capslock: 20,
        numlock: 144
    }).constant('templates', {
        Domain: '',
    })
    .constant("appSettings", {
        "serviceUrl": function (currentUrl) {
            var url = currentUrl.indexOf("localhost") > -1 ? "http://localhost:57084/" : "";
            return url;
        },
        //Kindergarten
        "GetKindergartens": "api/Kindergarden/GetKinderGardens/?",
        "GetKindergartensNumbers": 'api/Kindergarden/GetKindergartensNumbers',
        "CreateKindergarten": 'api/Kindergarden/CreateGarten',
        "DeleteKindergarten": 'api/Kindergarden/DeleteKindergaten',
        "UpdateKindergarten": 'api/Kindergarden/UpdateKindergarten',
        //Children
        "CreateChild": 'api/Children/CreateChild',
        "GetChildren": 'api/Children/GetChildren/?',
        "UpdateChild": 'api/Children/UpdateChild/',
        "DeleteChild": 'api/Children/DeleteChild/'
    });

//Services

core.service('api', Api);
core.service('spinnerService', spinnerService);
core.service('kindergartenService', kindergartenService);
core.service('childrenService', childrenService);

spinnerService.$inject = ['$timeout', '$busy'];
Api.$inject = ['$http', '$q', 'appSettings', '$window'];
childrenService.$inject = ["api", "appSettings", "spinnerService"];
kindergartenService.$inject = ["api", "appSettings", "spinnerService"];