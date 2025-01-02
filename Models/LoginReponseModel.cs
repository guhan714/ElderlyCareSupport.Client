using System.Text.Json.Serialization;

namespace ElderlyCareSupport.Client.Models;

public class LoginReponseModel
{
    public class LoginResponse
    {
        [JsonPropertyName("accessToken")] public string AccessToken { get; set; } = string.Empty;
        [JsonPropertyName("expiresIn")] public int ExpiresIn { get; set; }
        [JsonPropertyName("refreshToken")] public string RefreshToken { get; set; } = string.Empty;
    }

    [JsonPropertyName("item1")] public LoginResponse? LoginApiResponse { get; set; }
    [JsonPropertyName("item2")] public bool IsSuccess { get; set; }
}