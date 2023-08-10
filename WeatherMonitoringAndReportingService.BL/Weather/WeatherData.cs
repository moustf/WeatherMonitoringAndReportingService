namespace WeatherMonitoringAndReportingService.BL.Weather;

public class WeatherData
{
    public string Location { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }

    public WeatherData() {  }
    public WeatherData(string location, double temperature, double humidity)
    {
        Location = location;
        Temperature = temperature;
        Humidity = humidity;
    }
}