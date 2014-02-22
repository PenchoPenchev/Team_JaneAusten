using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class Level
    {
        private List<Enemy> enemiesList;
        private List<Bonus> bonusesList;
        public Level()
        { }

        public Level(List<Enemy> enemiesList, List<Bonus> bonusesList)
        {
            this.EnemiesList = enemiesList;
            this.BonusesList = bonusesList;
        }

        protected List<Enemy> EnemiesList
        {
            get
            {
                return this.enemiesList;
            }
            private set
            {
                this.enemiesList = GenerateEnemiesList(this.LevelToughness);
            }
        }

        protected List<Bonus> BonusesList
        {
            get
            {
                return this.bonusesList;
            }
            private set
            {
                this.bonusesList = GenerateBonusesList(this.LevelToughness);
            }
        }

        protected Levels LevelToughness { get; set; }

        protected virtual List<Enemy> GenerateEnemiesList(Levels levelToughness)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        protected virtual List<Bonus> GenerateBonusesList(Levels levelToughness)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void RemoveAllDeadEnemies()
        {
            for (int indx = 0; indx < this.EnemiesList.Count; indx++)
            {
                if (this.EnemiesList[indx].Health <= 0)
                {
                    Engine.score += 100;
                    for (int row = 0; row < Enemy.enemyFigure.GetLength(0); row++)
                    {
                        for (int col = 0; col < Enemy.enemyFigure.GetLength(1); col++)
                        {
                            Enemy deadEnemy = this.EnemiesList[indx];
                            Console.SetCursorPosition(deadEnemy.PosX + row, deadEnemy.PosY + col);
                            Console.Write(' ');
                        }
                    }
                    this.EnemiesList.RemoveAt(indx);
                }
            }
        }


    }
}
