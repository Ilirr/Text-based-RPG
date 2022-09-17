using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class Room
    {
        public List<Item> lootList = new List<Item>();
        
        public string roomName;
        public Player player;
        public Enemy enemy;

        public Fight roomFight;

        public List<Door> doors;
        public Room(string name)
        {
            roomName = name;
            doors = new List<Door>();
        }
        public void Enter()
        {
            Console.WriteLine("You entered: " + roomName);

            if(doors.Count > 0)
            {
                for (int i = 0; i < doors.Count; i++)
                {
                   Console.WriteLine(i + ": " + doors[i].GetOppositeRoom(this).roomName);

                }
            }
            else
            {
                Console.WriteLine(" No connecting rooms");
            }
        }
        public Room GetRoomFromId(int id)
        {
            return doors[id].GetOppositeRoom(this);
        }
        public static Room CreateRoom(string name)
        {
            Room room = new Room(name);

            if (name == "Entrance")
            {
                Room kitchen = Room.CreateRoom("Kitchen");
                Room cave = Room.CreateRoom("Cave");



                Door kitchenDoor = new Door(room,kitchen);
                Door caveDoor = new Door(room, cave);

                room.doors.Add(kitchenDoor);
                room.doors.Add(caveDoor);

                kitchen.doors.Add(kitchenDoor);
                cave.doors.Add(caveDoor);
            }
            else if(name == "Kitchen")
            {
                Room pantry = new Room("Pantry");
                Door pantryDoor = new Door(room, pantry);
                pantry.doors.Add(pantryDoor);
                room.doors.Add(pantryDoor);
            }
            else if(name == "Cave")
            {
                Room random = new Room("WAAA");
                Door entranceDoor = new Door(room, random);

                random.doors.Add(entranceDoor);
                room.doors.Add(entranceDoor);
            }
            return room;
        }
    }
}
