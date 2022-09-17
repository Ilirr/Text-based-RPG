using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class ItemHandler

    {
        public Item CreateItem(string itemName)
        {
            Item item = null;
            if (itemName == "Spear" || itemName == "Sword")
            {
                item = new Weapon(0);
                item.name = itemName;
            }
            else if(itemName == "Gloves" || itemName == "Plate" || itemName == "Helmet")
            {
                item = new Armor(1);
                item.name = itemName;

            }
            else
            {
                Console.WriteLine("ITEM HANDLER FAILED");
            }
            return item;
        }

    }
}
