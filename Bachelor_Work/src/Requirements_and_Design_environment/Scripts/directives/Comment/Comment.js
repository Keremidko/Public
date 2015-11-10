RDE.directive("comment", function () {
    return {
        restrict: "E",
        scope: {
            comment: "="
        },
        controller: function ($scope) {
            $scope.deleteComment = function () {
                $scope.$emit("widget:deleted", { widget: $scope.comment });
            }

            $scope.commentOptions = [
                ['Delete', $scope.deleteComment]
            ];
        },
        templateUrl: "/Scripts/directives/Comment/CommentTemplate.html"
    }
});