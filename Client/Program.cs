using BaseLibrary.DTOs;
using BaseLibrary.DTOs.Order;
using BaseLibrary.Entities;
using Blazored.LocalStorage;
using Client;
using Client.ApplicationStates;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using ClientLibrary.Services.Implementations;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<CustomHttpHandler>();
builder.Services.AddHttpClient("SystemApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7185/");
}).AddHttpMessageHandler<CustomHttpHandler>();

builder.Services.AddSweetAlert2();
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

builder.Services.AddScoped<IGenericServiceInterface<CompanyService>, GenericServiceImplementation<CompanyService>>();
builder.Services.AddScoped<IGenericServiceInterface<Employee>, GenericServiceImplementation<Employee>>();
builder.Services.AddScoped<IGenericServiceInterface<Order>, GenericServiceImplementation<Order>>();

builder.Services.AddScoped<IGenericServiceInterface<CompanyServiceDto>, GenericServiceImplementation<CompanyServiceDto>>();
builder.Services.AddScoped<IGenericServiceInterface<SaveOrderDto>, GenericServiceImplementation<SaveOrderDto>>();
builder.Services.AddScoped<IGenericServiceInterface<EmployeeDto>, GenericServiceImplementation<EmployeeDto>>();

builder.Services.AddScoped<IUtilityService, UtilityService>();

builder.Services.AddScoped<AllState>();

await builder.Build().RunAsync();