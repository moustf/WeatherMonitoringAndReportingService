namespace WeatherMonitoringAndReportingService.BL.WeatherBots;

public class RainBot : IBotSubscriber
{
    public RainBot(IBotPublisher botPublisher)
    {
        botPublisher.Attach(this);
    }
    
    public void Update(IBotPublisher publisherBot)
    {
        var rainBotConfigs = publisherBot.GetConfigData()["RainBot"];

        if (!rainBotConfigs.Enabled) return;
        
        Console.WriteLine("vbnetCpy code");
        Console.WriteLine("RainBot activated!");
        Console.WriteLine(rainBotConfigs.Message);
    }
}