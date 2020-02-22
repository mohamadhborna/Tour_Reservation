using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TransportationInfosController : Controller
    {
        private readonly ITransportationInfoService _transportationInfoService;

        public TransportationInfosController(ITransportationInfoService transportationInfo)
        {
            _transportationInfoService = transportationInfo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var hotelInfos = await _transportationInfoService.Get();
            return Ok(hotelInfos);

        }

        [HttpPost]
        public async Task<IActionResult> AddTransportationInfo(TransportationInfo transportationInfo)
        {
            await _transportationInfoService.Create(transportationInfo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransportationInfo(int id)
        {
            var deletedTransportationInfo = await _transportationInfoService.Delete(id);
            if (deletedTransportationInfo == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}