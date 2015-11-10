RDE.controller("ToolboxController",
    function ($scope, Tools) {
        $scope.setTool = function (t) {
            Tools.setTool(t);
        }
        $scope.tool = Tools.getTool();
    });