using AutoFixture;
using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService.BL.WeatherBots;

namespace WeatherMonitoringAndReportingService.Test.WeatherBots;

public class BotPublisherFactoryShould
{
    [Fact]
    public void CreateNewFactoryWithSubscribersAttached()
    {
        var botPublisherFactory = new Mock<BotPublisherFactory>();
        
        var publisher = botPublisherFactory.Object.GetInstance();

        publisher.Should().BeOfType<BotPublisher>();
    }
}