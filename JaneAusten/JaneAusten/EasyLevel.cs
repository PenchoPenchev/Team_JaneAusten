using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class EasyLevel : Level
    {
        protected Random rand;
        public EasyLevel()
            : base()
        { 
        
        }

        public EasyLevel(List<Enemy> enemiesList, List<Bonus> bonusesList)
            : base(enemiesList, bonusesList)
        {
         
        }

        public EasyLevel(List<Enemy> enemiesList, List<Bonus> bonusesList, Labyrinth labyrinth)
            : base(enemiesList, bonusesList, labyrinth)
        {

        }
        public override List<Enemy> GenerateEnemiesList()
        {
            //int enemiesNumber = rand.Next(3, 5);
            var enemies = new List<Enemy>();
            for (int i = 0; i < 5; i++)
            {
                enemies.Add(new FighterEnemy(35, 1, 70, 10, ConsoleColor.DarkMagenta, Levels.SecondLevel));
            }

            return enemies;
        }

        public override List<Bonus> GenerateBonusesList()
        {
            var bonuses = new List<Bonus>();
            for (int i = 0; i < 3; i++)
            {
                bonuses.Add(new Bonus(3, 14, BonusType.gold));
            }
            return bonuses;
        }
    }
}
