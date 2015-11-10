using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;
using Requirements_and_Design_environment.Models.Enums;

namespace Requirements_and_Design_environment.Models.Entities
{

    [Table("Project")]
    [DataContract(IsReference=true)]
    public class Project
    {
        public Project()
        {
            Participations = new List<Participation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(225)]
        [Index(IsUnique=true)]
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ProjectVisibility Visibility { get; set; }

        [DataMember]
        public virtual List<Participation> Participations { get; set; }

        [DataMember]
        public virtual List<Item> Items { get; set; }

        public void RemoveAllParticipantsButOwner()
        {
            for (int i = 0; i < Participations.Count; i++)
            {
                if (Participations[i].AccessLevel == Accessibility.Owner)
                    continue;
                Participations.Remove(Participations[i]);
                i--;
            }
        }
    }
}
