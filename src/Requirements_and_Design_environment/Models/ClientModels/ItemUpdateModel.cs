using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Requirements_and_Design_environment.Models.Enums;

namespace Requirements_and_Design_environment.Models.ClientModels
{
    public class ItemUpdateModel
    {
        public int ItemId { get; set; }
        public string Content { get; set; }
    }
}