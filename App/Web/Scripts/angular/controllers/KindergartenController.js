function KindergartenController(
    $scope,
    kindergartenService) {

    $scope.Kindergartens = [];
    $scope.Numbers = [];

    $scope.gridModel = {
        search: "",
        number: 0,
        page: 0
    }

    $scope.InitPageContent = function() {
        $scope.LoadData();
    }

    $scope.LoadData = function() {
        kindergartenService.GetKindergartens($scope.gridModel).then(function (response) {
            if (response) {
                $scope.Kindergartens = response;
            }
        });
    }


    $scope.InitPageContent();
};
