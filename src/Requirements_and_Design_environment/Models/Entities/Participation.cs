using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Requirements_and_Design_environment.Models.Enums;
using System.Runtime.Serialization;

namespace Requirements_and_Design_environment.Models.Entities
{
    [Table("Participations")]
    [DataContract(IsReference = true)]
    public class Participation
    {
        [ForeignKey("ProjectID")]
        [DataMember]
        public virtual Project ProjectReference { get; set; }
        [ForeignKey("UserID")]
        [DataMember]
        public virtual UserProfile UserReference { get; set; }

        [Key, Column(Order = 0)]
        public int ProjectID { get; set; }
        [Key, Column(Order = 1)]
        public int UserID { get; set; }
        [DataMember]
        public Accessibility AccessLevel { get; set; }
    }
}