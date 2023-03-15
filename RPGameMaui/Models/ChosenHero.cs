using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.Models
{
    // Användaren får välja mellan Knight eller Wizard, och den klassen sätts som ChosenHero-singleton som hanteras genom hela programmet. 
    internal class ChosenHero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int PhysicalAttack { get; set; }
        public int MagicalAttack { get; set; }
        public int CritChance { get; set; }
        public bool IsCrit { get; set; } = false;
        public string Image { get; set; }

        private static readonly ChosenHero _chosenHero = new ChosenHero();

        public static ChosenHero GetChosenHero()
        {
            return _chosenHero;
        }
        public static void AddHealthPoints()
        {
            _chosenHero.Level++;
            _chosenHero.Health += 8;
        }
        public static void AddPhysicalAttackPoints()
        {
            _chosenHero.Level++;
            _chosenHero.PhysicalAttack += 3;
        }
        public static void AddMagicalAttackPoints()
        {
            _chosenHero.Level++;
            _chosenHero.MagicalAttack += 4;
        }
        public static void AddCritChancePoints()
        {
            _chosenHero.Level++;
            _chosenHero.CritChance += 2;
        }
    }
}
