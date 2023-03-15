using RPGameMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.Data
{
    internal class Logic
    {
        public static bool IsCrit { get; set; }
        public static int CheckIfCrit(int damage, int critChance)
        {
            IsCrit = false;
            Random rnd = new Random();
            var chance = rnd.Next(1, 100);
            if (chance <= critChance)
            {
                IsCrit = true;
                return damage * 2;
            }
            else
            {
                return damage;
            }
        }
    }
}
