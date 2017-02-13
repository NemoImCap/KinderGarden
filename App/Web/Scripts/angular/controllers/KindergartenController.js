function KindergartenController(
    $scope,
    $uibModal,
    kindergartenService) {

    $scope.Kindergartens = [];
    $scope.Numbers = [];
    $scope.item = null;
    $scope.gridModel = {
        search: "",
        number: null,
        page: 0
    }

    $scope.InitPageContent = function() {
        $scope.LoadData();
    }

    $scope.LoadData = function() {
        var request = kindergartenService.GetKindergartens($scope.gridModel);
        request.then(function (response){
            if (response.data) {
                $scope.Kindergartens = response.data;
            }
        });
    }

    $scope.DeleteKindergarten = function(kinder, index) {
        kindergartenService.DeleteKindergarten(kinder).then(function (response) {
            $scope.Kindergartens.splice(index, 1);
        });
    }

    $scope.CreateDialog = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            keyboard : true,
            templateUrl: '/Kindergarden/CreateKindergarden',
            controller: 'ModalController',
            controllerAs: 'KindergartenController',
            resolve: {
                item: function () {
                    return $scope.item;
                }
            }
        });

        modalInstance.result.then(function (item) {
            $scope.Kindergartens.push(item);
        });
    };

    $scope.UpdateDialog = function(garten) {
        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            keyboard: true,
            templateUrl: '/Kindergarden/UpdateKindergarten',
            controller: 'ModalController',
            controllerAs: 'KindergartenController',
            resolve: {
                item: function () {
                    return garten;
                }
            }
        });

        modalInstance.result.then(function (item) {
          
        });
    }


    $scope.InitPageContent();
};
