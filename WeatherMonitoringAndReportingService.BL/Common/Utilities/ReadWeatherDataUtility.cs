namespace WeatherMonitoringAndReportingService.BL.Common.Utilities;

public static class ReadWeatherDataUtility
{
    public static string? GetJsonWeatherData()
    {
        Console.WriteLine("Please add the JSON data you want ot add!");

        return Console.ReadLine();
    }
    public static string? GetXmlWeatherData()
    {
        Console.WriteLine("Please add the XML data you want ot add!");
        
        return Console.ReadLine();;
    }
}