(function () {
    window.$ = angular.element;
    window.RDE = angular.module("RDE", ['ui.bootstrap', 'ngAnimate', 'ui.router', 'ngCookies', 'ui.tinymce']);
    RDE.value('uiTinymceConfig', {
        plugins: "table print preview",
        menubar : 'edit view format table',
        height:440,

    });
    RDE.config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
        $stateProvider
        .state("default", {
            url: "/",
            templateUrl: "Template/Get/Editor"
        })
        .state('Login', {
            url: '/Login',
            templateUrl: 'Template/Get/Login'
        })
        .state('Registration', {
            url: '/Registration',
            templateUrl: 'Template/Get/Registration'
        })
        .state('Editor', {
            url: "/Editor",
            templateUrl: 'Template/Get/Editor'
        })
        .state('Project', {
            url: "/Project/:projectId",
            templateUrl : 'Template/Get/Editor'
        })
        .state('Project.Document', {
            url: "/Document/:ID",
            //templateUrl : 'Template/Get/Tinymce'
        })
        .state('Project.Diagram', {
            url: "/Diagram/:ID",
            //templateUrl: 'Template/Get/DiagramEditor'
        });
        $urlRouterProvider.when("", function ($state) {
            $state.go("default");
        });

        //var param = function (obj) {
        //    var query = '', name, value, fullSubName, subName, subValue, innerObj, i;

        //    for (name in obj) {
        //        value = obj[name];

        //        if (value instanceof Array) {
        //            for (i = 0; i < value.length; ++i) {
        //                subValue = value[i];
        //                fullSubName = name + '[' + i + ']';
        //                innerObj = {};
        //                innerObj[fullSubName] = subValue;
        //                query += param(innerObj) + '&';
        //            }
        //        }
        //        else if (value instanceof Object) {
        //            for (subName in value) {
        //                subValue = value[subName];
        //                fullSubName = name + '[' + subName + ']';
        //                innerObj = {};
        //                innerObj[fullSubName] = subValue;
        //                query += param(innerObj) + '&';
        //            }
        //        }
        //        else if (value !== undefined && value !== null)
        //            query += encodeURIComponent(name) + '=' + encodeURIComponent(value) + '&';
        //    }

        //    return query.length ? query.substr(0, query.length - 1) : query;
        //};
        //$httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
        //$httpProvider.defaults.transformRequest = [function (data) {
        //    return angular.isObject(data) && String(data) !== '[object File]' ? param(data) : data;
        //}];
    });

    
})();
