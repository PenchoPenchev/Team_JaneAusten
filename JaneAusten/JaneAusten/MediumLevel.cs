using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class MediumLevel : Level
    {
        protected Random rand;
        public MediumLevel()
            : base()
        { }

        public MediumLevel(List<Enemy> enemiesList, List<Bonus> bonusesList)
            : base(enemiesList, bonusesList)
        { }

        public MediumLevel(List<Enemy> enemiesList, List<Bonus> bonusesList, Labyrinth labyrinth)
            : base(enemiesList, bonusesList, labyrinth)
        {
        }

        public override List<Enemy> GenerateEnemiesList()
        {
            int enemiesNumber = rand.Next(6, 10);
            var enemies = new List<Enemy>();
            for (int i = 0; i < enemiesNumber; i++)
            {
                enemies.Add(new FighterEnemy());
            }

            return enemies;
        }

        public override List<Bonus> GenerateBonusesList()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
