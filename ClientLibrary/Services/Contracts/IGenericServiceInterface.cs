using BaseLibrary.DTOs;
using BaseLibrary.DTOs.Order;
using BaseLibrary.Responses;

namespace ClientLibrary.Services.Contracts
{
    public interface IGenericServiceInterface<T>
    {
        Task<List<T>> GetAll(string baseUrl);

        Task<GeneralResponse> InsertOrder(T item, string baseUrl);
        Task<List<EmployeeDto>> GetAllEmployeesAsync(string baseUrl);
        Task<List<GetOrdersDto>> GetAllOrdersAsync(string baseUrl);
        Task<List<CompanyServiceDto>> GetCompanyServiceForDropdown(string baseUrl);

        Task<T> GetById(int id, string baseUrl);
        Task<GeneralResponse> Insert(T item, string baseUrl);
        Task<GeneralResponse> Update(T item, string baseUrl);
        Task<GeneralResponse> DeleteById(int id, string baseUrl);
    }
}