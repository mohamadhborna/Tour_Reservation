using Microsoft.AspNetCore.Mvc;
using Tour.Api.Controllers.Core;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers
{
    public class HotelInfoController : CrudControllerBase<HotelInfo, ICrudService<HotelInfo>>
    {
        public HotelInfoController(ICrudService<HotelInfo> service) : base(service)
        {
        }
    }
}