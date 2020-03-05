using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Entities;
using Tour.Domain.DTOs;
using Tour.Api.Controllers.Core;

namespace Tour.Api.Controllers
{
    public class PackageController : CrudControllerBase<Package, PackageDto, IPackageService>
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService) : base(packageService)
        {
            _packageService = packageService;
        }

    }
}