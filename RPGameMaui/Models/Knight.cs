﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.Models
{
    internal class Knight : Interface.ICharacter
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int PhysicalAttack { get; set; }
        public int MagicalAttack { get; set; }
        public int CritChance { get; set; }
        public string Image { get; set; }

        //private static readonly Knight _knight = new Knight();
        //TODO: Styra upp defense och skapa mer matte bakom fighterna?
        public Knight()
        {
            Level = 1;
            Health = 100;
            PhysicalAttack = 10;
            MagicalAttack = 2;
            CritChance = 3;
            Image = "knightidle.png";
        }
        //public static Knight ChosenKnight()
        //{
        //    return _knight;
        //}

    }
}
