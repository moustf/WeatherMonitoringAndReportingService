using System.Text.Json;
using WeatherMonitoringAndReportingService.BL.Weather;

namespace WeatherMonitoringAndReportingService.BL.Validation;

public class JsonValidation
{
    private readonly List<string> _errors;

    public JsonValidation()
    {
        _errors = new List<string>();
    }
    
    public bool ValidateJson(string? jsonData)
    {
        if (string.IsNullOrWhiteSpace(jsonData))
        {
            _errors.Add("Json formatted data can't be null!");
        }

        try
        {
            JsonSerializer.Deserialize<WeatherData>(jsonData!);
        }
        catch (Exception e)
        {
            _errors.Add("The json data is not a valid weather object json data!");
        }

        return !_errors.Any();
    }

    public List<string> GetErrors() => _errors;
}