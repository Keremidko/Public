RDE.factory('AuthorizationService', function ($http/*, DeserializationService*/) {
    var user = {
        Logged : false
    };

    $http.get('/api/Account/IsUserLogged')
         .success(function (data) {
             if (data == "true") {
                 user.Logged = true;
                 syncUserData();
             }
         });

    var syncUserData = function () {
        $http.get('/api/Account/GetProfile')
                      .success(function (data) {
                          for (var i in data) {
                              user[i] = data[i];
                          }
                      });
    };

    var registerModel = function () {
        this.UserName = "";
        this.Password = "";
        this.ConfirmPassword = "";
    };

    var loginModel = function () {
        this.UserName = "";
        this.Password = "";
        this.RememberMe = true;
    };

    return {
        registerModel: registerModel,
        loginModel: loginModel,
        syncUserData: syncUserData,
        getProfile: function () { return user; },
        userLoggedIn: function () { user.Logged = true; syncUserData(); },
        userLoggedOut: function () {
            user.Logged = false;
            user.Projects = [];
        }
    };
});