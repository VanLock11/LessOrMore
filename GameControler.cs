using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace LessOrMore
{
    public class GameControler
    {
        private int uNumber;
        private int bonus;
        private int over;
        private int rdNumber;
        private Random rd = new Random();

        //Constructor
        public GameControler()
        {
            Console.CursorVisible = false;
        }

        //The beginning of the game stage , rules of the game
        public void Menu()
        {
            Continue:

            Console.Clear();
            Console.CursorTop = (Console.WindowHeight - 11) / 2;
            Console.WriteLine("\t Hi " + Environment.UserName.ToString() + "!");
            Console.CursorTop = (Console.WindowHeight - 9) / 2;
            Console.WriteLine("\n\t You need to choose more or less. \n \t Do this with the up and down buttons.\n\n\t Up-more \n\t Down-less \n\n\t To start the game, click Enter. \n\t To exit , click Esc.");
            switch (Console.ReadKey().Key)
            {

                case ConsoleKey.Enter:
                    over = 0;
                    bonus = 0;
                    StartGame();
                    break;

                case ConsoleKey.Escape:
                    break;

                default:
                    goto Continue;
            }
        }

        //Game stage . Bonuses and losses calculation
        public void StartGame()
        {
            while (true)
            {
                uNumber = rd.Next(1, 9);
                do
                {
                    rdNumber = rd.Next(0, 11);
                } while (uNumber == rdNumber);

                Continue:

                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth - 18) / 2, (Console.WindowHeight / 2) - 4);
                Console.WriteLine("X - less or more ?");
                Console.WriteLine();
                Console.CursorLeft = (Console.WindowWidth - 9) / 2;
                Console.WriteLine(uNumber + "\tX");

                switch (Console.ReadKey().Key)
                {


                    case ConsoleKey.UpArrow:
                        if (uNumber < rdNumber)
                        { bonus += rdNumber - uNumber; }
                        else
                        {
                            over++;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (uNumber > rdNumber)
                        { bonus += uNumber - rdNumber; }
                        else
                        {
                            over++;
                        }
                        break;
                    default:
                        goto Continue;

                }

                Console.SetCursorPosition((Console.WindowWidth - 9) / 2, (Console.WindowHeight / 2) - 2);
                Console.WriteLine(uNumber + "\t" + rdNumber);
                Thread.Sleep(800);
                if (over == 3)
                {
                    GameOver();
                    break;
                }
            }

        }

        //End of the game phase
        public void GameOver()
        {
            Continue:

            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - 9) / 2, Console.WindowHeight / 2);
            Console.WriteLine("Game Over!");
            Console.CursorLeft = (Console.WindowWidth / 2) - 10;
            Console.WriteLine("You collected " + bonus + " points!");
            Console.WriteLine();
            Console.CursorLeft = (Console.WindowWidth / 2) - 20;
            Console.WriteLine("To play again press Enter , to exit press Esc");

            switch (Console.ReadKey().Key)
            {

                case ConsoleKey.Enter:
                    bonus = 0;
                    over = 0;
                    StartGame();
                    break;

                case ConsoleKey.Escape:
                    break;

                default:
                    goto Continue;
            }
        }


    }
}
