namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Media;
    
    public class Bonus : GameObject, ICollectable, IDrawable
    {
        static string collect = @"../../Content/collect.wav";
        public static SoundPlayer collectBonus = new SoundPlayer(collect);

        public BonusType Type { get; set; }

        public bool IsCollected { get; set; }


        public Bonus(int x, int y, BonusType type)
            : base(x, y)
        {
            Type = type;
            IsCollected = false;
        }

        public void Collect()
        {
            collectBonus.Play();
            this.IsCollected = true;
        }

        public void DrawObject()
        {
            string item;
            Console.SetCursorPosition(this.PosX, this.PosY); 
            switch (this.Type)
            {
                case BonusType.gold: 
                    item = "⌂"; Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(item); break;
                case BonusType.diamond: 
                    item = " ♦"; Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine(item); break;
                case BonusType.extraDamage: 
                    item = "D"; Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(item); break;
                case BonusType.lifePotion: 
                    item = "♥"; Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(item); break;
                case BonusType.longerRange: 
                    item = "R"; Console.ForegroundColor = ConsoleColor.Blue; Console.Write(item); break;
            }
        }


        public void ClearObject()
        {
            throw new NotImplementedException();
        }
    }
}
