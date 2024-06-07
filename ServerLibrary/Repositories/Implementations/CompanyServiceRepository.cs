using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class CompanyServiceRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<CompanyService>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDbContext.CompanyServices.FindAsync(id);
            if (dep is null) return NotFound();

            appDbContext.CompanyServices.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<CompanyService>> GetAll() => await appDbContext.CompanyServices.ToListAsync();

        public async Task<CompanyService> GetById(int id) => await appDbContext.CompanyServices.FindAsync(id);

        public async Task<GeneralResponse> Insert(CompanyService item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Company Service already added");
            appDbContext.CompanyServices.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(CompanyService item)
        {
            var companyService = await appDbContext.CompanyServices.FindAsync(item.Id);
            if (companyService is null) return NotFound();
            companyService.Name = item.Name;
            companyService.Price = item.Price;
            companyService.Category = item.Category;
            companyService.Description = item.Description;
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
