using DemoABC.Base.interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoABC.EntityFramework.Entities
{
    [Table("UserOrganizations", Schema = "dbo")]
    public class UserOrganization : IEntity<Guid>
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid TitleId { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }

        [ForeignKey("TitleId")]
        public virtual Title Title { get; set; }
    }
}
