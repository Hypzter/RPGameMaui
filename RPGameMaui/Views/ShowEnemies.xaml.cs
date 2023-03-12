using RPGameMaui.ViewModels;

namespace RPGameMaui.Views;

public partial class ShowEnemies : ContentPage
{
    ViewModels.ShowEnemiesViewModel sevm = new ViewModels.ShowEnemiesViewModel();

    public ShowEnemies()
    {
        InitializeComponent();
        BindingContext = sevm;
    }

    private async void OnListViewMonsterSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var monster = ((ListView)sender).SelectedItem as Models.Monster;
        GetCurrentMonster(monster);
        //var chosenHero = Models.ChosenHero.GetChosenHero();
        //sevm.Battle.Monster = monster;

        if (monster != null)
        {
            var page = new Views.BattlePage();
            //page.BindingContext = monster;
            await Navigation.PushAsync(page);
        }
    }
    internal void GetCurrentMonster(Models.Monster m)
    {
        ViewModels.ShowEnemiesViewModel.CurrentMonster = m;
    }

}