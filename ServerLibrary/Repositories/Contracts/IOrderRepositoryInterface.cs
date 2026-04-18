using BaseLibrary.DTOs.Order;
using BaseLibrary.Responses;

namespace ServerLibrary.Repositories.Contracts
{
    public interface IOrderRepositoryInterface<T> : IGenericRepositoryInterface<T>
    {
        Task<List<GetOrdersDto>> GetAllOrdersAsync();
        Task<int> SaveOrderAsync(SaveOrderDto saveOrderDto);
        Task<bool> UpdateStatusAsync(UpdateOrderStatusDto dto);
    }
}
