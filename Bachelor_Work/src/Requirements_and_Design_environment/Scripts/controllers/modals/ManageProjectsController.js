RDE.controller("ManageProjectsController", function ($scope, $modalInstance, $http, $filter, AuthorizationService) {

    $scope.userOwnedProjects = $filter("UserOwnedProjects")(AuthorizationService.getProfile().Projects);
    $scope.selected = $scope.userOwnedProjects[0];
    $scope.selectedIndex = 0;
    $scope.dirtyModel = angular.copy($scope.selected);
    $scope.searchResults = [];
    $scope.unfilteredResults = [];

    $scope.showAlert = false;
    $scope.alertCallback = null;

    $scope.setSelected = function (proj, index) {
        var select = function () {
            $scope.searchResults = [];
            $scope.selected = proj;
            $scope.selectedIndex = index;
            $scope.dirtyModel = angular.copy(proj);
            $scope.dirtyModel.isDirty = false;
        };

        if ($scope.dirtyModel.isDirty) {
            $scope.showAlert = true;
            $scope.alertCallback = select;
        }
        else {
            select();
        }
    };

    $scope.setDirty = function () {
        $scope.dirtyModel.isDirty = true;
    };

    $scope.save = function () {
        $http({
            url: '/api/Project/UpdateProject',
            method: 'POST',
            params: {
                name: $scope.selected.Name
            },
            data: $scope.dirtyModel
        }).success(function (data) {
            $scope.selected = $scope.dirtyModel;
            $scope.userOwnedProjects[$scope.selectedIndex] = $scope.dirtyModel;
            $scope.dirtyModel.isDirty = false;
        })
           .error(function (data) {
               console.log(data);
        });
    };

    $scope.close = function () {
        if ($scope.dirtyModel  && $scope.dirtyModel.isDirty)
        {
            $scope.showAlert = true;
            $scope.alertCallback = $modalInstance.close;
        } else {
            $modalInstance.close();
        }
        
    };

    $scope.alertClick = function (useCallback) {
        if (useCallback)
            $scope.save($scope.dirtyModel);
        $scope.alertCallback();
        $scope.showAlert = false;
    };

    $scope.findUsers = function (name) {
        $scope.searchResults = [];
        $http.get('/api/Account/GetUsersByName?name='+name
        ).success(function (res) {
            $scope.unfilteredResults = res;
            $scope.searchResults = $filter("UsersNotInProject")($scope.dirtyModel, res);
        });
    };

    $scope.removeUser = function (index) {
        $scope.dirtyModel.Participants.splice(index,1);
        $scope.setDirty();
    };

    $scope.addUser = function (user) {
        $scope.dirtyModel.Participants.push(user);
        $scope.searchResults = $filter("UsersNotInProject")($scope.dirtyModel, $scope.unfilteredResults);
        $scope.setDirty();
    };

    $scope.deleteProject = function ()
    {
        $http.delete('/api/Project/DeleteProject', {
            params: {
                name : $scope.selected.Name
            }
        })
        .success(function () {
            $scope.userOwnedProjects.splice($scope.selectedIndex, 1);
            $scope.selected = $scope.userOwnedProjects[0];
            $scope.selectedIndex = 0;
            AuthorizationService.syncUserData();
        });
    }
});