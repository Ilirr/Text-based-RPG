using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class Fight
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }
        public bool Turn { get; set; } // TRUE = PLAYER, FALSE = ENEMY

        public Fight(Player player, Enemy enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
            this.Turn = true;

            while (Player.Health > 0 && Enemy.Hp > 0)
            {
                if(Turn==true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Fight! Enter how much damage to deal: "); // OP mechanic YEP
                    player.Damage = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(this.Player.Name + "Attacks with: " + player.Damage);
                    Damage(player.Damage);
                    Turn = false;


                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\n{0} attacks {1}", this.Enemy.Details(), this.Player.Name);
                    Damage(randomNumberGenerator(1, 5));
                    Turn = true;
                }
            }
     
        }
        private static Random rand = new Random();
        public int randomNumberGenerator(int start, int end)
        {
            int num = rand.Next(start, end);
            return num;
        }

        public void Damage(int dmgAmount)
        {
            if(Turn == true)
            {
                Enemy.Hp -= dmgAmount;
                if(Enemy.Hp <= 0)
                {
                    Enemy.fought = true;

                    endMessage(true);
                }

            }
            else
            {
                Player.Health -= dmgAmount;
                if (Player.Health <= 0)
                    endMessage(false);
            }
        }   
        public void endMessage(bool state)
        {
            if (state)
            {

                Console.WriteLine("\n{0} has defeated {1}!\n", Player.Name, Enemy.Name);
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.WriteLine("\n{0} has defeated {1}!\nGAME OVER", Enemy.Name, Player.Name);
                Environment.Exit(0);
            }
            
        }
    }
}
