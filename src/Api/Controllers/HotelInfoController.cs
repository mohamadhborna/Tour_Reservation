using Microsoft.AspNetCore.Mvc;
using Tour.Api.Controllers.Core;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class HotelInfosController : BaseController<IService<HotelInfo>, HotelInfo>
    {
        public HotelInfosController(IService<HotelInfo> service) : base(service)
        {
        }
    }
}