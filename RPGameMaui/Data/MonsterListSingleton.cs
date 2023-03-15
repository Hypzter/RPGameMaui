using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.Data
{
    // Instansierar en singleton lista med 10 monster vid start av programmet. Lägger över dem till en ObservableCollection så jag kan visa dem i GUI.
    // Hanterar endast listan och laddar in den på nytt i ObservableCollection efter varje fight man vinner över ett monster, då med monstret borttaget.
    // Smidigt sätt att hantera det på anser jag!
    internal class MonsterListSingleton
    {
        private static readonly List<Models.Monster> _monsterList = new List<Models.Monster>();

        public static List<Models.Monster> GetMonsters()
        {
            return _monsterList;
        }
    }
}
