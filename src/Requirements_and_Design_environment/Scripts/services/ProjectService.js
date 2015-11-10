RDE.factory('ProjectService', function ($http, $rootScope, $state, ItemType) {

    var project = {
        loaded: false,
        opened : true
    };

    var loadProject = function (id) {
        return $http.get('/api/Project/OpenProject', {
            params: {
                id: id
            }
        }).success(function (data) {
            project.loaded = true;
            for (var i in data)
                project[i] = data[i];
            parseContents();
            createTreeStructure();
            if (!$state.$current.includes.Project || !($state.params && $state.params.projectId == id))
                $state.go('Project', { projectId: id });
            else
                //refresh-ва State-а
                $state.transitionTo($state.current, $state.params, {
                    reload: true,
                    inherit: false,
                    notify: true
                });
        });

    };

    //Преобразува JSON string-a на contents-a към javascript обекти
    var parseContents = function () {
        for (var i = 0; i < project.Items.length ; i++)
            if (project.Items[i].Type == ItemType["Diagram"])
                project.Items[i].Contents = JSON.parse(project.Items[i].Contents);

    };

    //Създава дървовидна структура от линейната която връща server-a
    var createTreeStructure = function () {
        var folders = {};
        for (var i = 0 ; i < project.Items.length ; i++)
        {
            if (project.Items[i].Type == ItemType["Folder"])
            {
                var items = [];
                project.Items[i].Items = items;
                project.Items[i].opened = true;
                folders[project.Items[i].ID] = items;
            }
        }

        for(var j = 0 ; j < project.Items.length ; j++)
        {
            var item = project.Items[j];
            if (item.ParentID != -1)
            {
                folders[item.ParentID].push(item);
                project.Items.splice(j, 1);
                j--;
            }
        }
    };

    $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
        if (toParams.projectId) {
            var id = toParams.projectId;
            if (project.ID != id)
                loadProject(id);
        }
    });


    return {
        project : project,
        loadProject: loadProject,
        unLoadProject : function() { project.loaded = false; }
    };
});