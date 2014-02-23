using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
   public class ArcherMenu : HeroMenu
    {
       private const int archerInfoLeft = 62;
       private const int archerInfoTop = 7;
        private const string typeHero = @"
                                                              ▄▄▄▄ ▄▄▄ ▄▄▄ ▄  ▄ ▄▄▄ ▄▄▄
                                                              █▄▄█ █▄█ █   █▄▄█ █▄▄ █▄█
                                                              █  █ █▀▄ █▄▄ █  █ █▄▄ █▀▄
                                 ";

        private const string archer = @"
                                                         
       -\                                  /\.                                             
         \\                              /   |.
           \\                          /     |.
            \|                       /       |.
              \#####\              /         |\
          ==###########>         /           ||
           \##==      \        /             ||
      ______ =       =|__ _  /               ||
  ,--' ,----`-,__ ___/'  --,-`-==============##==========>
 \               '        ##____ __,--,____,=##,__
  `,    __==    ___,-,__,--'#\'='          | ##,-/
    `-,____,---'       \###\        ____,--\_##,/
        #_              |##  \ __--'         ##
         #              ]===--=\             ||
          #_            |        \           ||
           ##_       __/'          \         |/
            ####='     |             \       |.  
             ###       |               \     |.  
             ##       _'                 \   |.  
            ###=======]                    \/.                        
                                               ";
        public ArcherMenu()
        {
            this.Damage = "DAMAGE: 20";
            this.Name = " NAME: The Mighty Archer";
            this.Weapon = "WEAPON: Bow and arrows";
            this.InitialNumberLifes = "LIFES: 3";
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
                        LevelDifficulty.DrawDifficulty();
                    }
                    else if (pressedKey.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        StartMenu.DrawMenu();
                    }
                }
                StartMenu.DrawComponent(typeHero, 15, 0, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(archer, 0, 4, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(Name, archerInfoLeft, archerInfoTop, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(Weapon, archerInfoLeft, archerInfoTop + 3, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(Damage, archerInfoLeft, archerInfoTop + 6, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(InitialNumberLifes, archerInfoLeft, archerInfoTop + 9, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(pressArrows,archerInfoLeft,archerInfoTop + 21, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(pressEnter,archerInfoLeft,archerInfoTop + 23,ConsoleColor.DarkYellow );
                StartMenu.DrawComponent(pressEsc, archerInfoLeft, archerInfoTop + 25, ConsoleColor.DarkYellow);

                System.Threading.Thread.Sleep(200);
            }
        }
    }
}

        
    

