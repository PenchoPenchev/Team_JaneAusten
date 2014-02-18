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
            Labyrinth labyrinth = new Labyrinth();
            //Draw loaded labyrinth with default parameteres 0, 0
            labyrinth.DrawObject(0, 0);

            Archer archer = new Archer(1, 1, false, 10, ConsoleColor.Cyan);
            //Load hero from file
            archer.LoadHero();
            //Draw loaded hero on the console screen with default position row = 1, col = 1
            archer.DrawObject(1, 1);

            while (true)
            {
                //Hero move or shoot (keypressed)
                archer.MoveAndShoot();
                //Read all bullets from the list and increment their positions according each shotSymbol
                archer.MoveAllBulletsOneStepForward();
                //Read all bullets and print them on the console
                archer.PrintAllBullets();
            
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
