using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class EnemyGenerator
    {
        public Enemy enemy;

        public void GenerateEnemy()
        {
            enemy = new Enemy("Björne", 5);
            enemy.CreateLoot();
        }
    }
}
