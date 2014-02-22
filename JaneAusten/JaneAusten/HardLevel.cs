using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class HardLevel : Level
    {
        public HardLevel() : base()
        { }

        public HardLevel(List<Enemy> enemiesList, List<Bonus> bonusesList)
            : base(enemiesList, bonusesList)
        { }

        protected override List<Enemy> GenerateEnemiesList(Levels levelToughness)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        protected override List<Bonus> GenerateBonusesList(Levels levelToughness)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
