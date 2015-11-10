using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;
using Requirements_and_Design_environment.Models.Enums;


namespace Requirements_and_Design_environment.Models.Entities
{
    [Table("Templates")]
    public class Template
    {
        public int ID { get; set; }
        public string Contents { get; set; }
    }
}