using CurrieTechnologies.Razor.SweetAlert2;
using ElderlyCareSupport.Client.Interfaces;
using Microsoft.JSInterop;

namespace ElderlyCareSupport.Client.Components;

public class Loader : ILoaderService
{
    private readonly SweetAlertService _sweetAlertService;
    private readonly IJSRuntime _jsRuntime;

    public Loader(SweetAlertService sweetAlertService, IJSRuntime jsRuntime)
    {
        _sweetAlertService = sweetAlertService;
        _jsRuntime = jsRuntime;
    }

    public async Task StartLoaderAsync(int delay)
    {
        await _sweetAlertService.ShowLoadingAsync();
        await _jsRuntime.InvokeVoidAsync("document.body.classList.add", "no-interaction");
        await Task.Delay(delay);
    }

    public async Task StopLoaderAsync()
    {
        await _sweetAlertService.CloseAsync();
        await _jsRuntime.InvokeVoidAsync("document.body.classList.remove", "no-interaction");
    }
}