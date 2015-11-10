RDE.directive("text", function () {
    return {
        restrict: "E",
        scope: {
            text: "="
        },
        controller: function ($scope) {
            $scope.deleteComment = function () {
                $scope.$emit("widget:deleted", { widget: $scope.text });
            }

            $scope.commentOptions = [
                ['Delete', $scope.deleteComment]
            ];
        },
        templateUrl: "/Scripts/directives/Text/TextTemplate.html"
    }
});