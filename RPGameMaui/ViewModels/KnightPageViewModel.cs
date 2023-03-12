using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.ViewModels
{
    internal class KnightPageViewModel
    {
        public Models.Knight Knight { get; set; }

        public Models.ChosenHero ChosenHero { get; set; }

        public KnightPageViewModel()
        {
            Knight = new Models.Knight();
            ChosenHero = Models.ChosenHero.GetChosenHero();
        }

    }
}
