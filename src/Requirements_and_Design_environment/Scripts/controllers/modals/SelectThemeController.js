RDE.controller("SelectThemeController", function ($scope, $modalInstance, $cookies) {
    $scope.theme = $cookies.theme;
    if ($scope.theme == undefined)
        $scope.theme = "cerulean";

    $scope.select = function (val) {
        $cookies.theme = val;
        window.location.reload();
        $modalInstance.close();
    };

    $scope.cancel = function () {
        $modalInstance.close();
    };
});