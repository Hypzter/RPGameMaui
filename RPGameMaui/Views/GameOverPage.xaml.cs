using RPGameMaui.Models;
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
        Data.MonsterListSingleton.GetMonsters().Clear();
        await Navigation.PushAsync(new MainPage());
    }

    private void OnQuitButtonClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}