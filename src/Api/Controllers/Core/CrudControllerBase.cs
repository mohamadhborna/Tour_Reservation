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
    public class CrudControllerBase<TEntity, TEntityDto, TService> : Controller
        where TEntity : EntityBase
        where TEntityDto : EntityDtoBase
        where TService : ICrudService<TEntityDto>
    {
        private readonly TService _service;

        public CrudControllerBase(TService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(TEntityDto entityDto)
        {
            if (entityDto.Id == default)
                await _service.AddAsync(entityDto);
            else
                await _service.UpdateAsync(entityDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}