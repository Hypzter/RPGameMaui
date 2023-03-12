using RPGameMaui.ViewModels;
using RPGameMaui.Views;

namespace RPGameMaui;

public partial class MainPage : ContentPage
{
    ViewModels.MainPageViewModel mpvm = new ViewModels.MainPageViewModel();
    public MainPage()
    {
        InitializeComponent();
        BindingContext = mpvm;
    }

    bool pageStarted = false;
    private async void OnKnightPicClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new KnightPage());
    }
    private async void OnWizardPicClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WizardPage());
    }

    private async void OnWeatherButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WeatherPage());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (!pageStarted)
        {
            // Hämtar din lokala platsuppgift med latitude och longitude, sparar dem i statiska variabler. Jag var tvungen att godkänna platsåtkomst i VS projektet.
            // Solution Explorer > Platforms > Windows > Package.appxmanifest sen Capabilities och kryssa för Location
            var task = (BindingContext as MainPageViewModel).GetCurrentLocation();
            pageStarted = true;
        }
    }
}

