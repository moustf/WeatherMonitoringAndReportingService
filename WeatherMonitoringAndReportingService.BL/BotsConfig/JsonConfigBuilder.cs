namespace WeatherMonitoringAndReportingService.BL.BotsConfig;

public class JsonConfigBuilder : IConfigBuilder
{
    private string _pathToFile;
    private JsonWeatherBotConfigIo _jsonWeatherBotConfigIo;

    public void GetConfigFilePath()
    {
        var generalBusinessLayerDirectory = Directory
            .GetCurrentDirectory()
            .Split(Path.DirectorySeparatorChar) // Split using the correct directory separator
            .TakeWhile(directory => !directory.Contains("WeatherMonitoringAndReportingService."));

        _pathToFile =
            $"{string.Join(Path.DirectorySeparatorChar, generalBusinessLayerDirectory)}{Path.DirectorySeparatorChar}WeatherMonitoringAndReportingService.BL{Path.DirectorySeparatorChar}ConfigFiles{Path.DirectorySeparatorChar}Bots.config.json";
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
