namespace WeatherMonitoringAndReportingService.BL.WeatherBots;

public class BotPublisher : IBotPublisher
{
    private readonly List<IBotSubscriber> _botSubscribers;
    private Dictionary<string, WeatherBotConfig> _weatherBotConfigs;

    public BotPublisher()
    {
        _botSubscribers = new List<IBotSubscriber>();
        _weatherBotConfigs = new Dictionary<string, WeatherBotConfig>();
    }

    public void Attach(IBotSubscriber subscriberBot)
    {
        _botSubscribers.Add(subscriberBot);
    }

    public void Detatch(IBotSubscriber subscriberBot)
    {
        _botSubscribers.Remove(subscriberBot);
    }

    public void Notify()
    {
        foreach (var bot in _botSubscribers)
        {
            bot.Update(this);
        }
    }

    public Dictionary<string, WeatherBotConfig> GetConfigData()
    {
        return _weatherBotConfigs;
    }

    public void SetConfigData(Dictionary<string, WeatherBotConfig> configData)
    {
        _weatherBotConfigs = configData;
    }

    public List<IBotSubscriber> GetSubscribers()
    {
        return _botSubscribers;
    }
}