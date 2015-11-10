RDE.controller("AccountController", function ($scope, $http, $window, $state, AuthorizationService) {
    $scope.registerModel = new AuthorizationService.registerModel();
    $scope.loginModel = new AuthorizationService.loginModel();

    $scope.severError = false;
    $scope.serverMessage = "";

    $scope.GoBack = function () {
        $window.history.back();
    };

    $scope.Register = function () {
        $http.post(
            '/api/Account/Register',
            $scope.registerModel
        ).success(function () {
            AuthorizationService.userLoggedIn();
            $state.go("default");
            $scope.serverError = false;
        }).error(function (data) {
            $scope.serverError = true;
            $scope.serverMessage = data.Message;
        });
    };

    $scope.Login = function () {
        $http.post(
            '/api/Account/Login',
            $scope.loginModel
        ).success(function () {
            AuthorizationService.userLoggedIn();
            $state.go("default");
            $scope.serverError = false;
        }).error(function (data) {
            $scope.serverError = true;
            $scope.serverMessage = data.Message;
        });
    };

});
