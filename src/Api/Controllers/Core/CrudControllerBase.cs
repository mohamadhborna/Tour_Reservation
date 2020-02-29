using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers.Core
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CrudControllerBase<TEntity, TService> : Controller
        where TEntity : EntityBase
        where TService : ICrudService<TEntity>
    {
        private readonly TService _service;

        public CrudControllerBase(TService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var cities = await _service.GetAllAsync();
            return Ok(cities);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TEntity entityInfo)
        {
            await _service.AddAsync(entityInfo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deletedCity = await _service.DeleteAsync(id);

            if (deletedCity == null)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] TEntity package)
        {
            await _service.UpdateAsync(package);
            return Ok();
        }
    }
}