using DemoABC.Base;
using DemoABC.Base.interfaces;
using DemoABC.Business.Managers;
using DemoABC.Dtos;
using DemoABC.EntityFramework.Entities;
using DemoABC.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Business.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrganizationController : BaseCrudAsyncController<Organization, OrganizationInputDto, OrganizationOutputDto, Guid>
    {
        private readonly OrganizationManager _organizationManager;

        public OrganizationController(
            IRepository<Organization, Guid> repository,
            OrganizationManager organizationManager) : base(repository)
        {
            _organizationManager = organizationManager;
        }

        [NotAllowSpecialCharacters("CodeValue")]
        public override Task<OrganizationOutputDto> CreateAsync([FromBody] OrganizationInputDto input)
        {
            return base.CreateAsync(input);
        }

        [NotAllowSpecialCharacters("CodeValue")]
        public override Task<IActionResult> UpdateAsync([FromBody] OrganizationInputDto input)
        {
            return base.UpdateAsync(input);
        }

        [HttpPut]
        public Task UpdateTitleOrganizationAsync([FromBody] TitleOrganizationInputDto input)
        {
            return _organizationManager.UpdateTitleOrganizationAsync(input);
        }
    }
}
