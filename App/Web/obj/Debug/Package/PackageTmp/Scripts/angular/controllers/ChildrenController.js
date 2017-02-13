function ChildrenController(
    $scope,
    $uibModal,
    kindergartenService,
    childrenService) {

    $scope.Children = [];
    $scope.Numbers = [];
    $scope.item = null;
    $scope.gridModel = {
        search: "",
        age: 0,
        page: 0,
        gartenNumber: null
    }

    $scope.InitPageContent = function () {
        var search = RegExp('[?&]' + "gartenId" + '=([^&]*)').exec(window.location.search);
        if (search) {
            $scope.gridModel.gartenId = Number(search[1]);
        }
        $scope.LoadData();
    }

    $scope.LoadData = function () {
        var request = childrenService.GetChildren($scope.gridModel);
        request.then(function(response) {
            if (response.data) {
                $scope.Children = response.data;
            }
        });
    }

    $scope.DeleteChild = function (child, index) {
        var request = childrenService.DeleteChild(child);
        request.then(function(response) {
            $scope.Children.splice(index, 1);
        });
    }

    $scope.CreateDialog = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            keyboard: true,
            templateUrl: '/Children/CreateChild',
            controller: 'ModalController',
            controllerAs: 'ChildrenController',
            resolve: {
                item: function () {
                    return $scope.item;
                }
            }
        });

        modalInstance.result.then(function (item) {
            $scope.Children.push(item);
        });
    };

    $scope.UpdateDialog = function (child, index) {
        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            keyboard: true,
            templateUrl: '/Children/UpdateChild',
            controller: 'ModalController',
            controllerAs: 'ChildrenController',
            resolve: {
                item: function () {
                    return child;
                }
            }
        });

        modalInstance.result.then(function (item) {
            if (window.location.pathname == "/Children/GetChildren/") {
                $scope.Children.splice(index, 1);
            } else {
                $scope.Children[index] = item;
            }
           
        });
    }


    $scope.InitPageContent();
};
