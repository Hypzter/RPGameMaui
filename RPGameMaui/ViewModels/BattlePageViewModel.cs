using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.ViewModels
{
    internal partial class BattlePageViewModel : ObservableObject
    {
        [ObservableProperty]
        public Models.Battle fight;

        [ObservableProperty]
        int monsterHealth;

        [ObservableProperty]
        int heroHealth;

        public BattlePageViewModel()
        {
            Fight = new();
            Fight.ChosenHero = Models.ChosenHero.GetChosenHero();
            Fight.Monster = ViewModels.ShowEnemiesViewModel.CurrentMonster;
            MonsterHealth = Fight.Monster.Health;
            HeroHealth = Fight.ChosenHero.Health;
        }

        [RelayCommand]
        public async void PhysicalAttack()
        {
            await Task.Delay(500);
            MonsterHealth -= Data.Logic.CheckIfCrit(Fight.ChosenHero.PhysicalAttack, Fight.ChosenHero.CritChance);
            CounterAttack();

        }
        [RelayCommand]
        public async void MagicalAttack()
        {
            await Task.Delay(500);
            MonsterHealth -= Data.Logic.CheckIfCrit(Fight.ChosenHero.MagicalAttack, Fight.ChosenHero.CritChance);
            CounterAttack();
        }
        public void CounterAttack()
        {
            if (MonsterHealth >= 0)
            {
                Task.Delay(1000).Wait();
                HeroHealth -= Data.Logic.CheckIfCrit(Fight.Monster.PhysicalAttack, Fight.Monster.CritChance);
            }
        }
        public static void YouWonTheFight(Models.Monster m)
        {
            Data.MonsterListSingleton.GetMonsters().Remove(m);
        }

    }
}
