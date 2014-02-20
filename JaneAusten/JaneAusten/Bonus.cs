using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JaneAusten
{
    public class Bonus : GameObject, ICollectable, IDrawable
    {

        public BonusType Type { get; set; }

        public bool isCollected { get; set; }


        public Bonus(int x, int y, BonusType type)
            : base(x, y)
        {
            Type = type;
            isCollected = false;
        }

        public void Collect()
        {
            this.isCollected = true;
        }

        public void DrawObject()
        {
            string item;
            Console.SetCursorPosition(this.PosX, this.PosY); 
            switch (this.Type)
            {
                case BonusType.gold: item = "o"; Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(item); break;
                case BonusType.diamond: item = "*"; Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine(item); break;
                case BonusType.extraDamage: item = "D"; Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(item); break;
                case BonusType.livePotion: item = "H"; Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(item); break;
            }
        }

        
    }
}
