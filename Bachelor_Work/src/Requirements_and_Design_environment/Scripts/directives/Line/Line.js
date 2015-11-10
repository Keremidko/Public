RDE.directive("line", function ($document, $timeout, $location, $state) {
    return {
        restrict: "E",
        templateUrl: "/Scripts/directives/Line/LineTemplate.html",
        scope: {
            line:"=",
            points: "="
        },
        controller: function ($scope) {
            var point;
            var startX, startY, x, y, dx, dy;
           
            $scope.strokeWidth = "2px";
            $scope.thickLine = function ()
            {
                $scope.strokeWidth = "3px";
            }
            $scope.thinLine = function()  
            {
                $scope.strokeWidth = "2px";
            }
            $scope.line.dashArray = $scope.line.dashArray ? $scope.line.dashArray : "5,5";
            $scope.deleteLine = function () {
                $scope.$emit("widget:deleted", { widget: $scope.line });
                $scope.element.remove();
            }
            $scope.setDashed = function () { $scope.line.dashArray = "5,5" }
            $scope.setSolid = function() { $scope.line.dashArray = "0,0" }

            $scope.insertPoint = function (s, elem, event) {
                var pt = {
                    x: event.offsetX,
                    y: event.offsetY
                }
                var pts = $scope.points;
                for (var i = 0 ; i < pts.length; i++)
                {
                    var maxX, maxY, minX, minY;
                    maxX = Math.max(pts[i].x, pts[i+1].x);
                    minX = Math.min(pts[i].x, pts[i+1].x);
                    maxY = Math.max(pts[i].y, pts[i+1].y);
                    minY = Math.min(pts[i].y, pts[i+1].y);
                    if (pt.x > minX
                        && pt.x < maxX
                        && pt.y > minY
                        && pt.y < maxY) {
                        pts.splice(i+1, 0, pt);
                        break;
                    }
                }
            }

            $scope.setCircle = function (endPoint) {
                if (endPoint == 'start')
                    $scope.line.startPoint = '#markerCircle';
                else
                    $scope.line.endPoint = '#markerCircle';
                $scope.$apply();
            }

            $scope.setArrow = function (endPoint) {
                if (endPoint == 'start') 
                    $scope.line.startPoint = '#markerBack';
                else
                    $scope.line.endPoint = '#markerArrow';
                $scope.$apply();
            }

            $scope.clearEndPoint = function (endPoint) {
                if (endPoint == 'start')
                    $scope.line.startPoint = '';
                else
                    $scope.line.endPoint = '';
                $scope.$apply();
            }

            $scope.endPointOptions = [
                ['Circle', $scope.setCircle],
                ['Arrow', $scope.setArrow],
                ['None', $scope.clearEndPoint]
            ];

            $scope.lineOptions = [
                ['Make dashed', $scope.setDashed],
                ['Make solid', $scope.setSolid],
                ['Insert point', $scope.insertPoint],
                null,
                ['Delete', $scope.deleteLine]
            ];

            $scope.deletePoint = function (i) {
                $scope.points.splice(i+1, 1);
            };

            $scope.pointOptions = [
                ['Delete', $scope.deletePoint]
            ];

            

            $scope.notFirstOrLast = function (pt) {
                var pts = $scope.points;
                return pts[0] != pt && pts[pts.length - 1] != pt;

            }
            
            $scope.startDrag = function ($event, pt) {
                point = pt;
                x = pt.x;
                y = pt.y;
                startX = $event.pageX;
                startY = $event.pageY;
                $document.on('mousemove', mousemove);
                $document.on('mouseup', mouseup);
            };

            function mousemove(event) {
                dy = event.pageY - startY;
                dx = event.pageX - startX;
                point.x = x + dx;
                point.y = y + dy;
                $scope.$apply(function () {
                    $scope.calculatePath();
                });
            }

            function mouseup() {
                $document.off('mousemove', mousemove);
                $document.off('mouseup', mouseup);
            }
            $scope.calculatePath = function () {
                var path = "M" + $scope.points[0].x + "," + $scope.points[0].y + " ";
                for (var i = 1; i < $scope.points.length ; i++) {
                    path += "L" + $scope.points[i].x + "," + $scope.points[i].y + " ";
                }
                $scope.path = path;
            };
        },
        link: function (scope, element, attrs) {
            scope.calculatePath();
            scope.$watch("points", function (newValue, oldValue) {
                $timeout(function () {
                    scope.$apply(function () {
                        scope.calculatePath();
                    });
                });
            }, true);
            var vectorContainer = $(document.getElementById("vectorContainer"));
            scope.element = element.children().children();
            vectorContainer.append(scope.element);
            element.remove();
            element.children().remove();
        }
    };
});