using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class Door
    {
        public Room originRoom;
        public Room connectingRoom;


        public Door(Room oR, Room cR)
        {

            originRoom = oR;
            connectingRoom = cR;
        }

        public Room GetOppositeRoom(Room currentRoom)
        {
            if (currentRoom == originRoom)
            {
                return connectingRoom;
            }
            return originRoom;

        }
    }
}
