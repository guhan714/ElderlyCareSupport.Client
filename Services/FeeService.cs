using System.Net.Http.Json;
using ElderlyCareSupport.Client.Interfaces;
using ElderlyCareSupport.Client.Models;

namespace ElderlyCareSupport.Client.Services;

public class FeeService : IFeeService
{
    private readonly HttpClient _httpClient;

    public FeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponseWrapper<IEnumerable<FeeModel>>> GetFeeDetails()
    {
        var defaultResponse = new ApiResponseWrapper<IEnumerable<FeeModel>>();
        try
        {
            var feeDetails =
                await _httpClient.GetFromJsonAsync<ApiResponseWrapper<IEnumerable<FeeModel>>>(
                    "https://localhost:44313/api/ElderlyCareSupportAccount/GetFeeDetails");
            return feeDetails ?? defaultResponse;
        }
        catch (Exception e)
        {
            return defaultResponse;
        }
    }
}