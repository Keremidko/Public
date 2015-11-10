RDE.directive("svgTextInput", function () {
    return {
        restrict: "E",
        replace :"true",
        scope: {
            data: "=",
            x: "=",
            y: "=",
            width: "=",
            height: "=",
        },
        template : '<foreignObject ng-attr-x ng-attr-y ng-attr-width ng-attr-height>'
                  +'<body xmlns="http://www.w3.org/1999/xhtml">'
                  +'<input type="text" ng-model="data"/>'
                  +'</body>'
                  +'</foreignObject>'
    }
});