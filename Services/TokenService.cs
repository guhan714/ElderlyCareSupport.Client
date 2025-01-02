using ElderlyCareSupport.Client.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace ElderlyCareSupport.Client.Services;

public class TokenService: ITokenIdentityService
{
    private readonly IJSRuntime _jsRuntime;

    public TokenService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<string> GetItemAsync(string key)
    {
        return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
    }

    public async Task SetItemAsync(string key, string value)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
    }

    public async Task RemoveItemAsync(string key)
    {
        await _jsRuntime.InvokeAsync<string>("localStorage.removeItem", key);
    }
}