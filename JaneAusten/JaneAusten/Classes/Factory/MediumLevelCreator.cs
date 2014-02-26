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
            var checkEnemies = (from en in enemies where en.Level.Equals(Levels.SecondLevel) select en).ToArray();
            if (checkEnemies.Length == 0)
            {
                throw new InvalidCreatureException("The medium level must contain at least one SecondLevel creature!");
            }
            else
            {
                checkEnemies.Count();
                medium.EnemiesList = enemies;
                foreach (var enemy in enemies)
                {
                    enemy.LoadEnemy();
                    enemy.DrawObject();
                }
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
