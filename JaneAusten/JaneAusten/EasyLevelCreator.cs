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
            var easy = new EasyLevel();
          
            return easy;
        }
    }
}
