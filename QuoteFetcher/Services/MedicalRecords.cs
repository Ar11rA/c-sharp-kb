using System.Text.Json;
using QuoteFetcher.DTO;

namespace QuoteFetcher.Services;

public static class MedicalRecords
{
    public static async Task<List<int>> FilterRecordsIdsByAgeAndBp(int startAge, int endAge, int bpDiff)
    {
        int page = 1;
        HttpClient client = new();
        List<int> matchedIds = new();
        while (true)
        {
            string url =
                $"https://jsonmock.hackerrank.com/api/medical_records?page={page}";
            string jsonData = await client.GetStringAsync(url);
            CustomerMedicalData? response = JsonSerializer.Deserialize<CustomerMedicalData>(jsonData);
            if (response == null)
            {
                break;
            }

            matchedIds.AddRange(response.Data.Aggregate(new List<int>(), (acc, curr) =>
            {
                DateTime today = DateTime.Today;
                int userAge = today.Year - DateTime.ParseExact(curr.UserDateOfBirth, "dd-MM-yyyy", null).Year;
                if (userAge >= startAge && userAge <= endAge &&
                    bpDiff >= curr.Vitals.BloodPressureDiastole - curr.Vitals.BloodPressureSystole)
                {
                    acc.Add(curr.Id);
                }

                return acc;
            }));
            page++;
            if (page > response.TotalPages)
            {
                break;
            }
        }

        return matchedIds;
    }
}
