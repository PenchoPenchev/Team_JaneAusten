namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class ArcherEnemy : Enemy, IDrawable, IShootable
    {
        public ArcherEnemy(int x, int y, int health, int speed, ConsoleColor color, Levels level)
            : base(x, y, health, speed, color, level)
        {
            
        }

        public void TakeDamage(ArcherEnemy enemy, double damage)
        {
            enemy.Health -= (int)damage;
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

       

        public void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
