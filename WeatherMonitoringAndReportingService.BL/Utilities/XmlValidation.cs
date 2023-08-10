using System.Xml.Linq;

namespace WeatherMonitoringAndReportingService.BL.Utilities;

public class XmlValidation
{
    private readonly List<string> _errors;

    public XmlValidation()
    {
        _errors = new List<string>();
    }
    
    public bool ValidateXml(string? xmlData)
    {
        if (string.IsNullOrWhiteSpace(xmlData))
        {
            _errors.Add("The string entered is null or contains only white spaces!");
        }

        try
        {
            var xDocument = XDocument.Parse(xmlData!);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            
            _errors.Add("Invalid xml data!");
            _errors.Add(e.Message);
        }

        return !_errors.Any();
    }

    public List<string> GetErrors() => _errors;
}