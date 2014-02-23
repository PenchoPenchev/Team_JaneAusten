using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class MediumLevelCreator : LevelFactory
    {
        public override Level GenerateLevel()
        {
            Level medium = new MediumLevel();
            medium.Labyrinth = new Labyrinth(@"..\..\Content\MazeLevel3.txt");
            medium.Labyrinth.DrawObject();
            var enemies = medium.GenerateEnemiesList();
            medium.EnemiesList = enemies;
            foreach (var enemy in enemies)
            {
                enemy.LoadEnemy();
                enemy.DrawObject();
            }
            var bonuses = medium.GenerateBonusesList();
            medium.BonusesList = bonuses;
            foreach (var bonus in bonuses)
            {
                bonus.DrawObject();
            }
            
            return medium;
        }
    }
}
