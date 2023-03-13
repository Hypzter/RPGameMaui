using RPGameMaui.ViewModels;

namespace RPGameMaui.Views;

public partial class WeatherPage : ContentPage
{
	ViewModels.WeatherPageViewModel weatherPageViewModel = new ViewModels.WeatherPageViewModel();

	bool pageStarted = false;
	public WeatherPage()
	{
		InitializeComponent();
		BindingContext = weatherPageViewModel;
	}
 //   protected override void OnAppearing()
	//{
	//	base.OnAppearing();
	//	if (!pageStarted)
	//	{
	//		var task = (BindingContext as WeatherPageViewModel).GetWeatherAsync();
	//	}
	//}
}