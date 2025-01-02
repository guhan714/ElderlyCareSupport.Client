using CurrieTechnologies.Razor.SweetAlert2;
using ElderlyCareSupport.Client.Components;
using ElderlyCareSupport.Client.Interfaces;
using ElderlyCareSupport.Client.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ElderlyCareSupport.Client.Pages;

public partial class LoginPage : ComponentBase
{
    private string email;
    private string password;
    private UserType _userType;
    private MudForm loginForm;

    [Inject] private ILoginService LoginService { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IAlertService<SweetAlertOptions, SweetAlert> SweetAlertService { get; set; } = null!;
    [Inject] private IAlertService<Snackbar, List<SnackbarModel>> SnackBarService { get; set; } = null!;
    [Inject] private ILoaderService LoaderService { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    private string ValidationMessage { get; set; } = string.Empty;


    private async Task HandleLoginAsync()
    {
        if (_userType is 0)
        {
            ValidationMessage = "Please select the user type";
            return;
        }

        await LoaderService.StartLoaderAsync(1000);
        var isAuthenticatedUser =
            await LoginService.AuthenticateUser<LoginReponseModel?>(email.TrimEnd(), password.TrimEnd(), _userType);
        await LoaderService.StopLoaderAsync();

        if (isAuthenticatedUser?.Errors is not null && isAuthenticatedUser?.Errors.Count != 0)
            await HandleErrorAsync(isAuthenticatedUser?.Errors?.ToList());

        switch (isAuthenticatedUser)
        {
            case { Success: false, StatusCode: 401 or 500 } :
                await ShowErrorAlert(isAuthenticatedUser.ErrorMessage);
                return;
            case { StatusCode: 200 }:
                await ShowSuccess();
                break;
        }
    }

    private async Task HandleErrorAsync(List<Error>? errors)
    {
        var snackBarList = errors?.Select(error => new SnackbarModel
        {
            Message = error.ErrorMessage,
            Duration = 3,
            ActionText = "Dismiss",
            Action = () => { },
        }).ToList();
        await SnackBarService.AlertAsync(null, snackBarList);
    }


    private async Task ShowErrorAlert(string? errorMessage)
    {
        await SweetAlertService.AlertAsync(new SweetAlertOptions()
        {
            Title = "Login Failed.",
            Text = errorMessage ?? "Invalid Credentials. Please check.",
            Icon = SweetAlertIcon.Error,
            ShowCancelButton = true,
            ConfirmButtonText = "Retry",
            CancelButtonText = "Close",
            Backdrop = false,
            ShowLoaderOnConfirm = true
        }, null);
    }

    private async Task ShowSuccess()
    {
        await SweetAlertService.AlertAsync(new SweetAlertOptions
        {
            Title = "Successfully Logged in",
            Text = "You will be redirected to the ",
            Icon = SweetAlertIcon.Success,
            ShowCancelButton = true,
            ConfirmButtonText = "Ok",
            Backdrop = false
        }, null);
    }
}