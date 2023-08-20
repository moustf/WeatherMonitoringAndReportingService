using AutoFixture;
using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService.BL.WeatherBots;

namespace WeatherMonitoringAndReportingService.Test.WeatherBots;

public class BotPublisherShould
{
    [Fact]
    public void AttachNewSubscriber()
    {
        var subscriber = new Mock<IBotSubscriber>();
        var publisher = new Mock<BotPublisher>();

        publisher.Object.Attach(subscriber.Object);
        var subscribers = publisher.Object.GetSubscribers();

        subscribers.Should().HaveCount(1);
        publisher.VerifyNoOtherCalls();
    }
    
    [Fact]
    public void DetachExistingSubscriber()
    {
        var subscriber = new Mock<IBotSubscriber>();
        var publisher = new Mock<BotPublisher>();

        publisher.Object.Attach(subscriber.Object);
        var subscribersAfterAttaching = publisher.Object.GetSubscribers();
        
        subscribersAfterAttaching.Should().HaveCount(1);
        
        publisher.Object.Detach(subscriber.Object);
        var subscribersAfterDetaching = publisher.Object.GetSubscribers();

        subscribersAfterDetaching.Should().HaveCount(0);
        publisher.VerifyNoOtherCalls();
    }
    
    [Fact]
    public void NotifyExistingSubscriber()
    {
        var subscriberOne = new Mock<IBotSubscriber>();
        var subscriberTwo = new Mock<IBotSubscriber>();
        var publisher = new Mock<BotPublisher>();

        publisher.Object.Attach(subscriberOne.Object);
        publisher.Object.Attach(subscriberTwo.Object);
        publisher.Object.Notify();
        
        subscriberOne.Verify(subscriber => subscriber.Update(publisher.Object), Times.Once);
        subscriberOne.Verify(subscriber => subscriber.Update(publisher.Object), Times.Once);
        
        publisher.Object.GetSubscribers().Should().HaveCount(2);
        publisher.VerifyNoOtherCalls();
    }
    
    [Fact]
    public void GetConfigDictionaryWhenCorrespondingMethodCalled()
    {
        var publisher = new Mock<BotPublisher>();

        var config = publisher.Object.GetConfigData();

        config.Should().BeOfType<Dictionary<string, WeatherBotConfig>>();
        publisher.VerifyNoOtherCalls();
    }
    
    [Fact]
    public void SetConfigDictionaryWhenCorrespondingMethodCalled()
    {
        var fixture = new Fixture();
        var publisher = new Mock<BotPublisher>();
        var configDictionary = fixture.Create<Dictionary<string, WeatherBotConfig>>();
        
        publisher.Object.SetConfigData(configDictionary);

        configDictionary.Should().BeOfType<Dictionary<string, WeatherBotConfig>>();
        configDictionary.Should().HaveCount(configDictionary.Count);
        publisher.VerifyNoOtherCalls();
    }
}