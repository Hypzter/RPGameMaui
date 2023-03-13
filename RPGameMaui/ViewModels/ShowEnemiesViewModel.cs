using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RPGameMaui.Models;

namespace RPGameMaui.ViewModels
{
    internal partial class ShowEnemiesViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Models.Monster> monsters;

        [ObservableProperty]
        Models.ChosenHero hero;

        internal static Models.Monster CurrentMonster { get; set; }

        public Models.Battle Battle;
        public ShowEnemiesViewModel()
        {
            Monsters = new ObservableCollection<Models.Monster>();

            foreach (var m in Data.MonsterListSingleton.GetMonsters())
            {
                Monsters.Add(m);
            }
        }
    }
}
