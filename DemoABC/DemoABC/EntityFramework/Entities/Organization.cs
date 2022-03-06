using DemoABC.Base.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoABC.EntityFramework.Entities
{
    [Table("Organizations", Schema = "dbo")]
    public class Organization : Entity<Guid>
    {
        public string CodeValue { get; set; }

        public string Name { get; set; }

        public string Titles { get; set; }

        public virtual IEnumerable<UserOrganization> UserOrganizations { get; set; }
    }
}
