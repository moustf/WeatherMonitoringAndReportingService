namespace WeatherMonitoringAndReportingService.BL.Parsers;
using Weather;

public class ParserContext
{
    private IParser _strategyParser;

    public ParserContext(IParser strategyParser)
    {
        _strategyParser = strategyParser;
    }

    public void SetStrategyParser(IParser strategyParser)
    {
        _strategyParser = strategyParser;
    }

    public WeatherData Parse(string dataToParse)
    {
        Console.WriteLine("Parsing data from the context parser!");
        
        return _strategyParser.Parse(dataToParse);
    }
}