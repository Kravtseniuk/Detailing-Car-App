using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class CustomerRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Customer>
    {
        public Task<GeneralResponse> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAll() => await appDbContext.Customers
            .Include(c => c.Orders)
            .ToListAsync();

        public Task<Customer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> Insert(Customer item)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}