using CurrieTechnologies.Razor.SweetAlert2;
using ElderlyCareSupport.Client.Components;
using ElderlyCareSupport.Client.Interfaces;
using ElderlyCareSupport.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace ElderlyCareSupport.Client.Pages;

public partial class Home : ComponentBase
{
    [Inject] private NavigationManager NavigationManagerAsync { get; set; } = default!;
    [Inject] private ILoaderService AlertService { get; set; } = default!;
    [Inject] private IFeeService FeeService { get; set; } = default!;
    private IEnumerable<FeeModel>? _feeDetails = Enumerable.Empty<FeeModel>();


    protected override async Task OnInitializedAsync()
    {
        var responseWrapper = await FeeService.GetFeeDetails();

        _feeDetails = responseWrapper.Data;
    }

    private async Task HandleLogin()
    {
        await AlertService.StartLoaderAsync(1000);
        NavigationManagerAsync.NavigateTo("/LoginPage", true);
        await AlertService.StopLoaderAsync();
    }
}