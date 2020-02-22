using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class HotelInfosController : Controller
    {
        private readonly IHotelInfoService _hotelInfoService;

        public HotelInfosController(IHotelInfoService hotelInfoService)
        {
            _hotelInfoService = hotelInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var hotelInfos = await _hotelInfoService.Get();
            return Ok(hotelInfos);

        }

        [HttpPost]
        public async Task<IActionResult> AddHotelInfo(HotelInfo hotelInfo)
        {
            await _hotelInfoService.Create(hotelInfo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelInfo(int id)
        {
            var deletedHotelInfo = await _hotelInfoService.Delete(id);
            if (deletedHotelInfo == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}