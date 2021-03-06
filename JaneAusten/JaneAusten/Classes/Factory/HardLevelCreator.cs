﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class HardLevelCreator : LevelFactory
    {
        public override Level GenerateLevel()
        {
            Level hard = new HardLevel();
            hard.Labyrinth = new Labyrinth(@"..\..\Content\MazeLevel4.txt");
            hard.Labyrinth.DrawObject();
            var enemies = hard.GenerateEnemiesList();
            hard.EnemiesList = enemies;
            foreach (var enemy in enemies)
            {
                if (enemy.Level.Equals(Levels.FirstLevel))
                {
                    throw new InvalidCreatureException("A creature intended for easy levels cannot be included in Hard levels.");
                }
                else
                {
                    enemy.LoadEnemy();
                    enemy.DrawObject();
                }
            }
            var bonuses = hard.GenerateBonusesList();
            hard.BonusesList = bonuses;
            foreach (var bonus in bonuses)
            {
                bonus.DrawObject();
            }
            return hard;
        }
    }
}
