using WeatherMonitoringAndReportingService.BL.Parsers;
using WeatherMonitoringAndReportingService.BL.Utilities;
using WeatherMonitoringAndReportingService.BL.Enums;
using WeatherMonitoringAndReportingService.BL.Weather;
using WeatherMonitoringAndReportingService.BL.WeatherBots;

namespace WeatherMonitoringAndReportingService.BL
{
    internal abstract class Program
    {
        public async static Task Main(string[] args)
        {
            var dataFormatChoice = ConsoleOutputUtility.GetDataFormat();
            
            var jsonParser = new JsonWeatherDataParser();
            var parserContext = new ParserContext(jsonParser);

            var weatherPublisher = new WeatherBotPublisher();
            weatherPublisher.SetConfigData(await ConfigDataUtility.ReadBotsConfigData());
            var rainBot = new RainBot(weatherPublisher);
            var snowBot = new SnowBot(weatherPublisher);
            var sunBot = new SunBot(weatherPublisher);
            
            switch (dataFormatChoice)
            {
                case DataFormat.Json:
                {
                    var weatherData = ManageJsonParsing(parserContext);
                    AnalyzeWeatherData(weatherPublisher, weatherData);
                    break;
                }
                case DataFormat.Xml:
                {
                    var weatherData = ManageXmlParsing(parserContext);
                    AnalyzeWeatherData(weatherPublisher, weatherData);
                    break;
                }
            }
        }

        private static WeatherData ManageJsonParsing(ParserContext parserContext)
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

            return parserContext.Parse(jsonData!);

            
        }

        private static WeatherData ManageXmlParsing(ParserContext parserContext)
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

            return parserContext.Parse(xmlData!);
        }

        private static void AnalyzeWeatherData(IBotPublisher weatherPublisher, WeatherData weatherData)
        {
            var initialBotsConfigs = weatherPublisher.GetConfigData();
            var weatherConfigsAfterAnalysis = WeatherAnalysisUtility.AnalyzeWeatherData(weatherData, initialBotsConfigs);
            
            weatherPublisher.Notify();
            weatherPublisher.SetConfigData(weatherConfigsAfterAnalysis);
        }
    }
}