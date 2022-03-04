using DemoABC.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Dtos
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }

        public string CodeValue { get; set; }

        public string Name { get; set; }
    }

    public class OrganizationInputDto : OrganizationDto
    {
    }

    public class OrganizationOutputDto : OrganizationDto
    {
        public string Titles { get; set; }

        public virtual IEnumerable<UserOrganization> UserOrganizations { get; set; }
    }
}
