namespace WeatherMonitoringAndReportingService.BL.WeatherBots;

public class BotPublisherFactory : IBotPublisherFactory
{
    private readonly IBotPublisher _publisher;
    private readonly IBotSubscriber[] _subscribers;

    public BotPublisherFactory(params IBotSubscriber[] subscribers)
    {
        _publisher = new BotPublisher();
        _subscribers = subscribers;
    }

    public void AttachSubscribers()
    {
        foreach (var subscriber in _subscribers)
        {
            _publisher.Attach(subscriber);
        }
    }

    public IBotPublisher GetInstance() => _publisher;
}