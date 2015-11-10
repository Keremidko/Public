RDE.controller("OpenProjectController", function ($scope, $modalInstance, $http, ProjectService, AuthorizationService) {
    $scope.projects = AuthorizationService.getProfile().Projects;

    $scope.selected = null;

    $scope.searchName = "";

    $scope.searchResults = [];

    $scope.open = function () {
        var request = ProjectService.loadProject($scope.selected.ID);
        request.success(function () {
            $modalInstance.close();
        });
    };

    $scope.ownedProjects = function (project) {
        return project.AccessLevel == 1;
    };

    $scope.invitedProjects = function (project) {
        return project.AccessLevel != 1;
    };

    $scope.select = function (project) {
        if ($scope.selected == project)
            $scope.selected = null;
        else
            $scope.selected = project;
    };

    $scope.cancel = function () {
        $modalInstance.close();
    };

    $scope.findProjects = function (projName) {
        $http.get('/api/Project/GetPublicProjectsByName?name=' + projName
        ).success(function (res) {
            $scope.searchResults = res;
        });
    }
});