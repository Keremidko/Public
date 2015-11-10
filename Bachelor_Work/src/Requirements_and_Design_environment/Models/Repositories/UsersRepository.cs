using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Requirements_and_Design_environment.Infrastructure;
using Requirements_and_Design_environment.Models.Interfaces;
using Requirements_and_Design_environment.Models.Entities;

namespace Requirements_and_Design_environment.Models.Repositories
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public UserProfile GetCurrentUserProfile()
        {
            return dbContext.UserProfiles.Where(x => x.UserName == HttpContext.Current.User.Identity.Name).FirstOrDefault();
        }

        public UserProfile GetProfileByName(string name)
        {
            return dbContext.UserProfiles.Where(x => x.UserName == name).FirstOrDefault();
        }

        public string[] GetUsersByName(string name)
        {
            name = name.ToLower();
            var users = dbContext.UserProfiles.ToList().FindAll(x => x.UserName.ToLower().Contains(name));
            return users.Select(x => x.UserName).ToArray<string>();
        }
    }
}