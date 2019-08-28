using Engine.Models;
using Engine.Models.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> _standardGameItems;

        static ItemFactory()
        {
            _standardGameItems = new List<GameItem>();

            _standardGameItems.Add(new Weapon(1001, "Spoon", 1, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "Pitchfork", 5, 1, 3));
            _standardGameItems.Add(new Weapon(1003, "Branch", 2, 1, 4));
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            return standardItem?.Clone();
        }
    }
}
