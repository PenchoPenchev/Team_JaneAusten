namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    public class Engine
    {
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

            //ENEMIES
            //TEST - Load all enemies
            foreach (var enemy in FirstLevel.listOfFighterEnemies)
            {
                enemy.LoadEnemy();
                enemy.DrawObject();
            }

            while (true)
            {
                //Hero move or shoot (keypressed)
                archer.MoveAndShoot();
                
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

        public static void PrintOnPosition(int x, int y, char chr, ConsoleColor color = ConsoleColor.Magenta)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(chr);
        }
    }
}
