using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class Enemy
    {
        public Inventory enemyLoot = new Inventory();
        public bool fought;
        public void CreateLoot()
        {
            string[] items = new string[] { "A", "B", "C", "D", "E" };
            for (int i = 0; i < items.Length; i++)
            {

                Item item = new Item();
                item.name = items[i];
                enemyLoot.item.Add(item);

            }
        }
        public int Hp { get; set; }
        public string Name { get; set; }

        public Enemy(string enemyName, int enemyHp)
        {
            this.Name = enemyName;
            this.Hp = enemyHp;
        }
        public string Details()
        {
            return String.Format("Enemy {0} has appeared! HP: ({1})", this.Name, this.Hp); // 0 = Name, 1 = Hp
        }
    }
}
