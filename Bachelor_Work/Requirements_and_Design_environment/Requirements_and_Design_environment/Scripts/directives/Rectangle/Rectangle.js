RDE.directive("rdeRectangle", function ($document, $timeout) {
    return {
        restrict: "E",
        templateUrl: "/Scripts/directives/Rectangle/RectangleTemplate.html",
        scope: {
            model :"="
        },
        controller: function ($scope) {
        },
        link: function (scope, element, attrs) {
        }
    };
});