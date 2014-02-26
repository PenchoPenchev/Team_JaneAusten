using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class Level
    {
        private const int points = 100;

        private List<Enemy> enemiesList;
       
        private List<Bonus> bonusesList;

        public Labyrinth Labyrinth;

        public event EventHandler<KillEventArgs> OnKill;
        public Level()
        { }

        public Level(List<Enemy> enemiesList, List<Bonus> bonusesList)
        {
            this.EnemiesList = enemiesList;
            this.BonusesList = bonusesList;
        }
        public Level(List<Enemy> enemiesList, List<Bonus> bonusesList, Labyrinth labyrinth)
        {
            this.EnemiesList = enemiesList;
            this.BonusesList = bonusesList;
            this.Labyrinth = labyrinth;
        }

        public List<Enemy> EnemiesList
        {
            get
            {
                return this.enemiesList;
            }
            set
            {
                this.enemiesList = GenerateEnemiesList();
            }
        }

        public List<Bonus> BonusesList
        {
            get
            {
                return this.bonusesList;
            }
            set
            {
                this.bonusesList = GenerateBonusesList();
            }
        }

        private Levels LevelToughness { get; set; }

        public virtual List<Enemy> GenerateEnemiesList()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public virtual List<Bonus> GenerateBonusesList()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void RemoveAllDeadEnemies()
        {
            EventHandler<KillEventArgs> handler = OnKill;
            for (int indx = 0; indx < this.EnemiesList.Count; indx++)
            {
                if (this.EnemiesList[indx].Health <= 0)
                {
                    if (handler != null)
                    {
                        handler(this, new KillEventArgs(points));
                    }
                    //Engine.score += 100;
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

        public void RemoveBonus(Bonus bonus)
        {
            BonusesList.Remove(bonus);
        }

        //public List<Enemy> GetLevelEnemies()
        //{
        //    return enemiesList;
        //}
        //public List<Bonus> GetLevelBonuses()
        //{
        //    return bonusesList;
        //}
    }
}
