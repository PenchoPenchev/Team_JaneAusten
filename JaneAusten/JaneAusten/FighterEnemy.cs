namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class FighterEnemy : Enemy, IMovable
    {
        public FighterEnemy(int x, int y, bool isDead, int health, int lives, int speed, ConsoleColor color, int level = 1)
            : base(x, y, isDead, health, lives, speed, color)
        {
            
        }

        public void Move()
        {
            
        }
    }
}
