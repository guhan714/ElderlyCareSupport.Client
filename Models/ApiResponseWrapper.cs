using System.Text.Json.Serialization;

namespace ElderlyCareSupport.Client.Models;

public class ApiResponseWrapper<T>
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    [JsonPropertyName("data")]
    public T Data { get; set; } = default!;
    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }
    [JsonPropertyName("statusMessage")]
    public string StatusMessage { get; set; } = string.Empty;
    [JsonPropertyName("errorMessage")]
    public string ErrorMessage { get; set; } = string.Empty;
    [JsonPropertyName("errors")] 
    public List<Error> Errors { get; set; } = [];
}

public class Error
{
    [JsonPropertyName("errorName")] 
    public string ErrorMessage { get; set; } = string.Empty;
}