using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        [StringLength(64)]
        public string Surname { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }
    }

    public class RegisterUserInputDto : RegisterUserDto
    {
        public string Password { get; set; }
    }

    public class RegisterUserOutputDto : RegisterUserDto
    {
        public Guid Id { get; set; }
    }
}
