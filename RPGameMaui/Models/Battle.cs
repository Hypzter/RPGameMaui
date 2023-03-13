using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.Models
{
    internal class Battle
    {
        public Models.Monster Monster { get; set; }
        public Models.ChosenHero ChosenHero { get; set; }
    }
}
