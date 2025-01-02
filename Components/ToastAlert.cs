using CurrieTechnologies.Razor.SweetAlert2;
using ElderlyCareSupport.Client.Interfaces;
using ElderlyCareSupport.Client.Models;
using MudBlazor;

namespace ElderlyCareSupport.Client.Components;

public class ToastAlert : IAlertService<Snackbar, List<SnackbarModel>>
{
    private readonly ISnackbar _snackbar;

    public ToastAlert(ISnackbar snackbar)
    {
        _snackbar = snackbar;
    }

    public async Task AlertAsync(Snackbar? snackbar, List<SnackbarModel>? snackbarList )
    {
        if (snackbarList != null)
            foreach (var error in snackbarList)
            {
                _snackbar.Add(error.Message, Severity.Error);
                await Task.Delay(error.Duration);
            }
    }
}