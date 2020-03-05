using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;
using Tour.Domain.DTOs;

namespace Tour.Api.Controllers.Core
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CrudControllerBase<TEntity, TDto, TService> : Controller
        where TEntity : EntityBase
        where TDto : DtoBase
        where TService : ICrudService<TDto>
    {
        private readonly TService _service;

        public CrudControllerBase(TService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var entities = await _service.GetAllAsync();
            // _mapper.Map<List<TDto>>(entities)
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TDto dtoInfo)
        {
            await _service.AddAsync(dtoInfo);
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
        public async Task<IActionResult> UpdateAsync([FromBody] TDto dtoInfo)
        {
            await _service.UpdateAsync(dtoInfo);
            return Ok();
        }
    }
}