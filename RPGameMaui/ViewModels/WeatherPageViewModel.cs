using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
            try
            {
                var weather = Task.Run(GetWeatherAsync);
                weather.Wait();
                WeatherRightNow = weather.Result;

                if (weather.Result != null)
                {
                    Temp = WeatherRightNow.Temp;
                    Feels_Like = WeatherRightNow.Feels_Like;
                    Wind_Speed = WeatherRightNow.Wind_Speed;
                    Humidity = WeatherRightNow.Humidity;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Application.Current.MainPage.DisplayAlert("Alert", "FeatureNotSupportedException", "OK");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                Application.Current.MainPage.DisplayAlert("Alert", "FeatureNotEnabledException", "OK");
            }
            catch (PermissionException pEx)
            {
                Application.Current.MainPage.DisplayAlert("Alert", "PermissionException", "OK");
            }
            catch (NullReferenceException nEx)
            {
                Application.Current.MainPage.DisplayAlert("Alert", "NullReferenceException", "Ok");
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Alert", "Unable to get location", "Ok");
            }

        }
        public async Task<Weather> GetWeatherAsync()
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
    }
}
