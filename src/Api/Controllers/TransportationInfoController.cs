using Microsoft.AspNetCore.Mvc;
using Tour.Api.Controllers.Core;
using Tour.Domain.Interfaces.Service.Core;
using Tour.Domain.DTOs;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers
{
    public class TransportationInfoController : CrudControllerBase<TransportationInfo, TransportationInfoDto, ICrudService<TransportationInfoDto>>
    {
        public TransportationInfoController(ICrudService<TransportationInfoDto> transportationInfo) : base(transportationInfo)
        {
        }
    }
}