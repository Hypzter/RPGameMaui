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
        //public void GetMonsters()
        //{
        //    if (Monsters == null)
        //    {
        //        Monsters = new ObservableCollection<Models.Monster>();
        //        for (int i = 0; i < 10; i++)
        //        {
        //            Monsters.Add(new Models.Monster());
        //        }
        //    }
        //}
        //public static void YouWonTheFight(Models.Monster m)
        //{
        //    var monster = (Monster)m;
        //    Monsters.Remove(monster);
        //}

    }
}
