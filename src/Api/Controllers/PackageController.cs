using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tour.Domain.Interfaces.Service;
using Tour.Domain.Entities;
using Tour.Api.Controllers.Core;

namespace Tour.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PackagesController : BaseController<IPackageService, Package>
    {
        private readonly IPackageService _packageService;

        public PackagesController(IPackageService packageService) : base(packageService)
        {
            _packageService = packageService;
        }

 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Package package, long id)
        {
            await _packageService.Update(package);
            return Ok();
        }

    }
}