using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tour.Domain.Interfaces;
using Tour.Domain.Entities;

namespace Tour.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PackagesController : Controller
    {
        private readonly IPackageService _packageService;

        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Package package)
        {
            await _packageService.Create(package);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var packages = await _packageService.Get();
            return Ok(packages);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Package package, long id)
        {
            await _packageService.Update(package);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deletedPackage = await _packageService.Delete(id);
            if (deletedPackage == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}