using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;
using Requirements_and_Design_environment.Models.Enums;

namespace Requirements_and_Design_environment.Models.Entities
{
    [Table("Items")]
    [DataContract]
    public class Item : IComparable<Item>
    {
        [Key]
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DataMember]
        public int ParentID { get; set; }

        [DataMember]
        public int ProjectID { get; set; }

        [StringLength(50)]
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ItemType Type { get; set; }

        [DataMember]
        public string Contents { get; set; }

        [IgnoreDataMember]
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        public int CompareTo(Item other)
        {
            return Type.CompareTo(other.Type);
        }

    }
}