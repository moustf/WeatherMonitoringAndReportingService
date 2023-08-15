using WeatherMonitoringAndReportingService.BL.Enums;

namespace WeatherMonitoringAndReportingService.BL.Common.Utilities;

public static class ConsoleOutputUtility
{
    public static DataFormat? GetDataFormat()
    {
        Console.WriteLine("Hello there!");
        Console.WriteLine("Welcome to our weather monitoring and reporting service!");
        Console.WriteLine("What data format do you like to enter? 1 for JSON format, and 2 for XML format!");
        Console.WriteLine("Type 3 to show you a quick example of the data you need to add!");
        Console.WriteLine("Type 0 to exit the program!");

        var selectedDataFormat = Console.ReadLine();
        var inputOptions = new string[] { "0", "1", "2", "3" };

        while (!inputOptions.Contains(selectedDataFormat))
        {
            Console.WriteLine("Your number should be eiter 1 or 2 only.");
            selectedDataFormat = Console.ReadLine();
        }
        
        var dataFormatChoiceInt = int.Parse(selectedDataFormat);

        return dataFormatChoiceInt switch
        {
            0 => DataFormat.Exit,
            1 => DataFormat.Json,
            2 => DataFormat.Xml,
            3 => DataFormat.ShowFormat,
            _ => null,
        };
    }
}