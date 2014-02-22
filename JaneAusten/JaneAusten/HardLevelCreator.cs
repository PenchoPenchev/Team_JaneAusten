using System;
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
            hard.GenerateEnemiesList();
            hard.GenerateBonusesList();
            return hard;
        }
    }
}
