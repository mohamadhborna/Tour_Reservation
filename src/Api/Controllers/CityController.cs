using Microsoft.AspNetCore.Mvc;
using Tour.Api.Controllers.Core;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers
{
    public class CityController : CrudControllerBase<City, ICrudService<City>>
    {
        public CityController(ICrudService<City> service) : base(service)
        {
        }
    }
}