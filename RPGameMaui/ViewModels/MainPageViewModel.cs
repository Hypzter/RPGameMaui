using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.ViewModels
{
    internal class MainPageViewModel
    {
        public static double longitude;
        public static double latitude;
        public MainPageViewModel()
        {
            //Task t = GetCurrentLocation();
            for (int i = 0; i < 10; i++)
            {
                Data.MonsterListSingleton.GetMonsters().Add(new Models.Monster());
            }
        }
        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;
        public async Task GetCurrentLocation()
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                _cancelTokenSource = new CancellationTokenSource();
                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                {
                    longitude = location.Longitude;
                    latitude = location.Latitude;
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "FeatureNotSupportedException", "OK");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "FeatureNotEnabledException", "OK");
            }
            catch (PermissionException pEx)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "PermissionException", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alers", "Unable to get locatin", "Ok");
            }
            finally
            {
                _isCheckingLocation = false;
            }

        }

        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }
    }
}
