var app = angular.module("app", ['core']);


//Controllers
app.controller('AppController', AppController);
app.controller('KindergartenController', KindergartenController);

AppController.$inject = ['$scope'];
KindergartenController.$inject = ['$scope', 'kindergartenService'];

/* Core Module Config
-----------------------------------------------------------------------------------------------------------------*/



