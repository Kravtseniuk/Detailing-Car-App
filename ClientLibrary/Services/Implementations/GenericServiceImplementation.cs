using BaseLibrary.DTOs;
using BaseLibrary.DTOs.Order;
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using System.Net.Http.Json;

namespace ClientLibrary.Services.Implementations
{
    public class GenericServiceImplementation<T>(GetHttpClient getHttpClient) : IGenericServiceInterface<T>
    {
        //Create
        public async Task<GeneralResponse> Insert(T item, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}/add", item);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        public async Task<GeneralResponse> InsertOrder(T item, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}/save", item);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        //Read All
        public async Task<List<T>> GetAll(string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<T>>($"{baseUrl}/all");
            return results!;
        }

        public async Task<List<EmployeeDto>> GetAllEmployeesAsync(string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<EmployeeDto>>($"{baseUrl}/allemployees");
            return results ?? new();
        }

        //GetServices for Dropdown
        public async Task<List<CompanyServiceDto>> GetCompanyServiceForDropdown(string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<CompanyServiceDto>>($"{baseUrl}/servicesfordropdown");
            return results ?? new();
        }

        //GetOrders Single
        public async Task<List<GetOrdersDto>> GetAllOrdersAsync(string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<GetOrdersDto>>($"{baseUrl}/getallorders");
            return results!;
        }

        //Read Single {id}
        public async Task<T> GetById(int id, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<T>($"{baseUrl}/single/{id}");
            return result!;
        }

        //Update {model}
        public async Task<GeneralResponse> Update(T item, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PutAsJsonAsync($"{baseUrl}/update", item);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        //Delete {id}
        public async Task<GeneralResponse> DeleteById(int id, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.DeleteAsync($"{baseUrl}/delete/{id}");
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        public async Task<GeneralResponse> UpdateOrderStatusAsync(UpdateOrderStatusDto dto, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PutAsJsonAsync($"{baseUrl}/update-status", dto);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }
    }
}