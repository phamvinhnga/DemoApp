using DemoABC.Base.interfaces;
using DemoABC.Base;
using DemoABC.Dtos;
using DemoABC.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Business.Managers
{
    public class TitleManager
    {
        private readonly IRepository<Title, Guid> _titleRepository;
        private readonly IRepository<Organization, Guid> _organizationRepository;

        public TitleManager(
            IRepository<Title, Guid> titleRepository,
            IRepository<Organization, Guid> organizationRepository
        )
        {
            _titleRepository = titleRepository;
            _organizationRepository = organizationRepository;
        }

        public Task UpdateTitleOrganization(Title input)
        {
            return null;
        }

        public Task DeleteTitleOrganization(Guid id)
        {
            return null;
        }
    }
}
