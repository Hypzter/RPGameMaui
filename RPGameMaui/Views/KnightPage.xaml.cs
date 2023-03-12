namespace RPGameMaui.Views;

public partial class KnightPage : ContentPage
{
    ViewModels.KnightPageViewModel kpvm = new ViewModels.KnightPageViewModel();
    public KnightPage()
    {
        InitializeComponent();
        BindingContext = kpvm;
    }

    private async void OnToBattleClicked(object sender, EventArgs e)
    {
        if (NameInput.Text == null)
        {
            await DisplayAlert("Alert!", "You must enter a name", "Ok");
        }
        else
        {
            bool answer = await DisplayAlert("Confirm", "Are you happy with your name?", "Yes", "Cancel");
            if (answer == true)
            {
                kpvm.ChosenHero.Name = NameInput.Text;
                kpvm.ChosenHero.Health = kpvm.Knight.Health;
                kpvm.ChosenHero.Level = kpvm.Knight.Level;
                kpvm.ChosenHero.PhysicalAttack = kpvm.Knight.PhysicalAttack;
                kpvm.ChosenHero.MagicalAttack = kpvm.Knight.MagicalAttack;
                kpvm.ChosenHero.CritChance = kpvm.Knight.CritChance;
                kpvm.ChosenHero.Image = kpvm.Knight.Image;

                await Navigation.PushAsync(new ShowEnemies());
            }
            else
            {
                return;
            }
        }
    }
}