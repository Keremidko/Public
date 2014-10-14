using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Requirements_and_Design_environment.Infrastructure;
using Requirements_and_Design_environment.Models.Enums;
using Requirements_and_Design_environment.Models.Entities;
using Requirements_and_Design_environment.Models.Interfaces;
using Requirements_and_Design_environment.Models.Repositories;
using Requirements_and_Design_environment.Models.ClientModels;
using System.Data.Entity.Core;


namespace Requirements_and_Design_environment.Controllers
{
    [Authorize]
    public class ProjectController : ApiController
    {
        private IProjectRepository projectRepository { get; set; }
        private IUsersRepository usersRepository { get; set; }

        public ProjectController()
        {
            projectRepository = new ProjectRepository();
            usersRepository = new UsersRepository();
        }

        [HttpGet]
        [AllowAnonymous]
        //TODO : Да се направи проверка за видимоста на проекта
        public object OpenProject(int id)
        {
            var proj = projectRepository.GetProject(id);
            proj.Items.Sort();
            return new
            {
                ID = proj.ID,
                Name = proj.Name,
                Items = proj.Items
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public object[] GetPublicProjectsByName(string name)
        {
            var projects = projectRepository.GetProjectsByName(name);
            var result = (from p in projects
                         where p.Visibility == ProjectVisibility.Public
                         select new { 
                             Name = p.Name,
                             ID = p.ID
                         }).ToArray();
            return result;
        }

        [HttpPost]
        public IHttpActionResult CreateProject(Project model, [FromUri]ProjectVisibility visibility)
        {
            try
            {
                model.Visibility = visibility;
                var profile = usersRepository.GetCurrentUserProfile();
                usersRepository.Dispose();
                projectRepository.CreateProject(model, profile);
                return Ok();
            }
            catch (DbUpdateException e)
            {
                return BadRequest("A project with this name already exists.");
            }
            catch (Exception e)
            {
                return BadRequest("An error occured while trying to create a new project.");
            }
        }

        //TODO: Да се добави проверка дали текущия user е собственик на проекта
        //TODO: Логиката да се премести в repository-то
        [HttpPost]
        public IHttpActionResult UpdateProject([FromBody]ProjectSaveModel model, [FromUri]string name)
        {
            try {
                Project proj = projectRepository.GetProject(name);
                proj.Name = model.Name;
                proj.Visibility = model.Visibility;
                proj.RemoveAllParticipantsButOwner();
                List<KeyValuePair<UserProfile, Accessibility>> users = new List<KeyValuePair<UserProfile, Accessibility>>();

                for (int i = 0; i < model.Participants.Length; i++)
                {
                    if (model.Participants[i].AccessLevel == Accessibility.Owner)
                        continue;
                    var user = usersRepository.GetProfileByName(model.Participants[i].UserName);
                    users.Add(new KeyValuePair<UserProfile, Accessibility>(user, model.Participants[i].AccessLevel));
                }  
                usersRepository.Dispose();
                for (int i = 0; i < users.Count; i++)
                {
                    proj.Participations.Add(new Participation
                    {
                        ProjectReference = proj,
                        UserReference = users[i].Key,
                        AccessLevel = users[i].Value
                    });
                    projectRepository.GetContext().Entry(users[i].Key).State = EntityState.Unchanged;
                }

                projectRepository.GetContext().SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //TODO : Да се провери дали е owner текущия user
        //TODO : да се добави Confirm window на клиентската част
        [HttpDelete]
        public IHttpActionResult DeleteProject(string name)
        {
            try
            {
                projectRepository.DeleteProject(name);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}