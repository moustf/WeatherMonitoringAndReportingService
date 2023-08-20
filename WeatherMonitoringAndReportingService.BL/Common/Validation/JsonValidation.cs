using System.Text.Json;
using WeatherMonitoringAndReportingService.BL.Weather;

namespace WeatherMonitoringAndReportingService.BL.Common.Validation;

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
            var jsonWeatherData = JsonSerializer.Deserialize<WeatherData>(jsonData!);
            if (jsonWeatherData?.Location == null)
            {
                throw new NullReferenceException("An empty object has been added!");
            }
        }
        catch (Exception e)
        {
            if (e.GetType() == typeof(NullReferenceException))
            {
                _errors.Add(e.Message);
            }
            
            _errors.Add("The json data is not a valid weather object json data!");
            _errors.Add(e.Message);
        }

        return !_errors.Any();
    }

    public List<string> GetErrors() => _errors;
}