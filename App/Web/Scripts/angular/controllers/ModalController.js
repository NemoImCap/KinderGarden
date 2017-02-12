function ModalController(
    $scope,
    $uibModalInstance,
    kindergartenService,
    item) {

    $scope.Context = item;
    $scope.KindergartenModel = {
        address: "",
        number: 0
    }

    $scope.CreateKindergarten = function () {
        if ($scope.KindergartenModel.address.length && $scope.KindergartenModel.number) {
            var request = kindergartenService.CreateKindergarten($scope.KindergartenModel);
                request.then(function (response) {
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

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };


}