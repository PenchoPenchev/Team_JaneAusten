using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class HeroMenu
    {
        public const string pressEsc = "Press Esc to go to main menu";
        public const string pressArrows = "Use left and right arrows to navigate";
        public const string pressEnter = "Press Enter to choose hero";
        public string Name{get; set;}
        public string InitialNumberLifes { get; set; }
        public string Weapon { get; set; }
        public string Damage { get; set; }
        public abstract void PrintHeroMenu();


    }
}
