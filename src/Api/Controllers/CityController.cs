using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _cityService.Get();
            return Ok(cities);

        }

        [HttpPost]
        public async Task<IActionResult> AddCity(City city)
        {
            await _cityService.Create(city);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var deletedCity = await _cityService.Delete(id);
            if (deletedCity == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}