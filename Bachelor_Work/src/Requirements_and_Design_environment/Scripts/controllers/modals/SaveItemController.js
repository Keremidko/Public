RDE.controller("SaveItemController", function ($scope, $modalInstance, $cookies) {
    $scope.save = function () {
        $modalInstance.close();
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});

