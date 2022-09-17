using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class Item
    {
        public string name;
        public int type;
        public string[] statArray = new string[] { "attack", "carry", "magic", "health", "stamina", "armor", "attackSpeed" };
        public Dictionary<string, int> itemstats = new Dictionary<string, int>();

        public Item()
        {
            Random rand = new Random();
            int min = 5;
            int max = 15;

            for (int i = 0; i < statArray.Length; i++)
            {
                itemstats.Add(statArray[i], rand.Next(min,max));
            }
        }

        /*private int attack;
        private int magic;
        private int stamina;
        private int health;
        private int armor;
        private int carry;
        private int attackSpeed;
        public int AttackSpeed => attackSpeed;
        public int Carry => carry;
        public int Attack => attack;
        public int Magic => magic;
        public int Health => health;
        public int Stamina => stamina;
        public int Armor => armor;
        */

        /*  public void CreateValues(Item item)
          {
              int min = 5;
              int max = 15;
              Random rand = new Random();
              int[] values = new int[] { attack, carry, magic, health, stamina, armor, health, attackSpeed };
              for (int i = 0; i < values.Length; i++)
              {
                  values[i] = rand.Next(min, max);

              }
                item.attack = values[0];
                item.carry = values[1];
                item.magic = values[2];
                item.health = values[3];
                item.stamina = values[4];
                item.armor = values[5];
                item.attack = values[6];
                item.attack = values[7];
          }

          */
    }


}


