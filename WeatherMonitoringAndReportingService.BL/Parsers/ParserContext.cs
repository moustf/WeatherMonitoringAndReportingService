namespace WeatherMonitoringAndReportingService.BL.Parsers;
using Weather;

public class ParserContext
{
    private IParser _parser;

    public ParserContext(IParser parser)
    {
        _parser = parser;
    }

    public void SetStrategyParser(IParser strategyParser)
    {
        _parser = strategyParser;
    }

    public WeatherData Parse(string dataToParse)
    {
        Console.WriteLine("Parsing data from the context parser!");
        
        return _parser.Parse(dataToParse);
    }
}