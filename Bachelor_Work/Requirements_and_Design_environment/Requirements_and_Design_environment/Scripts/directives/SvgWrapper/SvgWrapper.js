RDE.directive("svgWrapper", function ($document, Tools) {
    return {
        restrict: "E",
        transclude: true,
        replace : true,
        scope: {
            position : "="
        },
        templateUrl: "/Scripts/directives/SvgWrapper/SvgWrapperTemplate.html",
        link: function (scope, element, attrs) {
            var startX = 0, startY = 0, x = scope.position.x, y = scope.position.y;
            var tool = Tools.getTool();

            element.css({
                top : scope.position.y + "px",
                left : scope.position.x + "px"
            });

            element.on('mousedown', function (event) {
                if (tool.name == "Hand") {
                    // Prevent default dragging of selected content
                    event.preventDefault();
                    startX = event.pageX - x;
                    startY = event.pageY - y;
                    $document.on('mousemove', mousemove);
                    $document.on('mouseup', mouseup);
                }
                if (tool.name == "Arrow" && event.which == 3)
                    event.preventDefault();
            });

            function mousemove(event) {
                y = event.pageY - startY;
                x = event.pageX - startX;
                scope.position.x = x;
                scope.position.y = y;
                element.css({
                    top: y + 'px',
                    left: x + 'px'
                });
            }

            function mouseup() {
                $document.off('mousemove', mousemove);
                $document.off('mouseup', mouseup);
            }
        }
    }
});