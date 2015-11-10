RDE.directive("diagramView", function (Tools) {
    return {
        scope : {
            diagrams : "="
        },
        restrict: 'A',
        link: function (scope, element, attrs) {
            var $ = angular.element;
            $(element[0]).on("click", function (e) {
                Tools.getTool().click(e);
            });
        }
    };
});