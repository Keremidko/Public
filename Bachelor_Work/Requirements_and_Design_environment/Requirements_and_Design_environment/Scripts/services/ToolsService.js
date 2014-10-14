RDE.factory('Tools', function ($http, $rootScope, $state, ItemType) {
    var $ = angular.element;
    var scale = 1;

    var tool = {
        name: "Arrow",
        click : function() { }
    };

    zoomInClick = function (event) {
        event.stopPropagation();
        scale += 0.15;
        setScale(document.getElementById('diagramContent'), scale);
    };

    zoomOutClick = function (event) {
        event.stopPropagation();
        scale -= 0.15;
        setScale(document.getElementById('diagramContent'), scale);
    };

    var createClassDiagram = function (event) {
        $rootScope.$broadcast("create:classDiagram", {
            x: event.offsetX,
            y: event.offsetY
        });
    };

    var createComment = function (event) {
        $rootScope.$broadcast("create:comment", {
            x: event.offsetX,
            y: event.offsetY
        });
    };

    var createLine = function (event) {
        $rootScope.$broadcast("line:addPoint", {
            point : {
                x: event.offsetX,
                y: event.offsetY
            }
        });
    };

    var createText = function (event) {
        $rootScope.$broadcast("create:text", {
            x: event.offsetX,
            y: event.offsetY
        });
    };

    var createEllipse = function (event) {
        $rootScope.$broadcast("create:ellipse", {
            x: event.offsetX,
            y: event.offsetY
        });
    }

    var createRectangle = function (event) {
        $rootScope.$broadcast("create:rectangle", {
            x: event.offsetX,
            y: event.offsetY
        });
    }

    var setScale = function (el,scale)
    {
        $(el).css('-webkit-transform', 'scale(' + scale + ')');
        $(el).css('-moz-transform', 'scale(' + scale + ')');
        $(el).css('-ms-transform', 'scale(' + scale + ')');
        $(el).css('transform', 'scale(' + scale + ')');
    }

    return {
        setTool: function (t) {
            tool.name = t;
            $rootScope.$broadcast("tool:changed");
            switch (t) {
                case "Arrow": {
                    tool.click = function () { };
                    break;
                }
                case "Hand": {
                    tool.click = function () { };
                    break;
                }
                case "ZoomIn": {
                    tool.click = zoomInClick;
                    break;
                }
                case "ZoomOut": {
                    tool.click = zoomOutClick;
                    break;
                }
                case "ClassDiagram": {
                    tool.click = createClassDiagram;
                    break;
                }
                case "Comment": {
                    tool.click = createComment;
                    break;
                }
                case "Text": {
                    tool.click = createText;
                    break;
                }
                case "Line": {
                    tool.click = createLine;
                    break;
                }
                case "Ellipse": {
                    tool.click = createEllipse;
                    break;
                }
                case "Rectangle": {
                    tool.click = createRectangle;
                    break;
                }
                default: break;
            }
        },
        getTool: function() { return tool; }
    };
});