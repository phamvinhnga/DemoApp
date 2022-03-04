using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DemoABC.EntityFramework.Entities
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        [StringLength(64)]
        public virtual string Surname { get; set; }

        [Required]
        [StringLength(64)]
        public virtual string Name { get; set; }

    }
}
