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
            var medium = new MediumLevel();
            return medium;
        }
    }
}
