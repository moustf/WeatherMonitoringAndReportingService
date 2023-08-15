namespace WeatherMonitoringAndReportingService.BL.WeatherBots;

public sealed class BotPublisherProvider
{
    private static readonly Lazy<IBotPublisher> Lazy = new(() =>
    {
        var botPublisherFactory = new BotPublisherFactory(new RainBot(), new SnowBot(), new SunBot());
        botPublisherFactory.AttachSubscribers();

        return botPublisherFactory.GetInstance();
    });

    public static IBotPublisher Instance => Lazy.Value;
    
    private BotPublisherProvider() {  }
}