using DemoABC.Base.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.EntityFramework.Entities
{
    [Table("Titles", Schema = "dbo")]
    public class Title : Entity<Guid>
    {
        public string CodeValue { get; set; }

        public string Name { get; set; }
    }
}
