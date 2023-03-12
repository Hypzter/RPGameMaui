using System.Security.Cryptography.X509Certificates;

namespace RPGameMaui.Views;

public partial class GameOverPage : ContentPage
{
	public GameOverPage()
	{
		InitializeComponent();
	}
    private async void OnPlayAgainButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
        //Navigation.NavigationStack.Count;
    }

    private void OnQuitButtonClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}