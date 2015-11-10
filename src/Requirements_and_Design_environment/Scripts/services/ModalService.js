RDE.factory('modalServices', function () {
    //Настройки на модалните прозорци
    var newProject = {
        templateUrl: '/template/modal/newProject',
        controller: 'NewProjectController',
        backdrop: 'static'
    };

    var openProject = {
        templateUrl: '/template/modal/openProject',
        controller: 'OpenProjectController',
        backdrop: 'static'
    };

    var manageProjects = {
        templateUrl: '/template/modal/manageProjects',
        controller: 'ManageProjectsController',
        backdrop: 'static'
    };

    var selectTheme = {
        templateUrl: '/template/modal/selectTheme',
        controller: 'SelectThemeController',
        backdrop: 'static',
        size : 'sm'
    };

    var newItemModal = {
        templateUrl: '/template/modal/newItem',
        controller: 'NewItemController',
        backdrop: 'static',
        size : 'sm'
    };

    var saveItemModal = {
        templateUrl: '/template/modal/saveItem',
        controller: 'SaveItemController',
        backdrop: 'static',
        size : 'sm'
    };

    var errorModal = {
        templateUrl: '/template/modal/error',
        backdrop: 'static',
        size : 'sm',
        controller: function ($scope, $modalInstance, data) {
            $scope.Message = data.Message;
            $scope.close = function () {
                $modalInstance.close();
            }
        }
    };

    return {
        newProject: newProject,
        openProject: openProject,
        manageProjects: manageProjects,
        selectTheme: selectTheme,
        newItemModal: newItemModal,
        saveItemModal: saveItemModal,
        errorModal: errorModal
    };
});