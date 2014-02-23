using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    class LadyKillerMenu : HeroMenu
    {
        private const int shooterInfoLeft = 63;
        private const int shooterInfoTop = 7;
        private const string typeHero = @" 
                                                                ▄▄▄ ▄  ▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄▄▄
                                                                █▄▄ █▄▄█ █ █ █ █  █  █▄▄ █▄█
                                                                ▄▄█ █  █ █▄█ █▄█  █  █▄▄ █▀▄
                                ";
        private const string shooter = @"

       _)\____________________________________/7_
    (//   )))))                                   `\||
     /   (((((                                      )`
    (______________________________________________/
     \   ________ ______________________________/
      ) /#######/ )\  /     )/
     / /##(\)##/ /  \(            ******       ******
    / /#######( (\______.ad     **********   **********
   / /#########) )------``    ************* *************
  / /#########/ /            *****************************
 / /###(/)###/ /             *****************************
( (#########/ (              *****************************        
 \____/_______\)              ***************************        
                                ***********************        
                                  *******************        
                                    ***************        
                                      ***********        
                                        *******        
                                          ***        
                                           *         ";
        public LadyKillerMenu()
        {
            this.Damage = "DAMAGE: 30";
            this.Name = " NAME: Lady X";
            this.Weapon = "WEAPON: Pistol";
            this.InitialNumberLifes = "LIFES: 2";
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
                        LevelDifficulty.DrawDifficulty();
                    }
                    else if (pressedKey.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        StartMenu.DrawMenu();
                    }
                }
                StartMenu.DrawComponent(typeHero, 15, 0, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(shooter, 0, 8, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(Name, shooterInfoLeft, shooterInfoTop, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(Weapon, shooterInfoLeft, shooterInfoTop + 3, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(Damage, shooterInfoLeft, shooterInfoTop + 6, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(InitialNumberLifes, shooterInfoLeft, shooterInfoTop + 9, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(pressArrows, shooterInfoLeft, shooterInfoTop + 21, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(pressEnter, shooterInfoLeft, shooterInfoTop + 23, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(pressEsc, shooterInfoLeft, shooterInfoTop + 25, ConsoleColor.DarkYellow);

                System.Threading.Thread.Sleep(200);
            }
        }
    }
}
