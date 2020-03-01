using Microsoft.AspNetCore.Mvc;
using Tour.Api.Controllers.Core;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;
using Tour.Domain.DTOs;

namespace Tour.Api.Controllers
{
    public class HotelInfoController : CrudControllerBase<HotelInfo, HotelInfoDto, ICrudService<HotelInfoDto>>
    {
        public HotelInfoController(ICrudService<HotelInfoDto> service) : base(service)
        {
        }
    }
}