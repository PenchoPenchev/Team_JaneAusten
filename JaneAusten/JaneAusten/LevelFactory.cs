using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class LevelFactory : Level
    {
        public abstract Level GenerateLevel();
    }
}
