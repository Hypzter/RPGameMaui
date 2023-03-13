using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.Models
{
    internal class Monster
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int PhysicalAttack { get; set; }
        //public int MagicalAttack { get; set; }
        public int PhysicalDefense { get; set; }
        public int MagicalDefense { get; set; }
        public int CritChance { get; set; }
        public string Image { get; set; }
        //TODO: Bryt ut alla monster till egna objekt?
        public Monster()
        {
            Random rnd = new Random();
            Name = GetRandomMonsterName();
            Level = rnd.Next(1, 11);
            Health = 50 + (Level * 3);
            PhysicalAttack = 10 + (Level * 2);
            PhysicalDefense = 10 + (Level * 1);
            MagicalDefense = 10 + (Level * 1);
            //MagicalAttack = 10 + (Level * 2);
            CritChance = 2 + (Level * 1);
            Image = GetImage(Name);
        }
        internal string GetRandomMonsterName()
        {
            Random rnd = new Random();
            string[] names =
            {
                "Dragon",
                "Demon",
                "Medusa",
                "Jinn",
                "Baby Dragon",
                "Lizard"
            };
            return names[rnd.Next(0, names.Length)];
        }
        internal string GetImage(string name)
        {
            string image = null;
            if (name == "Dragon")
            {
                image = "dragon.png";
            }
            if (name == "Demon")
            {
                image = "demon.png";
            }
            if (name == "Medusa")
            {
                image = "medusa.png";
            }
            if (name == "Jinn")
            {
                image = "jinn.png";
            }
            if (name == "Lizard")
            {
                image = "lizard.png";
            }
            if (name == "Baby Dragon")
            {
                image = "babydragon.png";
            }
            return image;
        }
    }
}
