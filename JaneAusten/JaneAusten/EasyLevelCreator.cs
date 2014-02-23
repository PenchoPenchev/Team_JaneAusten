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
            easy.Labyrinth = new Labyrinth(@"..\..\Content\MazeLevel2.txt");
            easy.GenerateEnemiesList();
            easy.GenerateBonusesList();
            return easy;
        }
    }
}
