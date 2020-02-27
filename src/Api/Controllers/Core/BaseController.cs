using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers.Core
{
    [ApiController]
    public class BaseController<S, E> : Controller
    where S : IService<E>
    where E : BaseEntity
    {
        private readonly S _service;

        public BaseController(S service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cities = await _service.Get();
            return Ok(cities);
        }

        [HttpPost]
        public async Task<IActionResult> Add(E entityInfo)
        {
            await _service.Create(entityInfo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedCity = await _service.Delete(id);
            if (deletedCity == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}