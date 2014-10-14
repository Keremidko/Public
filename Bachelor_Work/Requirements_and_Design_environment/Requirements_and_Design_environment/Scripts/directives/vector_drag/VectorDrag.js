RDE.directive("vectorDrag", function ($document, $timeout, Tools) {
    return {
        restrict: "E",
        transclude: true,
        replace : true,
        scope: {
            position: "=",
            resizeOffset: "=",
            model :"="
        },
        controller: function ($scope) {
            $scope.deleteVector = function () {
                $scope.$emit("widget:deleted", { widget: $scope.model });
                $scope.element.remove();
                $scope.resizer.remove();
            }

            $scope.ellipseOptions = [
                ['Delete', $scope.deleteVector]
            ];

            $scope.resizerOpacity = "0.0";
            $scope.showResizer = function ()
            {
                $scope.resizerOpacity = "0.1";
                
            }
            $scope.hideResizer = function() 
            {
                $timeout(function () {
                    $scope.resizerOpacity = "0.0";
                }, 2000);
            }

            var startX = 0, startY = 0, x, y, startSx, startSy;
            var tool = Tools.getTool();

            $scope.startDrag = function (event) {
               
                if (tool.name == "Hand") {
                    // Prevent default dragging of selected content
                    event.preventDefault();
                    startX = event.pageX - $scope.position.x;
                    startY = event.pageY - $scope.position.y;
                    $document.on('mousemove', mousemove);
                    $document.on('mouseup', mouseup);
                }
                if (tool.name == "Arrow" && event.which == 3)
                    event.preventDefault();
            };

            function mousemove(event) {
                $scope.position.x = event.pageX - startX;
                $scope.position.y = event.pageY - startY;
                $scope.$apply();
            }

            function mouseup() {
                $document.off('mousemove', mousemove);
                $document.off('mouseup', mouseup);
            }

            var sDimX, sDimY;
            $scope.startResize = function (event) {
                if (tool.name == "Hand") {
                    // Prevent default dragging of selected content
                    event.preventDefault();
                    startX = event.pageX;
                    startY = event.pageY;
                    sDimX = $scope.position.x + $scope.resizeOffset.x * $scope.position.sX;
                    sDimY = $scope.position.y + $scope.resizeOffset.y * $scope.position.sY;
                    startSx = $scope.position.sX;
                    startSy = $scope.position.sY;
                    $document.on('mousemove', resizeMove);
                    $document.on('mouseup', resizeUp);
                }
                if (tool.name == "Arrow" && event.which == 3)
                    event.preventDefault();
            }

            function resizeMove(event) {
                var dx = event.pageX - startX;
                var dy = event.pageY - startY;
                $scope.position.sX = startSx + (dx/sDimX);
                $scope.position.sY = startSy + (dy/sDimY);
                $scope.$apply();
            }

            function resizeUp() {
                $document.off('mousemove', resizeMove);
                $document.off('mouseup', resizeUp);
            }
        },
        templateUrl: "/Scripts/directives/vector_drag/VectorDragTemplate.html",
        link: function (scope, element, attrs) {
            var children = element.find("div").children().children();
            var dragWrapper = element.find("g")[0];
            $(dragWrapper).append(children);
            var resizer = element.find("path");
            $(document.getElementById("vectorContainer")).append(resizer);

            $(document.getElementById("vectorContainer")).append(dragWrapper);
            $(element).css({
                display: "none"
            });
            scope.element = dragWrapper;
            scope.resizer = resizer;
        }
    }
});