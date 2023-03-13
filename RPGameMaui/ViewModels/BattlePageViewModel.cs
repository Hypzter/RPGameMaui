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
        int monsterPhysAtt;

        [ObservableProperty]
        int monsterCritChance;

        [ObservableProperty]
        int heroHealth;

        [ObservableProperty]
        int heroPhysAtt;

        [ObservableProperty]
        int heroMagAtt;

        public BattlePageViewModel()
        {
            Fight = new();
            Fight.ChosenHero = Models.ChosenHero.GetChosenHero();
            Fight.Monster = ViewModels.ShowEnemiesViewModel.CurrentMonster;
            MonsterHealth = Fight.Monster.Health;
            MonsterPhysAtt = Fight.Monster.PhysicalAttack;
            monsterCritChance = Fight.Monster.CritChance;
            HeroHealth = Fight.ChosenHero.Health;
            HeroPhysAtt = Fight.ChosenHero.PhysicalAttack;
            HeroMagAtt = Fight.ChosenHero.MagicalAttack;

        }

        //[RelayCommand]
        //public async void FightHero()
        //{
        //    await Task.Delay(500);
        //    if (Fight.ChosenHero.Image == "knightidle.png")
        //    {
        //        //Fight.ChosenHero = Models.Wizard.ChosenWizard();
        //        Fight.ChosenHero.Level = Models.Wizard.ChosenWizard().Level;
        //        Fight.ChosenHero.Health = Models.Wizard.ChosenWizard().Health;
        //        Fight.ChosenHero.PhysicalAttack = Models.Wizard.ChosenWizard().PhysicalAttack;
        //        Fight.ChosenHero.MagicalAttack = Models.Wizard.ChosenWizard().MagicalAttack;
        //        Fight.ChosenHero.CritChance = Models.Wizard.ChosenWizard().CritChance;
        //        Fight.ChosenHero.Image = Models.Wizard.ChosenWizard().Image;
        //    }
        //    if (Fight.ChosenHero.Image == "wizardidle.png")
        //    {
        //        //Fight.ChosenHero = Models.Knight.ChosenKnight();
        //        Fight.ChosenHero.Level = Models.Knight.ChosenKnight().Level;
        //        Fight.ChosenHero.Health = Models.Knight.ChosenKnight().Health;
        //        Fight.ChosenHero.PhysicalAttack = Models.Knight.ChosenKnight().PhysicalAttack;
        //        Fight.ChosenHero.MagicalAttack = Models.Knight.ChosenKnight().MagicalAttack;
        //        Fight.ChosenHero.CritChance = Models.Knight.ChosenKnight().CritChance;
        //        Fight.ChosenHero.Image = Models.Knight.ChosenKnight().Image;
        //    }
        //}

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
        public async void CounterAttack()
        {
            if (MonsterHealth >= 0)
            {
                await Task.Delay(1000);
                HeroHealth -= Data.Logic.CheckIfCrit(Fight.Monster.PhysicalAttack, Fight.Monster.CritChance);
            }
        }
        public static void YouWonTheFight(Models.Monster m)
        {
            Data.MonsterListSingleton.GetMonsters().Remove(m);
        }
    }
}
