namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        // public static int score = 0;

        private static Hero choosenHero;

        public static List<Bullet> listOfBullets = new List<Bullet>();

        private static int hidingBonusesMaxValue = 50;
        private static int hidingBonusesValue = 0;

        private const string goodByePath = @"..\..\Content\GoodBye.txt";

        private static bool stopGame = false;
        public static void Run(HeroMenu hero, int selectedLevel)
        {

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            //HERO
            choosenHero = new Archer(1, 1, 10, ConsoleColor.Cyan);
            
            if (hero is LadyKillerMenu)
            {
                choosenHero = new Shooter(1, 1, 10, ConsoleColor.Magenta);
            }

            //Load hero from file
            choosenHero.LoadHero(choosenHero.GetType().Name);

            
            while (true)
            {
                
                //Draw loaded hero on the console screen with default position row = 1, col = 1
                choosenHero.DrawObject();
                //Load hero collision
                choosenHero.LoadHeroCollision();

                Level level;
                switch (selectedLevel)
                {
                    case 1:
                        {
                            LevelFactory l = new EasyLevelCreator();
                            level = l.GenerateLevel();
                            break;
                        }
                    case 2:
                        {
                            LevelFactory l = new MediumLevelCreator();
                            level = l.GenerateLevel();
                            break;
                        }
                    case 3:
                        {
                            LevelFactory l = new HardLevelCreator();
                            level = l.GenerateLevel();
                            break;
                        }
                    default:
                        {
                            LevelFactory l = new EasyLevelCreator();
                            level = l.GenerateLevel();
                            break;
                        }
                }

                //Event Subscriber
                level.OnKill += levelOnKill;

                while (true)
                {
                    if (stopGame)
                    {
                        return;
                    }
                    PrintOnPosition(82, 5, "Hero Lifes: " + choosenHero.Lifes);
                    PrintOnPosition(82, 7, "Damage: " + choosenHero.Damage);
                    PrintOnPosition(82, 9, "Shoot range: " + choosenHero.Range);
                    PrintOnPosition(82, 11, "Score: " + choosenHero.Score);
                    //Hero move or shoot (keypressed)
                    choosenHero.Move();
                    //Check if some enemy is hitting us
                    choosenHero.CollisionWithEnemyCheck(level);
                    //Bonus checks
                    choosenHero.PotentialCollideWithBonus(level);
                    // Move all bullets and check for collision
                    Bullet.BulletsMovement(listOfBullets, choosenHero.Damage, level);
                    //Move enemies
                    foreach (var enemy in level.EnemiesList)
                    {
                        enemy.Move();
                    }

                    // Go to next level
                    if (level.EnemiesList.Count == 0)
                    {
                        break;
                    }

                    hidingBonusesValue++;

                    if (hidingBonusesValue == hidingBonusesMaxValue)
                    {
                        hidingBonusesValue = 0;
                        ToggleHidingBonuses(level);
                    }

                    if (choosenHero.Lifes <= 0)
                    {

                        Console.Clear();
                        GameOver.Display();
                        break;
                    }
                    //Slow down rendering speed
                    System.Threading.Thread.Sleep(100);
                }
                selectedLevel++;

                choosenHero.PosX = 1;
                choosenHero.PosY = 1;
                Console.Clear();
                // Game over
                if (selectedLevel > 3)
                {
                    break;
                }
            }
            GameOver.Display();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            
            stopGame = true;
            Console.Clear();
            StringBuilder sb = StartMenu.ReadComponents(goodByePath);
            StartMenu.DrawComponent(sb.ToString(), 10, 0, ConsoleColor.DarkGreen);
            Environment.Exit(0);
        }

        private static void ToggleHidingBonuses(Level level)
        {
            for (int i = 0; i < level.BonusesList.Count; i++)
            {
                if (level.BonusesList[i] is HidingBonus)
                {
                    if (!level.BonusesList[i].IsCollected)
                    {
                        if (((HidingBonus)level.BonusesList[i]).IsHidden)
                        {
                            ((HidingBonus)level.BonusesList[i]).IsHidden = false;
                            Console.SetCursorPosition(level.BonusesList[i].PosX, level.BonusesList[i].PosY);
                            level.BonusesList[i].DrawObject();
                        }
                        else
                        {
                            ((HidingBonus)level.BonusesList[i]).IsHidden = true;
                            Console.SetCursorPosition(level.BonusesList[i].PosX, level.BonusesList[i].PosY);
                            Console.Write(" ");
                        }
                    }
                }
            }
        }

        //Event
        private static void levelOnKill(object sender, KillEventArgs e)
        {
            choosenHero.Score += 100;
        }

        private static void PrintOnPosition(int x, int y, string message)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
        }



        
    }
}
