using System;
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
            easy.Labyrinth = new Labyrinth(@"..\..\Content\MazeLevel4.txt");
            easy.Labyrinth.DrawObject();
            var enemies = easy.GenerateEnemiesList();
            //foreach (var enemy in enemies)
            //{
            //    enemy.LoadEnemy();
            //    enemy.DrawObject();
            //}
            var bonuses = easy.GenerateBonusesList();
            //foreach (var bonus in bonuses)
            //{
            //    bonus.DrawObject();
            //}
            return easy;
        }
    }
}
