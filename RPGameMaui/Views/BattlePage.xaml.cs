
using RPGameMaui.ViewModels;

namespace RPGameMaui.Views;

public partial class BattlePage : ContentPage
{
	ViewModels.BattlePageViewModel bpvm = new ViewModels.BattlePageViewModel();
	public BattlePage()
	{
		InitializeComponent();
		BindingContext = bpvm;
	}

    private async void OnPhyAttButtonClicked(object sender, EventArgs e)
    {
		if (bpvm.MonsterHealth <= 0)
		{
			await DisplayAlert("Winner!", "You leveled up", "Ok");
			BattlePageViewModel.YouWonTheFight(bpvm.Fight.Monster);
			Models.ChosenHero.LevelUp(Models.ChosenHero.GetChosenHero());
			await Navigation.PushAsync(new ShowEnemies());
		}
		if (bpvm.HeroHealth <= 0)
		{
			await DisplayAlert("You lost!", "Better luck next time...", "Ok");
			await Navigation.PushAsync(new GameOverPage());
		}
    }
    private async void OnMagAttButtonClicked(object sender, EventArgs e)
    {
        if (bpvm.MonsterHealth <= 0)
        {
            await DisplayAlert("Winner!", "You leveled up", "Ok");
            BattlePageViewModel.YouWonTheFight(bpvm.Fight.Monster);
            Models.ChosenHero.LevelUp(Models.ChosenHero.GetChosenHero());
            await Navigation.PushAsync(new ShowEnemies());
        }
        if (bpvm.HeroHealth <= 0)
        {
            await DisplayAlert("You lost!", "Better luck next time...", "Ok");
            await Navigation.PushAsync(new GameOverPage());
        }
    }


}