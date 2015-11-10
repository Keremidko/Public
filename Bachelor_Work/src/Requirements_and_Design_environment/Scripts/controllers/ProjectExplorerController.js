RDE.controller("ProjectExplorerController",
    function ($scope, $modal, $http, $state, $rootScope, ProjectService, Item, ItemType, ErrorHandlingService, modalServices) {
        $scope.openFolder = function (e) { e.opened = true; };
        $scope.closeFolder = function (e) { e.opened = false; }
        $scope.toggleFolder = function (e) { e.opened = !e.opened; }
        $scope.state = $state.current;
        $scope.$on("$stateChangeSuccess", function (event, toState) {
            $scope.state = toState;
        });

        $scope.openItem = function (e) {
            $scope.goToItemState(e);
        }

        //TODO : При отворен документ и изтриване на директория която го съдържа,и ли на същия документ - да се затваря и документа
        //TODO : Да има Confirm Window.
        $scope.delete = function (e) {
            if (e.Type == ItemType["Folder"])
                for(var i = 0 ; i < e.Items.length; i++)
                    $scope.delete(e.Items[i]);

            (function () {
                var parent = $scope.getItem(e.ParentID);
                $http.delete('/api/Item/DeleteItem', {
                    params: {
                        itemId : e.ID
                    }
                }).success(function () {
                    for (var i = 0 ; i < parent.Items.length ; i++) {
                        if (parent.Items[i].ID == e.ID) {
                            parent.Items.splice(i, 1);
                            break;
                        }
                    }
                }).error(function(data, status, headers, config) {
                    ErrorHandlingService.handleError(data,status);
                });;
            })();
        }

        //TODO : Да се добави възможност за cut/copy/paste
        //TODO : да се промени директиваната на contextMenu-то за да могат да се добавят глифове към елемента
        $scope.folderOptions = [
            ['Open', $scope.openFolder],
            ['Close', $scope.closeFolder],
            null,
            ['Add Folder', $scope.addItem, ItemType["Folder"]],
            ['Add Document', $scope.addItem, ItemType["Document"]],
            ['Add Diagram', $scope.addItem, ItemType["Diagram"]],
            null,
            ['Delete', $scope.delete]
        ];

        //TODO : Да се добави опция за "View Project info" в която да излизат
        //project Owner-a, participants, и някакъв Description
        //Премахване на Delete опцията
        $scope.projectOptions = $scope.folderOptions.slice(0, $scope.folderOptions.length - 2);

        $scope.documentOptions = [
            ['Open', $scope.openItem],
            ['Delete', $scope.delete]
        ];
        $scope.diagramOptions = $scope.documentOptions;
    });