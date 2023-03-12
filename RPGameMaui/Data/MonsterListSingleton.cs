using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGameMaui.Data
{
    internal class MonsterListSingleton
    {
        private static readonly List<Models.Monster> _monsterList = new List<Models.Monster>();

        public static List<Models.Monster> GetMonsters()
        {
            return _monsterList;
        }
    }
}
