//Филтър който връща по подадени проекти 
//списък с проектите на които user-a е 'owner'
RDE.filter('UserOwnedProjects', function () {
    return function (projects) {
        var result = [];
        for (var i = 0 ; i < projects.length ; i++) {
            if (projects[i].AccessLevel == 1)
                result.push(projects[i]);
        }
        return result;
    }
});

//Филтър който връща по подаден проект и списък с user-и
//списък с user-ите които не участват в този проект
RDE.filter('UsersNotInProject', function () {
    return function (project, users) {
        var result = [];
        for (var i = 0 ; i < users.length; i++) {
            var user = users[i];
            var isInProject = false;
            for (var j = 0 ; j < project.Participants.length; j++)
            {
                var participantName = project.Participants[j].UserName;
                if (user == participantName)
                {
                    isInProject = true;
                    break;
                }
            }
            if (!isInProject)
                result.push(user);
        }
        return result;
    };
});