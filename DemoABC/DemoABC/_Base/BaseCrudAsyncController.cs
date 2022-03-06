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
    public class BaseCrudAsyncController<TEntity, TEntityInputDto, TEntityOutputDto, TPrimaryKey> : Controller 
        where TEntity : class
        where TEntityInputDto : IEntityDto<TPrimaryKey>
        where TEntityOutputDto : IEntityDto<TPrimaryKey>
        where TPrimaryKey : struct
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;
        
        public BaseCrudAsyncController(
            IRepository<TEntity, TPrimaryKey> repository
        )
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntityOutputDto>> GetAsync(TPrimaryKey id)
        {
            var entity = await _repository.GetAsync(id);

            if (entity == null)
            {
                return NotFound($"Can't find Id { id }");
            }

            return entity.JsonMapTo<TEntityOutputDto>();
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
        public virtual async Task<IActionResult> UpdateAsync([FromBody] TEntityInputDto input)
        {
            var entity = await _repository.GetAsync(input.Id);

            if (entity == null)
            {
                return NotFound($"Can't find Id { input }");
            }

            await _repository.UpdateAsync(input.JsonMapTo<TEntity>());

            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(TPrimaryKey id)
        {
            var entity = await _repository.GetAsync(id);

            if (entity == null)
            {
                return NotFound($"Can't find Id { id }");
            }

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
