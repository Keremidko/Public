using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
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
    public class ItemController : ApiController
    {
        private IProjectRepository projectRepository { get; set; }
        private IUsersRepository usersRepository { get; set; }

        public ItemController()
        {
            projectRepository = new ProjectRepository();
            usersRepository = new UsersRepository();
        }

        //TODO : Да се провери дали user-a има create права в текущия проект
        //TODO : Да се провери дали parentId-то на item-a е от тип folder
        //TODO : Уникално име на Item-a
        public IHttpActionResult CreateItem(Item item, int projectId, int templateId)
        {
            var user = System.Web.HttpContext.Current.User.Identity.Name;
            var proj = projectRepository.GetProject(projectId);

            var participation = proj.Participations.Find(x => x.UserReference.UserName == user);
            if (participation != null 
                && participation.AccessLevel >= Accessibility.Read_Edit_Create 
                || participation.AccessLevel == Accessibility.Owner)
                try
                {
                    item = projectRepository.AddItemToProject(item, projectId, templateId);
                    return Ok<Item>(item);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            else
                return BadRequest("You don't have rights to create items. Please ask your project manager to provide you with the rights before proceeding again.");
        }

        //TODO : Да се провери дали user-a има Edit права в текущия проект
        [HttpPost]
        public IHttpActionResult UpdateItem(ItemUpdateModel model)
        {
            try
            {
                projectRepository.UpdateItem(model.ItemId, model.Content);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        //TODO : Да се провери дали  user-a има Delete права в проекта
        public IHttpActionResult DeleteItem(int itemId)
        {
            var item = projectRepository.GetItem(itemId);
            var user = System.Web.HttpContext.Current.User.Identity.Name;
            var proj = item.Project;

            var participation = proj.Participations.Find(x => x.UserReference.UserName == user);
            if (participation != null 
                && participation.AccessLevel >= Accessibility.Read_Edit_Create_Delete
                || participation.AccessLevel == Accessibility.Owner)
                try
                {
                    projectRepository.DeleteItem(itemId);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            else
                return BadRequest("You don't have rights to delete this item. Please ask your project manager to provide you with the rights before proceeding again.");
        }
    }
}
