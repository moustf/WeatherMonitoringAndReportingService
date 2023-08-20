using WeatherMonitoringAndReportingService.BL.BotsConfig;
using WeatherMonitoringAndReportingService.BL.Common.Utilities;
using WeatherMonitoringAndReportingService.BL.Common.Validation;
using WeatherMonitoringAndReportingService.BL.Parsers;
using WeatherMonitoringAndReportingService.BL.Enums;
using WeatherMonitoringAndReportingService.BL.Weather;
using WeatherMonitoringAndReportingService.BL.WeatherBots;

namespace WeatherMonitoringAndReportingService.BL
{
    internal abstract class Program
    {
        public static async Task Main(string[] args)
        {
            await ApplicationFlow();
        }

        private static async Task ApplicationFlow()
        {
            var selectedFormat = ConsoleOutputUtility.GetDataFormat();

            var jsonParser = new JsonWeatherDataParser();
            var parserContext = new ParserContext(jsonParser);
            var weatherPublisher = BotPublisherProvider.Instance;
            var jsonConfig = JsonConfigProvider.Instance;

            weatherPublisher.SetConfigData(await jsonConfig.ReadBotsConfigData());
            
            
            switch (selectedFormat)
            {
                case DataFormat.Exit:
                {
                    Console.WriteLine("thanks for choosing our service!");
                    Environment.Exit(0);
                    break;
                }
                case DataFormat.Json:
                {
                    var weatherData = ManageJsonParsing(parserContext);
                    await AnalyzeWeatherData(weatherPublisher, weatherData, jsonConfig);
                    break;
                }
                case DataFormat.Xml:
                {
                    var weatherData = ManageXmlParsing(parserContext);
                    await AnalyzeWeatherData(weatherPublisher, weatherData, jsonConfig);
                    break;
                }
                case DataFormat.ShowFormat:
                {
                    Console.WriteLine("JSON data format!");
                    Console.WriteLine("""
                        {
                          "Location": "City Name",
                          "Temperature": 23.0,
                          "Humidity": 85.0
                        }
                    """);
                    Console.WriteLine("XML data format!");
                    Console.WriteLine("""
                        <WeatherData>
                          <Location>City Name</Location>
                          <Temperature>23.0</Temperature>
                          <Humidity>85.0</Humidity>
                        </WeatherData>
                    """);
                    await ApplicationFlow();
                    break;
                }
            }
        }
        
        private static WeatherData ManageJsonParsing(ParserContext parserContext)
        {
            var jsonData = ReadWeatherDataUtility.GetJsonWeatherData();

            var jsonValidation = new JsonValidation();
            var isJsonDataValid = jsonValidation.ValidateJson(jsonData);

            if (isJsonDataValid) return parserContext.Parse(jsonData!);
            
            var errors = jsonValidation.GetErrors();
            foreach (var error in errors)
            {
                Console.WriteLine(error);
                Console.WriteLine("The program is going to start from the beginning of the operation again!");
                    
                ManageJsonParsing(parserContext);
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

            if (isXmlValid) return parserContext.Parse(xmlData!);
            
            var xmlErrors = xmlValidation.GetErrors();
            foreach (var error in xmlErrors)
            {
                Console.WriteLine(error);
                Console.WriteLine("The program is going to start from the beginning of the operation again!");
                    
                ManageXmlParsing(parserContext);
            }

            return parserContext.Parse(xmlData!);
        }

        private static async Task AnalyzeWeatherData(
            IBotPublisher weatherPublisher,
            WeatherData weatherData,
            IWeatherBotConfigIO jsonConfig
            )
        {
            var initialBotsConfigs = weatherPublisher.GetConfigData();
            var weatherConfigsAfterAnalysis = WeatherAnalysisUtility
                .AnalyzeWeatherData(weatherData, initialBotsConfigs);

            await jsonConfig.WriteBotsConfigData(weatherConfigsAfterAnalysis);
            
            weatherPublisher.Notify();
            weatherPublisher.SetConfigData(weatherConfigsAfterAnalysis);
        }
    }
}