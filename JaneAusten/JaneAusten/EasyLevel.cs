﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class EasyLevel : Level
    {
        protected Random rand;
        public EasyLevel()
            : base()
        {

        }

        public EasyLevel(List<Enemy> enemiesList, List<Bonus> bonusesList)
            : base(enemiesList, bonusesList)
        {

        }

        public EasyLevel(List<Enemy> enemiesList, List<Bonus> bonusesList, Labyrinth labyrinth)
            : base(enemiesList, bonusesList, labyrinth)
        {

        }

        public override List<Enemy> GenerateEnemiesList()
        {
            var enemies = new List<Enemy>() {
                new FighterEnemy(35, 1, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
                new FighterEnemy(3, 9, 50, 5,ConsoleColor.DarkRed, Levels.FirstLevel),
                new FighterEnemy(26, 5, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
                new FighterEnemy(18, 6, 50, 5, ConsoleColor.DarkRed, Levels.FirstLevel),
                new FighterEnemy(28, 9, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
                new FighterEnemy(23, 17, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
                new FighterEnemy(18, 17, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
                new FighterEnemy(28, 17, 50, 10, ConsoleColor.DarkRed, Levels.FirstLevel),
                new FighterEnemy(60, 17, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel),
                new FighterEnemy(25, 21, 50, 10, ConsoleColor.DarkRed, Levels.FirstLevel),
                new FighterEnemy(27, 30, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel)
            };
            
            //for (int i = 0; i < 5; i++)
            //{
            //    enemies.Add(new FighterEnemy(35, 1, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel));
            //}

            return enemies;
        }

        public override List<Bonus> GenerateBonusesList()
        {
            var bonuses = new List<Bonus>() {
                            new Bonus(8,6,BonusType.diamond),
                            new Bonus(3,14,BonusType.gold),
                            new Bonus(23,2,BonusType.extraDamage),
                            new Bonus(24,6,BonusType.lifePotion),
                            new HidingBonus(35,12,BonusType.lifePotion,10000),
                            new Bonus(26,2,BonusType.longerRange),
                            new Bonus(56,7,BonusType.longerRange),
                            new Bonus(25,16,BonusType.longerRange),
                            new Bonus(58,27,BonusType.extraDamage),
                            new Bonus(35,26,BonusType.extraDamage),
                            new Bonus(5,25,BonusType.longerRange)
            };
            //for (int i = 0; i < 3; i++)
            //{
            //    bonuses.Add(new Bonus(3, 14, BonusType.gold));
            //}
            return bonuses;
        }

    }
}
