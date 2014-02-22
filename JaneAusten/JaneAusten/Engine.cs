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

        public static void Run()
        {           
            //LABYRINTH
            Labyrinth labyrinth = new Labyrinth();
            //Draw loaded labyrinth with default parameteres 0, 0
            labyrinth.DrawObject();

            //HERO
            Archer archer = new Archer(1, 1, 10, ConsoleColor.Cyan);
            //Load hero from file
            archer.LoadHero();
            //Draw loaded hero on the console screen with default position row = 1, col = 1
            archer.DrawObject();
            //Load hero collision
            archer.LoadHeroCollision();

            //ENEMIES
            //TEST - Load all enemies
            foreach (var enemy in FirstLevel.listOfFighterEnemies)
            {
                enemy.LoadEnemy();
                enemy.DrawObject();
            }

            //BNUSES
            //TEST = Load all bonuses
            foreach (var bonus in FirstLevel.listOfBonuses)
            {
                bonus.DrawObject();
            }

            
            while (true)
            {
                PrintOnPosition(82, 5, "Hero lives: " + archer.Lives);
                PrintOnPosition(82, 7, "Damage: " + archer.Damage);
                PrintOnPosition(82, 9, "Score: " + score);
                //Hero move or shoot (keypressed)
                archer.Move();
                //Check if some enemy is hitting us
                archer.CollisionWithEnemyCheck();
                //Bonus checks
                archer.PotentialCollideWithBonus();
                // Move all bullets and check for collision
                BulletsMovement();
                //Move enemies
                foreach (var enemy in FirstLevel.listOfFighterEnemies)
                {
                    enemy.Move();
                }
                //Slow down rendering speed
                if (archer.Lives <= 0)
                {
                    Console.Clear();
                    break;
                }
                System.Threading.Thread.Sleep(100);
            }
            GameOver.Display();
        }

        public static void PrintOnPosition(int x, int y, string message)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
        }

        private static void BulletsMovement()
        {
            for (int bullet = listOfBullets.Count() - 1; bullet >= 0; bullet--)
            {
                listOfBullets[bullet].Move();
            }
        }
    }
}
