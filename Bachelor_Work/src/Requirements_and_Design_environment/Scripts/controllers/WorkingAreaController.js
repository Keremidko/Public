RDE.controller("WorkingAreaController", function ($scope, $state, $rootScope, $modal, $http, modalServices, Item, ItemType, ItemInProcess) {

    $scope.ItemsInProcess = [];
    $scope.openedItem = null;
    $scope.openedDocument = null;
    $scope.openedDiagram = null;

    $scope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
       
        if (toState.name == "Project.Diagram" || toState.name == "Project.Document") {
            var itemInProcess, id = toParams.ID;
            var item;
            try {
                item = $scope.getItem(id);
            } catch (err) {
                //Колекцията все още не се е заредила
                return;
            }
            if (!isAlreadyProcessed(item)) {
                itemInProcess = new ItemInProcess(item, false);
                $scope.ItemsInProcess.push(itemInProcess);

            } else {
                itemInProcess = findItem(item.ID);
            }
            $scope.openItem(itemInProcess);
        }
    });

    $scope.$on('Item:save', function () {
        $scope.save($scope.openedItem);
    });

    $scope.save = function (item) {
        $http({
            method: "POST",
            url: "api/Item/UpdateItem",
            data: {
                ItemId : item.ref.ID,
                Content: (typeof item.dirtyContent === "string") ? item.dirtyContent : JSON.stringify(item.dirtyContent)
            }
        })
        .success(function () {
            item.ref.Contents = item.dirtyContent;
        });
        
    };

    $scope.openItem = function (item) {
        $(document.getElementById("vectorContainer")).children().remove();
        $scope.openedItem = item;
        if (item.ref.Type == ItemType['Document'])
            $scope.openedDocument = item;
        if (item.ref.Type == ItemType['Diagram'])
            $scope.openedDiagram = item;
    }

    $scope.closeItem = function (item) {
        var items = $scope.ItemsInProcess;
        var splice = function (i) {
            items.splice(i, 1);
            if (items[0]) {
                $scope.goToItemState(items[0].ref);
            } else {
                $state.go($state.$current.parent);
                $scope.openedItem = null;
                $scope.openedDocument = null;
                $scope.openedDiagram = null;
            }
        };

        for (var i = 0 ; i < items.length; i++)
            if (items[i] == item) {
                if (item.isDirty())
                    $modal.open(modalServices.saveItemModal).result.then(function () {
                        $scope.save(item);
                        splice(i);
                    }, function () {
                        splice(i);
                    });
                else
                    splice(i);
                break;
            }
    }

    var findItem = function (id)  {
        var items = $scope.ItemsInProcess;
        for(var i = 0 ; i < items.length ; i++) {
            if(items[i].ref.ID == id)
                return items[i];
        }
    }

    var isAlreadyProcessed = function (item) {
        var items = $scope.ItemsInProcess;
        for (var i = 0 ; i < items.length; i++)
        {
            if (items[i].ref.ID == item.ID)
                return true;
        }
        return false;
    }

});