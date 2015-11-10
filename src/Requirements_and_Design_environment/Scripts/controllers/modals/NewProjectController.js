RDE.controller("NewProjectController", function ($scope, $modalInstance, $http, AuthorizationService) {
    $scope.model = {
        ID : -1,
        Name: "",
        Visibility: 1,
        Participations : null
    }

    $scope.severError = false;
    $scope.serverMessage = "";

    $scope.nameMinLength = 5;

    $scope.create = function () {
        $http.post(
            '/api/Project/CreateProject?visibility='+$scope.model.Visibility,
             $scope.model
            ).success(function () {
                AuthorizationService.syncUserData();
                $modalInstance.close();
            }).error(function (data) {
                $scope.serverError = true;
                $scope.serverMessage = data.Message;
            });
    }

    $scope.closeAlert = function ()
    {
        $scope.serverError = false;
    }

    $scope.cancel = function () {
        $modalInstance.close();
    }
});