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
            var hard = new HardLevel();

            return hard;
        }
    }
}
