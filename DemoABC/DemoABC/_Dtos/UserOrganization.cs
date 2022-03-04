using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Dtos
{
    public class UserOrganizationDto
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid TitleId { get; set; }

        public Guid UserId { get; set; }
    }

    public class UserOrganizationInputDto : UserOrganizationDto
    {
    }

    public class UserOrganizationOutputDto : UserOrganizationDto
    {
        public UserInfoUserOrganizationDto User { get; set; }

        public InfoOrganizationInUserOrganizationDto Organization { get; set; }

        public InfoTitleInUserOrganizationDto Title { get; set; }
    }

    public class InfoOrganizationInUserOrganizationDto
    {
        public string Name { get; set; }

        public string CodeValue { get; set; }
    }

    public class UserInfoUserOrganizationDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }

    public class InfoTitleInUserOrganizationDto
    {
        public string CodeValue { get; set; }

        public string Name { get; set; }
    }
}
