using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class HardLevel : Level
    {
        protected Random rand;
        public HardLevel() : base()
        { }

        public HardLevel(List<Enemy> enemiesList, List<Bonus> bonusesList)
            : base(enemiesList, bonusesList)
        { }

        public HardLevel(List<Enemy> enemiesList, List<Bonus> bonusesList, Labyrinth labyrinth)
            : base(enemiesList, bonusesList, labyrinth)
        {
        }
        public override List<Enemy> GenerateEnemiesList()
        {
            var enemies = new List<Enemy>() {
                new FighterEnemy(50, 1, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(67, 2, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(3, 5, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel), 
                new FighterEnemy(18, 5, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(26, 5, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(35, 5, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel), 
                new FighterEnemy(48, 6, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
  
                new FighterEnemy(6, 15, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(9, 15, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                 
                new FighterEnemy(6, 18, 200, 30, ConsoleColor.White, Levels.ThirdLevel),
                 
                new FighterEnemy(6, 21, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                
                new FighterEnemy(9, 21, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(30, 14, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(44, 14, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel), 
                new FighterEnemy(30, 20, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(45, 20, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel), 
                new FighterEnemy(18, 25, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(60, 25, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(3, 26, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(3, 32, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(9, 32, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(18, 32, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(24, 32, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(31, 32, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(36, 32, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
                new FighterEnemy(65, 32, 100, 20, ConsoleColor.DarkYellow, Levels.ThirdLevel),
            };
            return enemies;
        }

        public override List<Bonus> GenerateBonusesList()
        {
            var bonuses = new List<Bonus>() {
                            new Bonus(67,1,BonusType.longerRange),
                            new Bonus(9,2,BonusType.longerRange),
                            new Bonus(12,2,BonusType.extraDamage), 
                            new Bonus(12,6,BonusType.diamond),
                            new Bonus(12,8,BonusType.diamond),
                            new Bonus(12,10,BonusType.diamond),
                            new Bonus(33,10,BonusType.gold),
                            new Bonus(42,10,BonusType.gold), 
                            new Bonus(67,14,BonusType.extraDamage), 
                            new Bonus(3,14,BonusType.extraDamage), 
                            new HidingBonus(43,29,BonusType.lifePotion)               
            };
            return bonuses;
        }
    }
}
