using System.Text.Json.Serialization;

namespace ElderlyCareSupport.Client.Models;

public class FeeModel
{
    [JsonPropertyName("feeId")] public long FeeId { get; set; }
    [JsonPropertyName("feeName")] public string FeeName { get; set; } = string.Empty;
    [JsonPropertyName("feeAmount")] public long FeeAmount { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
}