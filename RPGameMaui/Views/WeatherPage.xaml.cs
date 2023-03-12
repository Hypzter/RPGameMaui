using RPGameMaui.ViewModels;

namespace RPGameMaui.Views;

public partial class WeatherPage : ContentPage
{
	ViewModels.WeatherPageViewModel weatherPageViewModel = new ViewModels.WeatherPageViewModel();

	public WeatherPage()
	{
		InitializeComponent();
		BindingContext = weatherPageViewModel;
	}
}