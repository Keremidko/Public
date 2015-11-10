using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Requirements_and_Design_environment.Models.Enums;

namespace Requirements_and_Design_environment.Models.ClientModels
{
    public class ProjectSaveModel
    {
        public string Name { get; set; }
        public ProjectVisibility Visibility { get; set; }
        public UserParticipantModel[] Participants { get; set; }
    }

    public class UserParticipantModel
    {
        public string UserName { get; set; }
        public Accessibility AccessLevel { get; set; }
    }
}