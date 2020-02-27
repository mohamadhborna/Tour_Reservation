using Microsoft.AspNetCore.Mvc;
using Tour.Api.Controllers.Core;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TransportationInfosController : BaseController<IService<TransportationInfo>, TransportationInfo>
    {
        public TransportationInfosController(IService<TransportationInfo> transportationInfo) : base(transportationInfo)
        {
        }
    }
}