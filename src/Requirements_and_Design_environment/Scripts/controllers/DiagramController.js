RDE.controller("diagramController", function ($scope, $document, Item) {
    $scope.classDiagrams = function (widget) {
        return widget.type === "class";
    }
    
    $scope.texts = function (widget) {
        return widget.type === "text";
    };

    $scope.comments = function (widget) {
        return widget.type === "comment";
    }

    $scope.ellipses = function (widget) {
        return widget.type == "ellipse";
    }

    $scope.rectangles = function (widget) {
        return widget.type == "rectangle";
    }

    $scope.lines = function (widget) {
        return widget.type === "line";
    }

    $scope.$on("widget:deleted", function (event, args) {
        var w = args.widget;
        var widgets = $scope.openedDiagram.dirtyContent.widgets;
        for (var i = 0 ; i < widgets.length; i++)
            if (widgets[i] == w) {
                widgets.splice(i, 1);
                break;
            }
    });

    $scope.$on("create:classDiagram", function (event, args) {
        var classDiagram = Item.createClassDiagram(args.x, args.y);
        $scope.openedDiagram.dirtyContent.widgets.push(classDiagram);
    });

    $scope.$on("create:comment", function (event, args) {
        var comment = Item.createComment(args.x, args.y);
        $scope.openedDiagram.dirtyContent.widgets.push(comment);
    });

    $scope.$on("create:text", function (event, args) {
        var text = Item.createText(args.x, args.y);
        $scope.openedDiagram.dirtyContent.widgets.push(text);
    });

    $scope.$on("create:ellipse", function (event, args) {
        var ellipse = Item.createEllipse(args.x, args.y);
        $scope.openedDiagram.dirtyContent.widgets.push(ellipse);
        $scope.$apply();
    });

    $scope.$on("create:rectangle", function (event, args) {
        var rectangle = Item.createRectangle(args.x, args.y);
        $scope.openedDiagram.dirtyContent.widgets.push(rectangle);
    });

    (function () {
        var currentLine = null;
        $scope.$on("tool:changed", function () {
            currentLine = null;
        });
        $scope.$on("line:addPoint", function (event, args) {
            if (!currentLine)
            {
                currentLine = Item.createLine(args.point.x, args.point.y);
                $scope.openedDiagram.dirtyContent.widgets.push(currentLine);
            } else {
                currentLine.addPoint(args.point);
            }
            $scope.$apply();
        });
        
        $document.on('keypress', function (event) {
            //При натиснат enter
            if (event.keyCode == 13) {
                currentLine = null;
            }
        });

    })();

});