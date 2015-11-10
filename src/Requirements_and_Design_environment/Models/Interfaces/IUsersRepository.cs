using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Requirements_and_Design_environment.Models.Entities;

namespace Requirements_and_Design_environment.Models.Interfaces
{
    public interface IUsersRepository : IDisposable
    {
        UserProfile GetCurrentUserProfile();
        UserProfile GetProfileByName(string name);
        string[] GetUsersByName(string name);
     }
}