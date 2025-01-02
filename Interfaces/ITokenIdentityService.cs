namespace ElderlyCareSupport.Client.Interfaces;

public interface ITokenIdentityService
{
    Task<string> GetItemAsync(string key);
    Task SetItemAsync(string key, string value);
    Task RemoveItemAsync(string key);
}