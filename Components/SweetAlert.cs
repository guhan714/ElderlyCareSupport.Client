using CurrieTechnologies.Razor.SweetAlert2;
using ElderlyCareSupport.Client.Interfaces;

namespace ElderlyCareSupport.Client.Components;

public class SweetAlert : IAlertService<SweetAlertOptions, SweetAlert>
{
    private readonly SweetAlertService _sweetAlertService;

    public SweetAlert(SweetAlertService sweetAlertService)
    {
        _sweetAlertService = sweetAlertService;
    }


    public async Task AlertAsync(SweetAlertOptions? alertOptions, SweetAlert? alert)
    {
        await _sweetAlertService.FireAsync(alertOptions);
    }
    
}