var app = angular.module("app", ['core']);


//Controllers
app.controller('AppController', AppController);
app.controller('KindergartenController', KindergartenController);
app.controller('ModalController', ModalController);
app.controller('ChildrenController', ChildrenController);

AppController.$inject = ['$scope'];
KindergartenController.$inject = ['$scope', '$uibModal', 'kindergartenService'];
ModalController.$inject = ['$scope', '$uibModalInstance', 'kindergartenService', 'childrenService', 'item'];
ChildrenController.$inject = ['$scope', '$uibModal', 'kindergartenService', 'childrenService'];

/* Core Module Config
-----------------------------------------------------------------------------------------------------------------*/



