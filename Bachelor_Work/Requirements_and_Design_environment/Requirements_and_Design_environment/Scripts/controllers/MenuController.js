RDE.controller("MenuController", function ($scope, $rootScope, $modal, $http, modalServices, AuthorizationService) {
    $scope.newProjectModal = function () {
        if ($scope.userProfile.Logged)
            $modal.open(modalServices.newProject);
    };

    $scope.openProjectModal = function () {
        $modal.open(modalServices.openProject);
    };

    $scope.manageProjectsModal = function () {
        if ($scope.userProfile.Logged)
            $modal.open(modalServices.manageProjects);
    };

    $scope.Logout = function () {
        $http.post('/api/Account/Logout')
            .success(function () {
                AuthorizationService.userLoggedOut();
            })
    };

    $scope.selectThemeModal = function () {
        $modal.open(modalServices.selectTheme);
    };

    $scope.saveItem = function () {
        $rootScope.$broadcast("Item:save");
    }
});