using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class ArcherEnemy : Enemy
    {
        public ArcherEnemy(int x, int y, bool isDead, int health, int lives, int speed, ConsoleColor color, int level = 1)
            : base(x, y, isDead, health, lives, speed, color)
        {
            
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
