namespace WeatherMonitoringAndReportingService.BL.WeatherBots;

public class SnowBot : IBotSubscriber
{
    public SnowBot(IBotPublisher botPublisher)
    {
        botPublisher.Attach(this);
    }
    
    public void Update(IBotPublisher publisherBot)
    {
        var snowBotConfigs = publisherBot.GetConfigData()["SnowBot"];

        if (!snowBotConfigs.Enabled) return;
        
        Console.WriteLine("vbnetCpy code");
        Console.WriteLine("SnowBot activated!");
        Console.WriteLine(snowBotConfigs.Message);
    }
}