namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Media;
    
    public class FirstLevel
    {
        static string die = @"../../Content/die.wav";
        public static SoundPlayer dyingSound = new SoundPlayer(die);

        public static List<FighterEnemy> listOfFighterEnemies = new List<FighterEnemy>()
        {
            new FighterEnemy(35, 1, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
            new FighterEnemy(3, 9, 50, 5,ConsoleColor.DarkRed, Levels.FirstLevel),
            new FighterEnemy(26, 5, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
            new FighterEnemy(18, 6, 50, 5, ConsoleColor.DarkRed, Levels.FirstLevel),
            new FighterEnemy(28, 9, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
            new FighterEnemy(23, 17, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
            new FighterEnemy(18, 17, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
            new FighterEnemy(28, 17, 50, 10, ConsoleColor.DarkRed, Levels.FirstLevel),
            new FighterEnemy(60, 17, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
            new FighterEnemy(25, 21, 50, 10, ConsoleColor.DarkRed, Levels.FirstLevel),
            new FighterEnemy(27, 30, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel)
        };

        public static List<Bonus> listOfBonuses = new List<Bonus>()
        {
            new Bonus(8,6,BonusType.diamond),
            new Bonus(3,14,BonusType.gold),
            new Bonus(23,2,BonusType.extraDamage),
            new Bonus(24,6,BonusType.lifePotion),
            new HidingBonus(35,12,BonusType.lifePotion,10000),
            new Bonus(26,2,BonusType.longerRange),
            new Bonus(56,7,BonusType.longerRange),
            new Bonus(25,16,BonusType.longerRange),
            new Bonus(58,27,BonusType.extraDamage),
            new Bonus(35,26,BonusType.extraDamage),
            new Bonus(5,25,BonusType.longerRange),
            //    new HidingBonus(35,12,BonusType.livePotion,10000,2000,true),
        };

        public static void RemoveAllDeadEnemies()
        {
            for (int indx = 0; indx < listOfFighterEnemies.Count; indx++)
            {
                if (listOfFighterEnemies[indx].Health <= 0)
                {
                    dyingSound.Play();
                    Engine.score += 100;
                    for (int row = 0; row < Enemy.enemyFigure.GetLength(0); row++)
                    {
                        for (int col = 0; col < Enemy.enemyFigure.GetLength(1); col++)
                        {
                            Enemy deadEnemy = listOfFighterEnemies[indx];
                            Console.SetCursorPosition(deadEnemy.PosX + row, deadEnemy.PosY + col);
                            Console.Write(' ');
                        }
                    }
                    listOfFighterEnemies.RemoveAt(indx);
                }    
            }
        }
    }
}
