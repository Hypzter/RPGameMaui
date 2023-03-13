using RPGameMaui.ViewModels;

namespace RPGameMaui.Views;

public partial class LevelUpPage : ContentPage
{
	public LevelUpPage()
	{
		InitializeComponent();
		BindingContext = new LevelUpPageViewModel();
	}

    private async void OnAddHealthButtonClicked(object sender, EventArgs e)
    {
		Models.ChosenHero.AddHealthPoints();
        IsAllMonstersDefeated();
    }

    private async void OnAddPhyAttButtonClicked(object sender, EventArgs e)
    {
		Models.ChosenHero.AddPhysicalAttackPoints();
        IsAllMonstersDefeated();
    }

    private async void OnAddMagAttButtonClicked(object sender, EventArgs e)
    {
        Models.ChosenHero.AddMagicalAttackPoints();
        IsAllMonstersDefeated();
    }

    private async void OnAddCritChanceButtonClicked(object sender, EventArgs e)
    {
        Models.ChosenHero.AddCritChancePoints();
        IsAllMonstersDefeated();
    }
    private async void IsAllMonstersDefeated()
    {
        var list = Data.MonsterListSingleton.GetMonsters();
        if (list.Count > 0)
        {
            await Navigation.PushAsync(new ShowEnemies());
        }
        else
        {
            await Navigation.PushAsync(new WinPage());
        }
        
    }
}