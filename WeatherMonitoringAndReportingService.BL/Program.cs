using WeatherMonitoringAndReportingService.BL.Parsers;
using WeatherMonitoringAndReportingService.BL.Utilities;
using WeatherMonitoringAndReportingService.BL.Enums;

namespace WeatherMonitoringAndReportingService.BL
{
    internal abstract class Program
    {
        public static void Main(string[] args)
        {
            var dataFormatChoice = ConsoleOutputUtility.GetDataFormat();

            var jsonParser = new JsonWeatherDataParser();
            var parserContext = new ParserContext(jsonParser);
            
            switch (dataFormatChoice)
            {
                case DataFormat.Json:
                {
                    ManageJsonParsing(parserContext);
                    break;
                }
                case DataFormat.Xml:
                {
                    ManageXmlParsing(parserContext);
                    break;
                }
            }
        }

        private static void ManageJsonParsing(ParserContext parserContext)
        {
            var jsonData = ReadWeatherDataUtility.GetJsonWeatherData();

            var jsonValidation = new JsonValidation();
            var isJsonDataValid = jsonValidation.ValidateJson(jsonData);

            if (!isJsonDataValid)
            {
                var errors = jsonValidation.GetErrors();
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                    Console.WriteLine("The program is going to start from the beginning of the operation again!");
                    
                    ManageJsonParsing(parserContext);
                }
            }

            var weatherData = parserContext.Parse(jsonData!);
            
            Console.WriteLine(weatherData.Location);
            Console.WriteLine(weatherData.Temperature);
            Console.WriteLine(weatherData.Humidity);
        }

        private static void ManageXmlParsing(ParserContext parserContext)
        {
            var xmlParser = new XmlWeatherDataParser();
            parserContext.SetStrategyParser(xmlParser);
            
            var xmlData = ReadWeatherDataUtility.GetXmlWeatherData();

            var xmlValidation = new XmlValidation();
            var isXmlValid = xmlValidation.ValidateXml(xmlData);

            if (!isXmlValid)
            {
                var xmlErrors = xmlValidation.GetErrors();
                foreach (var error in xmlErrors)
                {
                    Console.WriteLine(error);
                    Console.WriteLine("The program is going to start from the beginning of the operation again!");
                    
                    ManageXmlParsing(parserContext);
                }
            }

            var weatherData = parserContext.Parse(xmlData!);
            
            Console.WriteLine(weatherData.Location);
            Console.WriteLine(weatherData.Temperature);
            Console.WriteLine(weatherData.Humidity);
        }
    }
}