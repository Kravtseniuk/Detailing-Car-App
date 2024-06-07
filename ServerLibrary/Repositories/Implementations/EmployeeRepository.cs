using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class EmployeeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Employee>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var emp = await appDbContext.Employees.FindAsync(id);
            if (emp is null) return NotFound();

            appDbContext.Employees.Remove(emp);
            await Commit();
            return Success();
        }

        public async Task<List<Employee>> GetAll() => await appDbContext.Employees.ToListAsync();

        public async Task<Employee> GetById(int id) => await appDbContext.Employees.FindAsync(id);

        public async Task<GeneralResponse> Insert(Employee item)
        {
            if (!await CheckName(item.Fullname!)) return new GeneralResponse(false, "Employee already added");
            appDbContext.Employees.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Employee item)
        {
            var employee = await appDbContext.Employees.FindAsync(item.Id);
            if (employee is null) return NotFound();
            employee.Fullname = item.Fullname;
            employee.TelephoneNumber = item.TelephoneNumber;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry company service not found");
        private static GeneralResponse Success() => new(true, "Proccess comleted");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.CompanyServices.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}