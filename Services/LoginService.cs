using System.Collections;
using System.Text.Json;
using System.Text.Json.Nodes;
using ElderlyCareSupport.Client.Interfaces;
using ElderlyCareSupport.Client.Models;

namespace ElderlyCareSupport.Client.Services;

public class LoginService : ILoginService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenIdentityService _tokenIdentityService;

    public LoginService(HttpClient httpClient, ITokenIdentityService tokenIdentityService)
    {
        _httpClient = httpClient;
        _tokenIdentityService = tokenIdentityService;
    }

    public async Task<ApiResponseWrapper<T>?> AuthenticateUser<T>(string email, string password, UserType userType)
    {
        try
        {
            const string loginUri = "https://localhost:44313/api/ElderlyCareSupportAccount/Login";
            var loginRequest = new LoginRequestModel
            {
                Email = email,
                Password = password,
                UserType = userType
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(loginRequest), System.Text.Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync(loginUri, jsonContent);

            var responseContent = await response.Content.ReadAsStringAsync();
            
            var baseResponse = JsonSerializer.Deserialize<ApiResponseWrapper<LoginReponseModel>>(responseContent);
            if (baseResponse == null)
            {
                return null;
            }

            var finalResponse = new ApiResponseWrapper<LoginReponseModel?>
            {   
                Success = baseResponse.Success,
                StatusCode = baseResponse.StatusCode,
                StatusMessage = baseResponse.StatusMessage,
                ErrorMessage = baseResponse.ErrorMessage,
                Errors = baseResponse.Errors,
                Data = new LoginReponseModel{ LoginApiResponse = baseResponse.Data.LoginApiResponse, IsSuccess = baseResponse.Data.IsSuccess}
            };

            await _tokenIdentityService.SetItemAsync("accessToken", baseResponse?.Data?.LoginApiResponse?.AccessToken ?? string.Empty);
            await _tokenIdentityService.SetItemAsync("refreshToken", baseResponse?.Data?.LoginApiResponse?.RefreshToken ?? string.Empty);
            await _tokenIdentityService.SetItemAsync("expiresIn",baseResponse?.Data?.LoginApiResponse?.ExpiresIn.ToString() ?? string.Empty );
            return (finalResponse as ApiResponseWrapper<T?>)!;
        }
        catch (Exception e)
        {
            return new ApiResponseWrapper<T>() { Errors = [new Error { ErrorMessage = e.Message }] };
        }
    }
}