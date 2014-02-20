namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    public class Engine
    {
        public static List<Bullet> listOfBullets = new List<Bullet>();
        public static void Run()
        {
            //LABYRINTH
            Labyrinth labyrinth = new Labyrinth();
            //Draw loaded labyrinth with default parameteres 0, 0
            labyrinth.DrawObject();

            //HERO
            Archer archer = new Archer(1, 1, false, 10, ConsoleColor.Cyan);
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



            while (true)
            {
                PrintOnPosition(70, 5, "Hero lives: " + archer.Lives);
                //Hero move or shoot (keypressed)
                archer.MoveAndShoot();
                archer.ResetHeroPosition();


                BulletsMovement();

                //Move enemies
                //Check if some enemy is hitting us
                //Console clear
                //Console.Clear();
                //Redraw playfield
                //Redraw hero
                //Redraw left enemies

                //Slow down rendering speed
                System.Threading.Thread.Sleep(100);
            }
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
                Console.SetCursorPosition(listOfBullets[bullet].PosX, listOfBullets[bullet].PosY);
                Console.Write(listOfBullets[bullet].BulletSymbol);
                listOfBullets[bullet].Move();
            }
        }
    }
}
