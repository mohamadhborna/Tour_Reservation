using Microsoft.AspNetCore.Mvc;
using Tour.Api.Controllers.Core;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CitiesController : BaseController<IService<City> , City>
    {
        public CitiesController(IService<City> service) : base(service)
        {
        }
    }
}