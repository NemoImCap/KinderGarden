var app = angular.module("app", ['core']);


//Controllers
app.controller('AppController', AppController);
app.controller('KindergartenController', KindergartenController);
app.controller('ModalController', ModalController);

AppController.$inject = ['$scope'];
KindergartenController.$inject = ['$scope', '$uibModal', 'kindergartenService'];
ModalController.$inject = ['$scope', '$uibModalInstance','kindergartenService', 'item'];

/* Core Module Config
-----------------------------------------------------------------------------------------------------------------*/



