using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class OrderRepository(AppDbContext appDbContext) : IOrderRepositoryInterface<Order>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var emp = await appDbContext.Orders.FindAsync(id);
            if (emp is null) return NotFound();

            appDbContext.Orders.Remove(emp);
            await Commit();
            return Success();
        }

        public async Task<List<Order>> GetAll() => await appDbContext.Orders.ToListAsync();

        public async Task<Order> GetById(int id) => await appDbContext.Orders.FindAsync(id);

        public async Task<GeneralResponse> Insert(Order item)
        {
            if (!await CheckName(item.OrderName!)) return new GeneralResponse(false, "Order already added");
            appDbContext.Orders.Add(item);
            await Commit();
            return Success();
        }

        public async Task<List<GetOrdersDto>> GetAllOrdersAsync()
        {
            var orders = await appDbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.ExecutorOfTheWork)
                .Select(o => new GetOrdersDto
                {
                    Id = o.Id,
                    OrderName = o.OrderName,
                    CustomerName = o.Customer.FullName,
                    CustomerAuto = o.Customer.Auto,
                    PriceForServices = o.TotalPrice ?? 0,
                    ExecutorOfWork = o.ExecutorOfTheWork.FullName,
                    WorkStartTime = o.WorkStartTime ?? TimeSpan.Zero,
                    WorkEndTime = o.WorkEndTime ?? TimeSpan.Zero
                })
                .ToListAsync();

            return orders;
        }

        public async Task<int> SaveOrderAsync(SaveOrderDto saveOrderDto)
        {
            var customer = await appDbContext.Customers
                .FirstOrDefaultAsync(c => c.FullName == saveOrderDto.CustomerFullName && c.TelephoneNumber == saveOrderDto.CustomerPhone);

            if (customer == null)
            {
                customer = new Customer
                {
                    FullName = saveOrderDto.CustomerFullName,
                    Auto = saveOrderDto.CustomerAuto,
                    TelephoneNumber = saveOrderDto.CustomerPhone
                };

                appDbContext.Customers.Add(customer);
                await appDbContext.SaveChangesAsync();
            }

            var order = new Order
            {
                OrderName = saveOrderDto.OrderName,
                DateCreated = saveOrderDto.DateCreated,
                CustomerId = customer.Id,
                Status = OrderStatus.Pending,
                TotalPrice = saveOrderDto.TotalPrice,
                WorkStartTime = saveOrderDto.WorkStartTime,
                WorkEndTime = saveOrderDto.WorkEndTime,
                EmployeeId = saveOrderDto.EmployeeId
            };

            appDbContext.Orders.Add(order);
            await appDbContext.SaveChangesAsync();

            return order.Id;
        }


        public async Task<GeneralResponse> Update(Order item)
        {
            var order = await appDbContext.Orders.FindAsync(item.Id);
            if (order is null) return NotFound();
            order.OrderName = item.OrderName;
            order.Status = item.Status;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry order not found");
        private static GeneralResponse Success() => new(true, "Proccess comleted");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Orders.FirstOrDefaultAsync(x => x.OrderName!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}