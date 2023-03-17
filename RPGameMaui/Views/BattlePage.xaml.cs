
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
    // H�r har jag ett problem. Jag vill ju pusha till olika sidor beroende p� vem som vinner mellan ChosenHero och Monster, allts� d� n�gon av deras Health blir 0.
    // Blir lite knas d� den ber�kningen sker via en asynkron Command i viewmodel. Min CounterAttack metod har f�rdr�jning i sig f�r att jag vill ha det turn-based,
    // s� bvpm.HeroHealth hinner aldrig komma under noll f�rens efter den k�rs i metoden under h�r.
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