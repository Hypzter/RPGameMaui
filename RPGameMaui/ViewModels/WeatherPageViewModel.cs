using CommunityToolkit.Mvvm.ComponentModel;
using RPGameMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RPGameMaui.ViewModels
{
    internal partial class WeatherPageViewModel : ObservableObject
    {
        [ObservableProperty]
        int temp;

        [ObservableProperty]
        int feels_Like;

        [ObservableProperty]
        float wind_Speed;

        [ObservableProperty]
        int humidity;

        Weather WeatherRightNow { get; set; } = new Weather();

        public WeatherPageViewModel()
        {
            var weather = Task.Run(GetWeatherAsync);
            
            WeatherRightNow = weather.Result;

            Temp = WeatherRightNow.Temp;
            Feels_Like = WeatherRightNow.Feels_Like;
            Wind_Speed = WeatherRightNow.Wind_Speed;
            Humidity = WeatherRightNow.Humidity;

        }
        public static async Task<Weather> GetWeatherAsync()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.api-ninjas.com/");

            client.DefaultRequestHeaders.Add("X-Api-Key", "43HHhw9r1pV9cmDU6A4h3w==RXGER3FnoaQooZgL");

            Weather weather = null;

            using (HttpResponseMessage response = await client.GetAsync("v1/weather?lat=" + MainPageViewModel.latitude + "&lon=" + MainPageViewModel.longitude))
            {
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();
                        weather = JsonSerializer.Deserialize<Weather>(responseString);
                    }
                }
            }

            return weather;
        }
        //public async Task GetCurrentLocation()
        //{
        //    try
        //    {
        //        _isCheckingLocation = true;

        //        GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

        //        _cancelTokenSource = new CancellationTokenSource();

        //        LocationRightNow = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);



        //        //if (location != null)
        //        //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        //    }
        //    // Catch one of the following exceptions:
        //    //   FeatureNotSupportedException
        //    //   FeatureNotEnabledException
        //    //   PermissionException
        //    catch (Exception ex)
        //    {
        //        // Unable to get location
        //    }
        //    finally
        //    {
        //        _isCheckingLocation = false;
        //    }

        //}

        //public void CancelRequest()
        //{
        //    if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
        //        _cancelTokenSource.Cancel();
        //}
    }
}
