namespace WeatherMonitoringAndReportingService.BL.Utilities;

public static class ReadWeatherDataUtility
{
    public static string? GetJsonWeatherData()
    {
        Console.WriteLine("Please add the JSON data you want ot add!");

        var jsonData = Console.ReadLine();

        return jsonData;
    }
    public static string? GetXmlWeatherData()
    {
        Console.WriteLine("Please add the XML data you want ot add!");

        var xmlData = Console.ReadLine();

        return xmlData;
    }
}