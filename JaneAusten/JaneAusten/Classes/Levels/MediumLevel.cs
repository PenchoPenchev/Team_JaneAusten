using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class MediumLevel : Level
    {
        protected Random rand;
        public MediumLevel()
            : base()
        { }

        public MediumLevel(List<Enemy> enemiesList, List<Bonus> bonusesList)
            : base(enemiesList, bonusesList)
        { }

        public MediumLevel(List<Enemy> enemiesList, List<Bonus> bonusesList, Labyrinth labyrinth)
            : base(enemiesList, bonusesList, labyrinth)
        {
        }

        public override List<Enemy> GenerateEnemiesList()
        {
            var enemies = new List<Enemy>() {
                new FighterEnemy(50, 1, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel), 
                new FighterEnemy(3, 5, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel), 
                new FighterEnemy(26, 4, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel), 
                new FighterEnemy(18, 7, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel), 
                new FighterEnemy(3, 16, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
                new FighterEnemy(65, 16, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel), 
                new FighterEnemy(45, 20, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(3, 20, 70, 10, ConsoleColor.DarkRed, Levels.SecondLevel), 
                new FighterEnemy(18, 24, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel), 
                new FighterEnemy(65, 24, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel), 
                new FighterEnemy(3, 28, 70, 10, ConsoleColor.DarkRed, Levels.SecondLevel),
                new FighterEnemy(24, 32, 70, 10, ConsoleColor.DarkRed, Levels.SecondLevel),
                new FighterEnemy(31, 32, 70, 10, ConsoleColor.DarkRed, Levels.SecondLevel),
                new FighterEnemy(36, 32, 70, 10, ConsoleColor.DarkRed, Levels.SecondLevel),
                new FighterEnemy(65, 32, 70, 10, ConsoleColor.DarkRed, Levels.SecondLevel)
            };
            return enemies;
        }

        public override List<Bonus> GenerateBonusesList()
        {
            var bonuses = new List<Bonus>() {
                            new Bonus(11,2,BonusType.gold),
                            new Bonus(67,14,BonusType.extraDamage), 
                            new Bonus(10,14,BonusType.extraDamage),
                            new Bonus(45,2,BonusType.lifePotion), 
                            new HidingBonus(32,29,BonusType.extraDamage), 
                            new Bonus(26,2,BonusType.longerRange), 
                            new Bonus(67,2,BonusType.longerRange), 
                            new Bonus(25,13,BonusType.longerRange), 
                            new Bonus(67,29,BonusType.extraDamage), 
                            new Bonus(33,9,BonusType.extraDamage), 
                            new Bonus(3,25,BonusType.longerRange) 
            };
            return bonuses;
        }
    }
}
