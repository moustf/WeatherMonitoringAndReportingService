namespace WeatherMonitoringAndReportingService.BL.WeatherBots;

public interface IBotSubscriber
{
    void Update(IBotPublisher publisher);
}