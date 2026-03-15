using BaseLibrary.DTOs;

namespace ServerLibrary.Repositories.Contracts
{
    public interface IEmployeeRepositoryInterface<T> : IGenericRepositoryInterface<T>
    {
        Task<List<EmployeeDto>> GetAllEmployeesAsync();
    }
}
