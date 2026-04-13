using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeRepositoryInterface<Employee> emloyeeRepositoryInterface)
        : GenericController<Employee>(emloyeeRepositoryInterface)
    {
        [HttpGet("allemployees")]
        public async Task<IActionResult> GetAll()
        {
            var employees = await emloyeeRepositoryInterface.GetAllEmployeesAsync();
            return Ok(employees);
        }
    }
}