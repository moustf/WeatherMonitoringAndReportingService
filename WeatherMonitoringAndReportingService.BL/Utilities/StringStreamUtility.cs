using System.Text;

namespace WeatherMonitoringAndReportingService.BL.Utilities;

public static class StringStreamUtility
{
    public static Stream GenerateStreamFromString(string xmlData)
    {
        return new MemoryStream(Encoding.UTF8.GetBytes(xmlData ?? ""));
    }
}