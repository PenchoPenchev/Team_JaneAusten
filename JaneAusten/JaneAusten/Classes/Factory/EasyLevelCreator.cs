﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class EasyLevelCreator : LevelFactory
    {
        public override Level GenerateLevel()
        {
            Level easy = new EasyLevel();
            easy.Labyrinth = new Labyrinth(@"..\..\Content\MazeLevel2.txt");
            easy.Labyrinth.DrawObject();
            var enemies = easy.GenerateEnemiesList();
            easy.EnemiesList = enemies;
            foreach (var enemy in enemies)
            {
                if (enemy.Level.Equals(Levels.ThirdLevel))
                {
                    throw new InvalidCreatureException("A creature intended for hard levels cannot be included in Easy levels.");
                }
                else
                {
                    enemy.LoadEnemy();
                    enemy.DrawObject();
                }
             
            }
            var bonuses = easy.GenerateBonusesList();
            easy.BonusesList = bonuses;
            foreach (var bonus in bonuses)
            {
                bonus.DrawObject();
            }
            
            return easy;
        }

        
    }
}
