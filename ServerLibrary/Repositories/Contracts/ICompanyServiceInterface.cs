using BaseLibrary.DTOs;

namespace ServerLibrary.Repositories.Contracts
{
    public interface ICompanyServiceInterface<T> : IGenericRepositoryInterface<T>
    {
        Task<List<CompanyServiceDto>> GetServiceForDropdown();
    }
}
