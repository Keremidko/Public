RDE.controller("BaseController",
    function ($scope, $modal, $state, ErrorHandlingService, ProjectService, Item, Tools, ItemType, AuthorizationService, modalServices) {
    //Добавя към главния scope user profile-a
    //и после всички останали имат достъп до него
    $scope.userProfile = AuthorizationService.getProfile();
    $scope.project = ProjectService.project;
    $scope.tool = Tools.getTool();
    
    $scope.goToItemState = function (e) {
        switch (e.Type) {
            case 2: {
                $state.go("Project.Document", {
                    projectId: $scope.project.ID,
                    ID: e.ID
                });
                break;
            }
            case 3: {
                $state.go("Project.Diagram", {
                    projectId: $scope.project.ID,
                    ID: e.ID
                });
                break;
            }
            default: break;
        }
    };

    $scope.getItem = function (id) {
        var get = function (itemId, collection) {
            if (itemId == -1)
                return $scope.project;
            for (var i = 0; i < collection.length ; i++) {
                if (collection[i].ID == itemId)
                    return collection[i];
                if (collection[i].Type == ItemType["Folder"]) {
                    var search = get(itemId, collection[i].Items);
                    if (search != null)
                        return search;
                }
            }
            return null;
        };

        return get(id, $scope.project.Items);
    }

    $scope.addItem = function (e, type) {
        var settings = angular.copy(modalServices.newItemModal);
        settings.resolve = { type: function () { return type; } };
        $modal.open(settings).result.then(function (model) {
            var itemParams = {
                parentId: (e == $scope.project)? -1 : e.ID,
                name: model.Name,
                type: type,
            };
            var templateId = -1;
            if (type == ItemType["Document"] && model.UseTemplate)
                templateId = 1;
            var item = Item.createItem(itemParams, $scope.project.ID, templateId)
                .error(function (data, statusCode) {
                    ErrorHandlingService.handleError(data, statusCode);
                })
                .success(function (data) {
                //TODO: тази логика да се измести във service-a който създава item-a
                if (data.Type == ItemType["Folder"]) {
                    data.Items = [];
                    data.opened = true;
                }
                //TODO: тази също
                if (data.Type == ItemType["Diagram"])
                    data.Contents = JSON.parse(data.Contents);
                //Подрежда item-ите
                for (var i = 0 ; i < e.Items.length ; i++) {
                    if (e.Items[i].Type == data.Type) {
                        e.Items.splice(i, 0, data);
                        return;
                    }
                }
                e.Items.push(data);
            });
        });
    };
});