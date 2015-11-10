using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Requirements_and_Design_environment.Infrastructure;
using Requirements_and_Design_environment.Models.Interfaces;
using Requirements_and_Design_environment.Models.Entities;
using Requirements_and_Design_environment.Models.Enums;

namespace Requirements_and_Design_environment.Models.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public void DeleteProject(string name)
        {
            var proj = dbContext.Projects.Where(x => x.Name == name).First();
            for (int i = 0; i < proj.Participations.Count; i++)
                dbContext.Participations.Remove(proj.Participations[i]);

            dbContext.Projects.Remove(proj);
            dbContext.SaveChanges();
        }

        public void DeleteItem(int itemId)
        {
            var item = dbContext.Items.Find(itemId);
            dbContext.Items.Remove(item);
            dbContext.SaveChanges();
        }

        public Item GetItem(int id) {
            return dbContext.Items.Find(id);
        }

        public void UpdateItem(int itemId, string content)
        {
            dbContext.Items.Find(itemId).Contents = content;
            dbContext.SaveChanges();
        }

        public Project[] GetProjectsByName(string name)
        {
            name = name.ToLower();
            var projects = from p in dbContext.Projects
                        where p.Name.ToLower().Contains(name)
                        select p;
            return projects.ToArray();
        }

        public Item AddItemToProject(Item item, int projectId, int templateId)
        {
            if (templateId > -1)
                item.Contents = dbContext.Templates.Where(x => x.ID == templateId).First().Contents;
            var project = dbContext.Projects.Find(projectId);
            item.Project = project;
            dbContext.Items.Add((item));
            dbContext.SaveChanges();
            return item;
        }

        public void CreateProject(Project model, UserProfile owner)
        {
            var participation = new Participation { ProjectReference = model, UserReference = owner, AccessLevel = Accessibility.Owner };

            dbContext.Entry(model).State = EntityState.Added;
            dbContext.Entry(participation).State = EntityState.Added;
            dbContext.Entry(owner).State = EntityState.Unchanged;

            dbContext.SaveChanges();
        }

        public Project GetProject(int id)
        {
            return dbContext.Projects.Find(id);
        }

        public Project GetProject(string name)
        {
            return dbContext.Projects.Where(x => x.Name == name).First();
        }

        public DbContext GetContext()
        {
            return dbContext;
        }
    }
}