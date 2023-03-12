namespace RPGameMaui.Views;

public partial class WizardPage : ContentPage
{
	ViewModels.WizardPageViewModel wpvm = new ViewModels.WizardPageViewModel();
	public WizardPage()
	{
		InitializeComponent();
		BindingContext = wpvm;
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
                wpvm.ChosenHero.Name = NameInput.Text;
                wpvm.ChosenHero.Health = wpvm.Wizard.Health;
                wpvm.ChosenHero.Level = wpvm.Wizard.Level;
                wpvm.ChosenHero.PhysicalAttack = wpvm.Wizard.PhysicalAttack;
                wpvm.ChosenHero.MagicalAttack = wpvm.Wizard.MagicalAttack;
                wpvm.ChosenHero.CritChance = wpvm.Wizard.CritChance;
                wpvm.ChosenHero.Image = wpvm.Wizard.Image;

                await Navigation.PushAsync(new ShowEnemies());
            }
            else
            {
                return;
            }
        }
    }
}