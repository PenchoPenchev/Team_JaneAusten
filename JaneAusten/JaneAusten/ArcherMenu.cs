using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JaneAusten
{
   public class ArcherMenu : HeroMenu
    {
       private const string menuPath = @"..\..\Content\ArcherMenu.txt";
       private const int archerInfoLeft = 62;
       private const int archerInfoTop = 7;
        public ArcherMenu()
        {
            this.Damage = "DAMAGE: 20";
            this.Name = " NAME: The Mighty Archer";
            this.Weapon = "WEAPON: Bow and arrows";
            this.Range = "SHOOT RANGE: ? ";
            this.InitialNumberLifes = "LIFES: 3";
        }
       public override StringBuilder ReadHeroMenu(string path)
        {
            StringBuilder component = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        component.AppendLine(line);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file {0} can not be found!", path);
            }
            return component;
        }
        public override void PrintHeroMenu()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        Console.Clear();
                        var ladyHero = new LadyKillerMenu();
                        ladyHero.PrintHeroMenu();
                    }

                    else if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        ArcherMenu archer = new ArcherMenu();
                        LevelDifficulty.DrawDifficulty(archer);
                    }
                    else if (pressedKey.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        StartMenu.DrawMenu();
                    }
                }
                var archerMenu = new ArcherMenu();
                StartMenu.DrawComponent(archerMenu.ReadHeroMenu(menuPath).ToString(), 0, 0, ConsoleColor.DarkGreen);    
                StartMenu.DrawComponent(Name, archerInfoLeft, archerInfoTop, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(Weapon, archerInfoLeft, archerInfoTop + 3, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(Damage, archerInfoLeft, archerInfoTop + 6, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(InitialNumberLifes, archerInfoLeft, archerInfoTop + 9, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(Range, archerInfoLeft, archerInfoTop + 12, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(pressArrows,archerInfoLeft,archerInfoTop + 22, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(pressEnter,archerInfoLeft,archerInfoTop + 24,ConsoleColor.DarkYellow );
                StartMenu.DrawComponent(pressEsc, archerInfoLeft, archerInfoTop + 26, ConsoleColor.DarkYellow);

                System.Threading.Thread.Sleep(200);
            }
        }
    }
}