using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Requirements_and_Design_environment.Models.Entities;
using System.Data.Entity;

namespace Requirements_and_Design_environment.Models.Interfaces
{
    public interface IProjectRepository : IDisposable
    {
        void DeleteProject(string name);

        void UpdateItem(int itemId, string content);

        void DeleteItem(int itemId);

        void CreateProject(Project model, UserProfile owner);

        Project[] GetProjectsByName(string name);

        Item GetItem(int id);

        Item AddItemToProject(Item item, int projectId, int templateId);

        Project GetProject(int id);
        Project GetProject(string name);
        DbContext GetContext();
       
    }
}
