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
            var url = window.location.origin;
            return url;
        },
        //Kindergarten
        "GetKindergartens": "/app-api/Kindergarden/GetKinderGardens/?",
        "GetKindergartensNumbers": '/app-api/Kindergarden/GetKindergartensNumbers',
        "CreateKindergarten": '/app-api/Kindergarden/CreateGarten',
        "DeleteKindergarten": '/app-api/Kindergarden/DeleteKindergaten',
        "UpdateKindergarten": '/app-api/Kindergarden/UpdateKindergarten',
        //Children
        "CreateChild": '/app-api/Children/CreateChild',
        "GetChildren": '/app-api/Children/GetChildren/?',
        "UpdateChild": '/app-api/Children/UpdateChild/',
        "DeleteChild": '/app-api/Children/DeleteChild/'
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