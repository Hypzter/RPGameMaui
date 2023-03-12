using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.Models
{
    internal class Wizard
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int PhysicalAttack { get; set; }
        public int MagicalAttack { get; set; }
        public int CritChance { get; set; }
        public string Image { get; set; }
        public Wizard()
        {
            Level = 1;
            Health = 80;
            PhysicalAttack = 2;
            MagicalAttack = 15;
            CritChance = 5;
            Image = "wizardidle.png";
        }
    }
}
