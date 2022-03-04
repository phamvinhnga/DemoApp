using DemoABC.Base.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Base
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class BaseCrudAsyncController<TEntity, TEntityInputDto, TEntityOutputDto> : Controller 
        where TEntity : class
        where TEntityInputDto : class 
        where TEntityOutputDto : class
    {
        private readonly IRepository<TEntity> _repository;
        
        public BaseCrudAsyncController(
            IRepository<TEntity> repository
        )
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<List<TEntityOutputDto>> GetListAsync()
        {
            var query = await _repository.GetListAsync();

            return query.JsonMapTo<List<TEntityOutputDto>>();
        }

        [HttpPost]
        public virtual async Task<TEntityOutputDto> CreateAsync([FromBody] TEntityInputDto input)
        {
            var query = await _repository.InsertAsync(input.JsonMapTo<TEntity>());

            return query.JsonMapTo<TEntityOutputDto>();
        }

        [HttpPut]
        public virtual async Task UpdateAsync([FromBody] TEntityInputDto input)
        {
            await _repository.UpdateAsync(input.JsonMapTo<TEntity>());
        }

        [HttpDelete]
        public virtual async Task DeleteAsync([FromBody] TEntityInputDto input)
        {
            await _repository.DeleteAsync(input.JsonMapTo<TEntity>());
        }
    }
}
