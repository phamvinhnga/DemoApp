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
    public class OrganizationManager
    {
        private readonly IRepository<Organization, Guid> _organizationRepository;

        public OrganizationManager(
            IRepository<Organization, Guid> organizationRepository
        )
        {
            _organizationRepository = organizationRepository;
        }

        public async Task UpdateTitleOrganizationAsync(TitleOrganizationInputDto input)
        {
            var entity = await _organizationRepository.GetAsync(input.Id);

            if(entity != null)
            {
                entity.Titles = input.ListTitle.ConvertToJson();
                await _organizationRepository.UpdateAsync(entity);
            }
        
        }
    }
}
