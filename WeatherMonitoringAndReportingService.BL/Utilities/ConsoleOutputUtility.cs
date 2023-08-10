using WeatherMonitoringAndReportingService.BL.Enums;

namespace WeatherMonitoringAndReportingService.BL.Utilities;

public static class ConsoleOutputUtility
{
    public static DataFormat? GetDataFormat()
    {
        Console.WriteLine("Hello there!");
        Console.WriteLine("Welcome to our weather monitoring and reporting service!");
        Console.WriteLine("What data format do you like to enter? 1 for JSON format, and 2 for XML format!");

        var dataFormatChoice = Console.ReadLine();

        while (dataFormatChoice != "1" && dataFormatChoice != "2")
        {
            Console.WriteLine("Your number should be eiter 1 or 2 only.");
            dataFormatChoice = Console.ReadLine();
        }
        
        var dataFormatChoiceInt = int.Parse(dataFormatChoice);

        return dataFormatChoiceInt switch
        {
            1 => DataFormat.Json,
            2 => DataFormat.Xml,
            _ => null,
        };
    }
}