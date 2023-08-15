namespace WeatherMonitoringAndReportingService.BL.WeatherBots;

public class SunBot : IBotSubscriber
{
    public void Update(IBotPublisher publisherBot)
    {
        var suBotConfigs = publisherBot.GetConfigData()["SunBot"];

        if (!suBotConfigs.Enabled) return;
        
        Console.WriteLine("vbnetCpy code");
        Console.WriteLine("SunBot activated!");
        Console.WriteLine(suBotConfigs.Message);
    }
}