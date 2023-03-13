using CommunityToolkit.Mvvm.ComponentModel;
using RPGameMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.ViewModels
{
    internal partial class LevelUpPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public LevelUp levelUp;

        public LevelUpPageViewModel()
        {
            LevelUp = new();
            LevelUp.ChosenHero = Models.ChosenHero.GetChosenHero();
        }
    }
}
