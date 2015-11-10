RDE.directive("rdeEllipse", function ($document, $timeout) {
    return {
        restrict: "E",
        templateUrl: "/Scripts/directives/Ellipse/EllipseTemplate.html",
        scope: {
            model :"="
        },
        controller: function ($scope) {
            
        },
        link: function (scope, element, attrs) {
        }
    };
});