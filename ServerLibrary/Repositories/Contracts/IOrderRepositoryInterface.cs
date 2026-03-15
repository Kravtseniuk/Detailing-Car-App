using BaseLibrary.DTOs;
using BaseLibrary.Responses;

namespace ServerLibrary.Repositories.Contracts
{
    public interface IOrderRepositoryInterface<T> : IGenericRepositoryInterface<T>
    {
        Task<List<GetOrdersDto>> GetAllOrdersAsync();
        Task<int> SaveOrderAsync(SaveOrderDto saveOrderDto);
    }
}
