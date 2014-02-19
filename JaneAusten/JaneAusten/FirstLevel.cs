using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class FirstLevel
    {
        public static List<FighterEnemy> listOfFighterEnemies = new List<FighterEnemy>()
        {
            new FighterEnemy(10, 1, false, 50, 1, 5, ConsoleColor.DarkRed, 1),
            new FighterEnemy(17, 1, false, 50, 1, 5, ConsoleColor.DarkRed, 1),
            new FighterEnemy(26, 5, false, 50, 1, 5, ConsoleColor.DarkRed, 1)
        };

        public static void RemoveAllDeadEnemies()
        {
            for (int indx = 0; indx < listOfFighterEnemies.Count; indx++)
            {
                if (listOfFighterEnemies[indx].Health <= 0)
                {
                    listOfFighterEnemies[indx].IsDead = true;
                    for (int row = 0; row < Enemy.enemyFigure.GetLength(0); row++)
                    {
                        for (int col = 0; col < Enemy.enemyFigure.GetLength(1); col++)
                        {
                            Enemy deadEnemy = listOfFighterEnemies[indx];
                            Console.SetCursorPosition(deadEnemy.PosX + row, deadEnemy.PosY + col);
                            Console.Write(' ');
                        }
                    }
                    listOfFighterEnemies.RemoveAt(indx);
                }    
            }
        }
    }
}
