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
            medium.GenerateEnemiesList();
            medium.GenerateBonusesList();
            return medium;
        }
    }
}
