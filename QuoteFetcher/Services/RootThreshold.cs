using System.Text.Json;
using QuoteFetcher.DTO;

namespace QuoteFetcher.Services;

public static class RootThreshold
{
    private static int CountDevicesAboveThresholdForDate(List<Device> devices, int threshold, string date)
    {
        return devices.Aggregate(0, (ctr, device) =>
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(device.RecordedAt);
            DateTime recordedDate = dateTimeOffset.DateTime;
            string[] inputDateData = date.Split("-");
            if (device.OperatingParams.Threshold > threshold
                && recordedDate.Month == int.Parse(inputDateData[0])
                && recordedDate.Year == int.Parse(inputDateData[1]))
            {
                ctr++;
            }

            return ctr;
        });
    }

    public static async Task<int> CountDevices(int threshold, string statusQuery, string date)
    {
        HttpClient client = new();
        int page = 1;
        int count = 0;
        while (true)
        {
            string url =
                $"https://jsonmock.hackerrank.com/api/iot_devices/search?status={statusQuery}&page={page}";
            string data = await client.GetStringAsync(url);
            IOTDeviceData? response = JsonSerializer.Deserialize<IOTDeviceData>(data);
            if (response == null)
            {
                continue;
            }

            count += CountDevicesAboveThresholdForDate(response.Data, threshold, date);
            page++;
            if (page > response.TotalPages)
            {
                break;
            }
        }

        return count;
    }
}
