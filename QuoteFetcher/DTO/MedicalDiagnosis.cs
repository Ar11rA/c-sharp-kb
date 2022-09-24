using System.Text.Json.Serialization;

namespace QuoteFetcher.DTO;

public class MedicalDiagnosis
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("userDob")] public string UserDateOfBirth { get; set; }
    [JsonPropertyName("vitals")] public BpVitals Vitals { get; set; }
}
