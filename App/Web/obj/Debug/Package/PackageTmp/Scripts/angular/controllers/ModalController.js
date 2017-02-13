function ModalController(
    $scope,
    $uibModalInstance,
    kindergartenService,
    childrenService,
    item) {

    $scope.Context = item;
    $scope.asyncSelected = null;
    $scope.Kindergartens = [];
    $scope.modalError = false;
    $scope.KindergartenModel = {
        address: "",
        number: 0
    }
    $scope.ChildModel = {
        FirstName: "",
        LastName: "",
        MiddleName: "",
        Age: null,
        GartenId: null
    }

    $scope.CreateKindergarten = function() {
        $scope.modalError = !$scope.KindergartenModel.address || !$scope.KindergartenModel.number;
        if (!$scope.modalError) {
        var request = kindergartenService.CreateKindergarten($scope.KindergartenModel);
        request.then(function(response) {
            $uibModalInstance.close(response.data);
        });
       }
    }

    $scope.UpdateKindergarten = function() {
        if ($scope.Context.Address.length && $scope.Context.Number) {
            var model = { Address: $scope.Context.Address, Number: $scope.Context.Number };
            var request = kindergartenService.UpdateKindergarten($scope.Context);
            request.then(function (response) {
                $uibModalInstance.close(response.data);
            });
        }
    }


    $scope.CreateChild = function () {
        $scope.modalError = !$scope.ChildModel.FirstName ||
            !$scope.ChildModel.LastName ||
            !$scope.ChildModel.MiddleName ||
            !$scope.ChildModel.Age;
        if ($scope.asyncSelected != null) {
            $scope.ChildModel.GartenId = $scope.asyncSelected.Id;
        }
        if (!$scope.modalError) {
            childrenService.CreateChild($scope.ChildModel).then(function (response) {
                $uibModalInstance.close(response.data);
            });
        }
    }

    $scope.SearchGarten = function (value) {
        var request = kindergartenService.GetKindergartens({ search: value });
        return request.then(function (response) {
            return response.data;
        });
    }

    $scope.UpdateChild = function() {
        $scope.modalError = !$scope.Context.FirstName ||
            !$scope.Context.LastName||
            !$scope.Context.MiddleName ||
            !$scope.Context.Age;
        if ($scope.asyncSelected != null) {
            $scope.Context.GartenId = $scope.asyncSelected.Id;
        }
        if (!$scope.modalError) {
            var request = childrenService.UpdateChild($scope.Context);
            request.then(function(response) {
                $uibModalInstance.close(response.data);
            });
        }
    }

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };


}