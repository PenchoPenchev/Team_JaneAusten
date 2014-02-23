namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class Shooter : Hero, IMovable, IDrawable
    {
        private char shotDirection = 'R';
        private char shotSybmol = '→';

        public char ShotSymbol
        {
            get { return this.shotSybmol; }
            private set { this.shotSybmol = value; }
        }
        
        public Shooter(int x, int y, int speed, ConsoleColor color,
            int health = 100, int Lifes = 2, int damage = 20, int range = 3)
            : base(x, y, speed, color, health, Lifes, damage, range)
        {
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

    }
}
