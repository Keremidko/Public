RDE.controller("NewItemController", function ($scope, $modalInstance, $cookies, type) {
    $scope.model = {
        Name: null,
        UseTemplate : false
    };

    $scope.type = type;

    $scope.create = function () {
        $modalInstance.close($scope.model);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});

