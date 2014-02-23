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

        public static void Run(int selectedLevel)
        {           
            //LABYRINTH
           // Labyrinth labyrinth = new Labyrinth();
            //Draw loaded labyrinth with default parameteres 0, 0
           // labyrinth.DrawObject();

            Level level;
            switch(selectedLevel)
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
           //LevelFactory l = new EasyLevelCreator();
           //Level level = l.GenerateLevel();

            //HERO
            Hero archer = new Archer(1, 1, 10, ConsoleColor.Cyan);
            //Load hero from file
            archer.LoadHero();
            //Draw loaded hero on the console screen with default position row = 1, col = 1
            archer.DrawObject();
            //Load hero collision
            archer.LoadHeroCollision();

            //ENEMIES
            //TEST - Load all enemies
            
            //List<Enemy> levelEnemies = level.EnemiesList;
            //List<Bonus> firstLevelBonuses = level.BonusesList;
            //foreach (var enemy in levelEnemies)
            //{
            //    enemy.LoadEnemy();
            //    enemy.DrawObject();
            //}

            //BNUSES
            //TEST = Load all bonuses
            //foreach (var bonus in firstLevelBonuses)
            //{
            //    bonus.DrawObject();
            //}

            
            while (true)
            {
                PrintOnPosition(82, 5, "Hero Lifes: " + archer.Lifes);
                PrintOnPosition(82, 7, "Damage: " + archer.Damage);
                PrintOnPosition(82, 9, "Shoot range: " + archer.Range);
                PrintOnPosition(82, 11, "Score: " + score);
                //Hero move or shoot (keypressed)
                archer.Move();
                //Check if some enemy is hitting us
                archer.CollisionWithEnemyCheck(level);
                //Bonus checks
                archer.PotentialCollideWithBonus(level);
                // Move all bullets and check for collision
                Bullet.BulletsMovement(listOfBullets, archer.Damage, level);
                //Move enemies
                foreach (var enemy in level.EnemiesList)
                {
                    enemy.Move();
                }
                //Slow down rendering speed
                if (archer.Lifes <= 0)
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
