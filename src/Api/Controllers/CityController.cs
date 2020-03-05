using Microsoft.AspNetCore.Mvc;
using Tour.Api.Controllers.Core;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;
using Tour.Domain.DTOs;

namespace Tour.Api.Controllers
{
    public class CityController : CrudControllerBase<City, CityDto, ICrudService<CityDto>>
    {
        public CityController(ICrudService<CityDto> service) : base(service)
        {
        }
    }
}