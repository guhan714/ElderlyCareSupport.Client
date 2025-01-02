using CurrieTechnologies.Razor.SweetAlert2;
using ElderlyCareSupport.Client;
using ElderlyCareSupport.Client.Components;
using ElderlyCareSupport.Client.Interfaces;
using ElderlyCareSupport.Client.Models;
using ElderlyCareSupport.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



builder.Services.AddMudServices();
builder.Services.AddSweetAlert2();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<ITokenIdentityService, TokenService>();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IFeeService, FeeService>();

builder.Services.AddScoped<ILoaderService, Loader>();
builder.Services.AddScoped<IAlertService<SweetAlertOptions,SweetAlert>, SweetAlert>();
builder.Services.AddScoped<IAlertService<Snackbar,List<SnackbarModel>>,ToastAlert>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
