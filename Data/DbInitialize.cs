namespace NaLibApi.Data;

public static class DbInitialize
{
    // public static aysnc Task Initialize(NaLibDbContext context)
    // {
    //     context.Database.EnsureCreated();

    //     if (!await context.Database.CanConnectAsync())
    //     {
    //         return;
    //     }

    //     if (context.WeatherForecasts.Any())
    //     {
    //         return;
    //     }

    //     var rng = new Random();
    //     var summaries = new[]
    //     {
    //         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //     };

    //     var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateTime.Now.AddDays(index),
    //         TemperatureC = rng.Next(-20, 55),
    //         Summary = summaries[rng.Next(summaries.Length)]
    //     }).ToArray();

    //     context.WeatherForecasts.AddRange(weatherForecasts);
    //     context.SaveChanges();
    // }
}