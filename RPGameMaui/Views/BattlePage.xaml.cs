
using RPGameMaui.ViewModels;
using System.Runtime.CompilerServices;

namespace RPGameMaui.Views;

public partial class BattlePage : ContentPage
{
    ViewModels.BattlePageViewModel bpvm = new ViewModels.BattlePageViewModel();
    public BattlePage()
    {
        InitializeComponent();
        BindingContext = bpvm;
    }
    // Här har jag ett problem. Jag vill ju pusha till olika sidor beroende på vem som vinner mellan ChosenHero och Monster, alltså då någon av deras Health blir 0.
    // Blir lite knas då den beräkningen sker via en asynkron Command i viewmodel. Min CounterAttack metod har fördröjning i sig för att jag vill ha det turn-based,
    // så bvpm.HeroHealth hinner aldrig komma under noll förens efter den körs i metoden under här.
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