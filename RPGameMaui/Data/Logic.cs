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
        public static int CheckIfCrit(int damage, int critChance)
        {
            Random rnd = new Random();
            var chance = rnd.Next(1, 100);
            if (chance <= critChance)
            {
                return damage * 2;
            }
            else
            {
                return damage;
            }
        }
    }
}
