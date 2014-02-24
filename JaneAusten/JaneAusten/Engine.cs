namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        public static int score = 0;

        public static List<Bullet> listOfBullets = new List<Bullet>();

        public static void Run(HeroMenu hero, int selectedLevel)
        {
            //HERO
            Hero choosenHero = new Archer(1, 1, 10, ConsoleColor.Cyan);
            
            if (hero is LadyKillerMenu)
            {
                choosenHero = new Shooter(1, 1, 10, ConsoleColor.Magenta);
            }

            //Load hero from file
            choosenHero.LoadHero(choosenHero.GetType().Name);
            //Draw loaded hero on the console screen with default position row = 1, col = 1
            choosenHero.DrawObject();
            //Load hero collision
            choosenHero.LoadHeroCollision();

            Level level;
            switch (selectedLevel)
            {
                case 1:
                    {
                        LevelFactory l = new EasyLevelCreator();
                        level = l.GenerateLevel();
                        break;
                    }
                case 2:
                    {
                        LevelFactory l = new MediumLevelCreator();
                        level = l.GenerateLevel();
                        break;
                    }
                case 3:
                    {
                        LevelFactory l = new HardLevelCreator();
                        level = l.GenerateLevel();
                        break;
                    }
                default:
                    {
                        LevelFactory l = new EasyLevelCreator();
                        level = l.GenerateLevel();
                        break;
                    }
            }
        
            while (true)
            {
                PrintOnPosition(82, 5, "Hero Lifes: " + choosenHero.Lifes);
                PrintOnPosition(82, 7, "Damage: " + choosenHero.Damage);
                PrintOnPosition(82, 9, "Shoot range: " + choosenHero.Range);
                PrintOnPosition(82, 11, "Score: " + score);
                //Hero move or shoot (keypressed)
                choosenHero.Move();
                //Check if some enemy is hitting us
                choosenHero.CollisionWithEnemyCheck(level);
                //Bonus checks
                choosenHero.PotentialCollideWithBonus(level);
                // Move all bullets and check for collision
                Bullet.BulletsMovement(listOfBullets, choosenHero.Damage, level);
                //Move enemies
                foreach (var enemy in level.EnemiesList)
                {
                    enemy.Move();
                }
                //Slow down rendering speed
                if (choosenHero.Lifes <= 0)
                {
                    Console.Clear();
                    break;
                }
                System.Threading.Thread.Sleep(100);
            }
            //GameOver.Display();
        }

        private static void PrintOnPosition(int x, int y, string message)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
        }

        
    }
}
