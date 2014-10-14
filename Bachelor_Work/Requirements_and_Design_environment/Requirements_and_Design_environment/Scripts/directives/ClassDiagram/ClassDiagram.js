RDE.directive("classDiagram", function () {
    return {
        restrict: "E",
        scope: {
            diagram :"="
        },
        controller: function ($scope) {
            $scope.deleteMember = function (e) {
                if (e.type == "prop")
                    $scope.diagram.properties.splice(e.index, 1);
                else
                    $scope.diagram.methods.splice(e.index, 1);
            }
            $scope.addProperty = function () {
                $scope.diagram.properties.push("");
            };
            $scope.addMethod = function () {
                $scope.diagram.methods.push("");
            };
            $scope.deleteDiagram = function () {
                $scope.$emit("widget:deleted", { widget: $scope.diagram });
            }

            $scope.memberOptions = [
                ['Delete', $scope.deleteMember]
            ];
            $scope.diagramOptions = [
                ['Add property', $scope.addProperty],
                ['Add method', $scope.addMethod],
                null,
                ['Delete', $scope.deleteDiagram]
            ];

            
        },
        templateUrl : "/Scripts/directives/ClassDiagram/ClassDiagramTemplate.html"
    }
});