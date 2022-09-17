using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ConsoleApp4
{
    public class Player
    {
        
        int strength;
        int dexterity;
        int intelligence;
        int charisma;
        int fitness;
        int health;
        int damage;
        private string name;
       
       public Inventory inventory = new Inventory();
       
        public Player(string playerName, int styrka, int smidighet, int intelligens, int kondition, int karisma, int health) 
        {
            this.name = playerName;
            this.strength = styrka;
            this.dexterity = smidighet;
            this.intelligence = intelligens;
            this.fitness = kondition;
            this.charisma = karisma;
            this.health = health;
            
            inventory.weaponSlot = new Item[2];
            inventory.armorSlot = new Item[3];
        }
        public int Damage
        {
            get => damage;
            set { damage = value; }
        }
        public string Name
        {
            get => name;
            set { name = value; }
        }
        public int Health
        {
            get => health;
            set { health = value; }
        }
        public int Strength
        {
            get => strength;
            set { strength = value; }
        }
        public int Dexterity
        {
            get => dexterity;
            set { dexterity = value; }
        }
        public int Intelligence
        {
            get => intelligence;
            set { intelligence = value; }
        }
        public int Charisma
        {
            get => charisma;
            set { charisma = value; }
        }
        public int Fitness
        {
            get => fitness;
            set { fitness = value; }
        }
        public bool ArmorHandler(int slot)
        {

            if (inventory.armorSlot[slot] != null)
            {
                Console.WriteLine("SLOT IS OCCUPIED");
                return false;
            }
            else
                return true;
           

        }
        public bool WeaponHandler(int slot)
        {
            if (inventory.weaponSlot[slot] != null)
            {
                Console.WriteLine("SLOT IS OCCUPIED");
                return false;
            }
            else
                return true;
            
        }
        public void EquipWeapon(Weapon weapon_temp, int hand)
        {
            inventory.weaponSlot[hand] = weapon_temp;
        }
        public void EquipArmor(Armor armor_temp, int slot)
        {
            inventory.armorSlot[slot] = armor_temp;

        }
       
        public int GetAttack()
        {
            int itemBonus = 0;
            for (int i = 0; i < inventory.equippedItems.Count; i++)
            {
                if (inventory.equippedItems[i] != null)
                {
                    itemBonus += inventory.equippedItems[i].itemstats["attack"];

                }
            }
            return strength * dexterity + itemBonus;
        }
        public int GetMagic()
        {
            int itemBonus = 0;
            for (int i = 0; i < inventory.equippedItems.Count; i++)
            {
                if (inventory.equippedItems[i] != null)
                {
                    itemBonus += inventory.equippedItems[i].itemstats["magic"];

                }
            }
            return intelligence * dexterity + itemBonus;
        }
        public int GetHealth()
        {
            int itemBonus = 0;
            for (int i = 0; i < inventory.equippedItems.Count; i++)
            {
                if (inventory.equippedItems[i] != null)
                {
                    itemBonus += inventory.equippedItems[i].itemstats["health"];

                }
            }
            return fitness * 10 + strength * 5 + itemBonus;
        }
        public int GetStamina()
        {
            int itemBonus = 0;
            for (int i = 0; i < inventory.equippedItems.Count; i++)
            {
                if (inventory.equippedItems[i] != null)
                {
                    itemBonus += inventory.equippedItems[i].itemstats["stamina"];

                }
            }
            return fitness * 7 + strength * 7 + itemBonus;
        }
        public int GetCarry()
        {
            int itemBonus = 0;
            for (int i = 0; i < inventory.equippedItems.Count; i++)
            {
                if (inventory.equippedItems[i] != null)
                {
                    itemBonus += inventory.equippedItems[i].itemstats["carry"];

                }
            }
            return strength + dexterity + itemBonus / 3;
        }
        public int GetAttackSpeed()
        {
            int itemBonus = 0;
            for (int i = 0; i < inventory.equippedItems.Count; i++)
            {
                if (inventory.equippedItems[i] != null)
                {
                    itemBonus += inventory.equippedItems[i].itemstats["attackSpeed"];

                }
            }
            return dexterity + itemBonus;
        }
        public int GetArmor()
        {
            int itemBonus = 0;
            for (int i = 0; i < inventory.equippedItems.Count; i++)
            {
                if (inventory.equippedItems[i] != null)
                {
                    itemBonus += inventory.equippedItems[i].itemstats["armor"];

                }
            }
            return dexterity + itemBonus;
        }
        public void EquipItem()
        {

            Console.WriteLine("ID to equip");
            int result;
            bool parsed;
            do
            {

                parsed = int.TryParse(Console.ReadLine(), out result);

            }
            while (!parsed);

            if (inventory.item[result].type == 0)
            {

                EquipWeapon(result);
            }
            else if (inventory.item[result].type == 1)
            {

                EquipArmor(result);
            }
            else
            {
                Console.Write("Failed");
            }
        }
        public void UnequipItem()
        {
            Console.WriteLine("Item to unequip");
            for (int i = 0; i < inventory.equippedItems.Count; i++)
            {
                Console.WriteLine("[" + i + "]" + inventory.equippedItems[i].name);

            }
            int unequip = Convert.ToInt32(Console.ReadLine());
            inventory.item.Add(inventory.equippedItems[unequip]);
            Console.WriteLine("Unequipped: " + inventory.equippedItems[unequip].name);
            inventory.equippedItems.RemoveAt(unequip);
        }
        public void EquipWeapon(int weaponID)
        {
            inventory.equippedItems.Add(inventory.item[weaponID]);

            Console.WriteLine("Slot to equip weapon on? 0-1");

            int handSlot = Convert.ToInt32(Console.ReadLine());
            bool result = WeaponHandler(handSlot);
            if (result == false)
            {
                //CheckInventory();
                return;
                
            }
            Weapon weapon = new Weapon(0);
            weapon = inventory.item[weaponID] as Weapon;
            EquipWeapon(weapon, handSlot);
            inventory.item.RemoveAt(weaponID);
            Console.WriteLine("Equipped : " + weapon.name + " at slot " + handSlot);

        }
        public void EquipArmor(int armorID)
        {
            inventory.equippedItems.Add(inventory.item[armorID]);


            Console.WriteLine("Slot to equip armor on? 0-2");
            int armorSlot = Convert.ToInt32(Console.ReadLine());
            bool result = ArmorHandler(armorSlot);
            if (result == false)
            {
                Console.WriteLine("SLOT IS OCCUPIED");

                //CheckInventory();
                return;
            }
            Armor armor = new Armor(1);
            armor = inventory.item[armorID] as Armor;
            EquipArmor(armor, armorSlot);
            inventory.item.RemoveAt(armorID);
            Console.WriteLine("Equipped : " + armor.name + " at slot " + armorSlot);
        }

        public void CheckEquippedItems()
        {
            for (int i = 0; i < inventory.equippedItems.Count; i++)
            {
                if (inventory.equippedItems[i].type == 0)
                {
                    Console.WriteLine("Weapons:" + inventory.equippedItems[i].name);

                }
                else
                    Console.WriteLine("Armor:" + inventory.equippedItems[i].name);
            }

        }

    }
}

