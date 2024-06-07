using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyServiceController(IGenericRepositoryInterface<CompanyService> genericRepositoryInterface)
        : GenericController<CompanyService>(genericRepositoryInterface)
    {
    }
}