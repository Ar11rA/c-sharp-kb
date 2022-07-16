using System.Text.Json.Serialization;

namespace QuoteFetcher.DTO;

public class CustomerMedicalData
{
    [JsonPropertyName("total_pages")] public int TotalPages { get; set; }

    [JsonPropertyName("data")] public List<MedicalDiagnosis> Data { get; set; } 
}
