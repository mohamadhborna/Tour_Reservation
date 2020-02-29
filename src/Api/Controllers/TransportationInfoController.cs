using Microsoft.AspNetCore.Mvc;
using Tour.Api.Controllers.Core;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers
{
    public class TransportationInfoController : CrudControllerBase<TransportationInfo, ICrudService<TransportationInfo>>
    {
        public TransportationInfoController(ICrudService<TransportationInfo> transportationInfo) : base(transportationInfo)
        {
        }
    }
}