using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.Models
{
    internal class ChosenHero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int PhysicalAttack { get; set; }
        public int MagicalAttack { get; set; }
        public int CritChance { get; set; }
        public string Image { get; set; }

        private static readonly ChosenHero _chosenHero = new ChosenHero();

        public static ChosenHero GetChosenHero()
        {
            return _chosenHero;
        }
        public static void LevelUp(ChosenHero c)
        {
            c.Level++;
            c.Health += (c.Level + 2);
            c.PhysicalAttack += (2);
            c.MagicalAttack += (2);
            c.CritChance += (c.Level * 1);
        }
    }
}
