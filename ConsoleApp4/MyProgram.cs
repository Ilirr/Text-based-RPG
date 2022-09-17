using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp4
{

    class MyProgram
    {
        ItemGenerator itemGen = new ItemGenerator();
        Player player;
        ItemHandler itemHandler = new ItemHandler();
        bool notQuit = true;
        Room currentRoom = Room.CreateRoom("Entrance");

        public void Run()
        {
            Console.WriteLine("Name: ");
            string playerName = Console.ReadLine();

            player = new Player(playerName, 5, 5, 5, 5, 5, 5);

            Console.WriteLine("Your name is: " + playerName);

            itemGen.GenerateItems(currentRoom);
            currentRoom.player = player;
            currentRoom.Enter();
            while (notQuit)
            {
                Game();

            }
        }
        void Game()
        {
            while (notQuit)
            {
                PlayerOptions();
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        CheckLoot();
                        break;
                    case 2:
                        CheckStats();
                        break;
                    case 3:
                        CheckInventory();
                        break;
                    case 4:
                        EnterRoom();
                        break;
                    case 5:
                        notQuit = false;
                        Environment.Exit(1);
                        return;


                }
            }

        }
        void CheckLoot()
        {
            EnemyEncounter();
            Console.WriteLine("Loot: ");
            for (int i = 0; i < currentRoom.lootList.Count; i++)
            {

                Console.WriteLine("[" + i + "]" + currentRoom.lootList[i].name);

            }
            Console.WriteLine("1 - pick up, else - back");
            int addLoot = Convert.ToInt32(Console.ReadLine());
            if (addLoot == 1)
            {
                AddLoot();

            }
            else
                return; // specify return 
        }
        void EnemyEncounter()
        {
            EnemyGenerator enemyGen = new EnemyGenerator();

            enemyGen.GenerateEnemy();
            while (!enemyGen.enemy.fought)
            {
                Console.WriteLine(enemyGen.enemy.Details());
                Fight enemyFight = new Fight(player, enemyGen.enemy);
                Console.WriteLine(enemyGen.enemy.Name + " loot was dropped on the floor");
                for (int i = 0; i < enemyGen.enemy.enemyLoot.item.Count; i++)
                {
                    currentRoom.lootList.Add(enemyGen.enemy.enemyLoot.item[i]);

                }
            }
        }
        void EnterRoom()
        {
            if (currentRoom.doors.Count > 0)
            {
                Console.WriteLine("Room to enter?");
                for (int i = 0; i < currentRoom.doors.Count; i++)
                {
                    Console.WriteLine(i + ": " + currentRoom.doors[i].GetOppositeRoom(currentRoom).roomName);
                }
                int selectedRoom = int.Parse(Console.ReadLine());
                currentRoom = currentRoom.GetRoomFromId(selectedRoom);
                currentRoom.Enter();
                itemGen.GenerateItems(currentRoom);

            }
            else
                Console.WriteLine("No connecting rooms");
        }
        
        void CheckInventory()
        {

            for (int i = 0; i < player.inventory.item.Count; i++)
            {
                Console.WriteLine("[" + i + "]" + player.inventory.item[i].name);
            }
            if (player.inventory.item.Count > 0)
            {
                Console.WriteLine("1 - equip, 2 - back");

            }
            else
            {
                Console.WriteLine("No items, 2 - go back, 3 - equipped items, 4 - unequip item");
            }

            int equipChoice = Convert.ToInt32(Console.ReadLine());
            if (equipChoice == 1 && player.inventory.item.Count > 0)
                player.EquipItem();
            else if (equipChoice == 2 && player.inventory.item.Count == 0)
                return;
            else if (equipChoice == 3)
                player.CheckEquippedItems();
            else if (equipChoice == 4)
                player.UnequipItem();
            else
                Console.WriteLine("Invalid input, going back");

        }
        
        void AddLoot()
        {
            Console.WriteLine("ID to pick up");
            int id = Convert.ToInt32(Console.ReadLine());
            player.inventory.item.Add(currentRoom.lootList[id]);
            Console.WriteLine("Added: " + currentRoom.lootList[id].name);
            currentRoom.lootList.RemoveAt(id);

            for (int i = 0; i < player.inventory.item.Count; i++)
            {
                Item item = itemHandler.CreateItem(player.inventory.item[i].name);
                player.inventory.item[i] = item;
                Console.WriteLine("Created: " + player.inventory.item[i].name + " at type : " + player.inventory.item[i].type);
            }
        }
        
        void CheckStats()
        {
            Console.WriteLine("Attack: " + player.GetAttack());
            Console.WriteLine("AttackSpeed: " + player.GetAttackSpeed());
            Console.WriteLine("Armor: " + player.GetArmor());
            Console.WriteLine("Health: " + player.GetHealth());
            Console.WriteLine("Magic: " + player.GetMagic());
            Console.WriteLine("Carry: " + player.GetCarry());
            Console.WriteLine("Stamina: " + player.GetStamina());

        }
        void PlayerOptions()
        {
            Console.WriteLine("1 - Search room");
            Console.WriteLine("2 - Check stats");
            Console.WriteLine("3 - Check inventory");
            Console.WriteLine("4 - Enter new room");
            Console.WriteLine("5 - Quit");

        }

    }
}
