using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.ViewModels
{
    internal class WizardPageViewModel
    {
        public Models.Wizard Wizard { get; set; }

        public Models.ChosenHero ChosenHero { get; set; }

        public WizardPageViewModel()
        {
            Wizard = new Models.Wizard();
            ChosenHero = Models.ChosenHero.GetChosenHero();
        }
    }
}
