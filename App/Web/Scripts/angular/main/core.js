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
        "GetKindergartens": "/api/Kindergarden/GetKinderGardens/?",
        "GetKindergartensNumbers": '/api/Kindergarden/GetKindergartensNumbers'
    });

//Services

core.service('api', Api);
core.service('spinnerService', spinnerService);
core.service('kindergartenService', kindergartenService);

spinnerService.$inject = ['$timeout', '$busy'];
kindergartenService.$inject = ["api", "appSettings", "spinnerService"];
Api.$inject = ['$http', '$q', 'appSettings', '$window'];