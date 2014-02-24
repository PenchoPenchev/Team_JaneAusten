using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    class LadyKillerMenu : HeroMenu
    {
        private const string menuPath = @"..\..\Content\LadyKillerMenu.txt";
        private const int shooterInfoLeft = 63;
        private const int shooterInfoTop = 7;
       
        public LadyKillerMenu()
        {
            this.Damage = "DAMAGE: 30";
            this.Name = " NAME: Lady X";
            this.Weapon = "WEAPON: Pistol";
            this.InitialNumberLifes = "LIFES: 2";
            this.Range = "SHOOT RANGE: ?";
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
                Console.WriteLine("The file {0} can not be found!", menuPath);
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

                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        Console.Clear();
                        ArcherMenu archerMenu = new ArcherMenu();
                        archerMenu.PrintHeroMenu();
                    }

                    else if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        var shooter = new LadyKillerMenu();
                        EnterName.DrawNameChoice(shooter);
                    }
                    else if (pressedKey.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        StartMenu.DrawMenu();
                    }
                }
                var ladyhero = new LadyKillerMenu();
                StartMenu.DrawComponent(ladyhero.ReadHeroMenu(menuPath).ToString(), 0, 0, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(Name, shooterInfoLeft, shooterInfoTop, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(Weapon, shooterInfoLeft, shooterInfoTop + 3, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(Damage, shooterInfoLeft, shooterInfoTop + 6, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(InitialNumberLifes, shooterInfoLeft, shooterInfoTop + 9, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(Range, shooterInfoLeft, shooterInfoTop + 12, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(pressArrows, shooterInfoLeft, shooterInfoTop + 22, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(pressEnter, shooterInfoLeft, shooterInfoTop + 24, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(pressEsc, shooterInfoLeft, shooterInfoTop + 26, ConsoleColor.DarkGreen);

                System.Threading.Thread.Sleep(200);
            }
        }
        
    }
}