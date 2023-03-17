using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Xaml;
using RPGameMaui.Models;
using RPGameMaui.Views;
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
        int monsterAtt;

        [ObservableProperty]
        int monsterCritChance;

        [ObservableProperty]
        int heroHealth;

        [ObservableProperty]
        int heroPhysAtt;

        [ObservableProperty]
        int heroMagAtt;

        [ObservableProperty]
        int heroCritChance;

        [ObservableProperty]
        string monsterActionText;

        [ObservableProperty]
        string monsterActionTextForCrit;

        [ObservableProperty]
        string heroActionTextForCrit;

        [ObservableProperty]
        string heroActionText;

        [ObservableProperty]
        int heroDamage;

        [ObservableProperty]
        int monsterDamage;

        public static bool checkIfHealthReachedZero = false;
        public BattlePageViewModel()
        {
            Fight = new();
            Fight.ChosenHero = Models.ChosenHero.GetChosenHero();
            Fight.Monster = ViewModels.ShowEnemiesViewModel.CurrentMonster;
            MonsterHealth = Fight.Monster.Health;
            MonsterAtt = Fight.Monster.Attack;
            monsterCritChance = Fight.Monster.CritChance;
            HeroHealth = Fight.ChosenHero.Health;
            HeroPhysAtt = Fight.ChosenHero.PhysicalAttack;
            HeroMagAtt = Fight.ChosenHero.MagicalAttack;
            HeroCritChance = Fight.ChosenHero.CritChance;
        }

        [RelayCommand]
        public async void PhysicalAttack()
        {
            HeroDamage = Data.Logic.CheckIfCrit(Fight.ChosenHero.PhysicalAttack, Fight.ChosenHero.CritChance);
            MonsterHealth -= HeroDamage;
            if (Data.Logic.IsCrit == false)
            {
                HeroActionText = Fight.ChosenHero.Name + " hits " + Fight.Monster.Name + " for " + HeroDamage + " physical damage!";
                await Task.Delay(1000);
                HeroActionText = "";
            }
            else
            {
                HeroActionTextForCrit = Fight.ChosenHero.Name + " crits " + Fight.Monster.Name + " for " + HeroDamage + " physical damage!";
                await Task.Delay(1000);
                HeroActionTextForCrit = "";
            }
            CounterAttack();

        }
        [RelayCommand]
        public async void MagicalAttack()
        {
            HeroDamage = Data.Logic.CheckIfCrit(Fight.ChosenHero.MagicalAttack, Fight.ChosenHero.CritChance);
            MonsterHealth -= HeroDamage;
            if (Data.Logic.IsCrit == false)
            {
                HeroActionText = Fight.ChosenHero.Name + " hits " + Fight.Monster.Name + " for " + HeroDamage + " magical damage!";
                await Task.Delay(1000);
                HeroActionText = "";
            }
            else
            {
                HeroActionTextForCrit = Fight.ChosenHero.Name + " crits " + Fight.Monster.Name + " for " + HeroDamage + " magical damage!";
                await Task.Delay(1000);
                HeroActionTextForCrit = "";
            }           
            CounterAttack();
        }
        public async void CounterAttack()
        {
            if (MonsterHealth > 0)
            {
                MonsterDamage = Data.Logic.CheckIfCrit(Fight.Monster.Attack, Fight.Monster.CritChance);
                HeroHealth -= MonsterDamage;
                if (Data.Logic.IsCrit == false)
                {
                    MonsterActionText = Fight.Monster.Name + " hits " + Fight.ChosenHero.Name + " for " + MonsterDamage + " damage!";
                    await Task.Delay(1000);
                    MonsterActionText = "";
                }
                else
                {
                    MonsterActionTextForCrit = Fight.Monster.Name + " crits " + Fight.ChosenHero.Name + " for " + MonsterDamage + " damage!";
                    await Task.Delay(1000);
                    MonsterActionTextForCrit = "";
                }
            }
        }
        public static void YouWonTheFight(Models.Monster m)
        {
            Data.MonsterListSingleton.GetMonsters().Remove(m);
        }
    }
}
