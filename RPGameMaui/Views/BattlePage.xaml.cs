
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
        if (bpvm.MonsterHealth < 1)
        {
            await DisplayAlert("Winner!", "You leveled up", "Ok");
            BattlePageViewModel.YouWonTheFight(bpvm.Fight.Monster);
            await Navigation.PushAsync(new LevelUpPage());
        }
        if (bpvm.HeroHealth < 1)
        {
            await DisplayAlert("You lost!", "Better luck next time...", "Ok");
            await Navigation.PushAsync(new GameOverPage());
        }
    }
    private async void OnMagAttButtonClicked(object sender, EventArgs e)
    {
        if (bpvm.MonsterHealth < 1)
        {
            await DisplayAlert("Winner!", "You leveled up", "Ok");
            BattlePageViewModel.YouWonTheFight(bpvm.Fight.Monster);
            await Navigation.PushAsync(new LevelUpPage());
        }
        if (bpvm.HeroHealth < 1)
        {
            await DisplayAlert("You lost!", "Better luck next time...", "Ok");
            await Navigation.PushAsync(new GameOverPage());
            
        }
    }
}