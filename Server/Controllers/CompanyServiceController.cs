using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyServiceController(ICompanyServiceInterface<CompanyService> companyServiceInterface)
        : GenericController<CompanyService>(companyServiceInterface)
    {
        [HttpGet("servicesfordropdown")]
        public async Task<IActionResult> GetServicesForDropdown()
        {
            var services = await companyServiceInterface.GetServiceForDropdown();
            return Ok(services);
        }
    }
}