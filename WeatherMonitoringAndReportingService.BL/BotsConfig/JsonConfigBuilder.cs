namespace WeatherMonitoringAndReportingService.BL.BotsConfig;

public class JsonConfigBuilder : IConfigBuilder
{
    private string _pathToFile;
    private JsonWeatherBotConfigIo _jsonWeatherBotConfigIo;

    public void GetConfigFilePath()
    {
        var generalBusinessLayerDirectory = Directory
            .GetCurrentDirectory()
            .Split('/')
            .TakeWhile(directory => !directory.Contains("WeatherMonitoringAndReportingService."));

        _pathToFile =  $"{string.Join('/', generalBusinessLayerDirectory)}/WeatherMonitoringAndReportingService.BL/ConfigFiles/Bots.config.json";
        
        Console.WriteLine("**************** Path to config file **********************");
        Console.WriteLine(_pathToFile);
    }

    public void CreateInstance()
    {
        _jsonWeatherBotConfigIo = new JsonWeatherBotConfigIo(_pathToFile);
    }

    public IWeatherBotConfigIO GetInstance()
    {
        return _jsonWeatherBotConfigIo;
    }
}
