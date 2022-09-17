using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class ItemGenerator
    {
        string[] items = new string[] { "Spear", "Sword", "Helmet", "Gloves", "Plate" };
        Item item;    
        public void GenerateItems(Room currentRoom)
        {

            for (int i = 0; i < items.Length; i++)
            {

                item = new Item();
                item.name = items[i];
               
                currentRoom.lootList.Add(item);
            }

        }
    }
}
