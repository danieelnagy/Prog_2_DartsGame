using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace ConsoleApp1
{
    class Game
    {
        private List<Players> Players_List = new List<Players>();
        StreamWriter sw = new StreamWriter(@"turns.txt");
        private int attempt;
        private int chanceOne;
        private int chanceTwo;
        private int chanceThree;
        private bool b = false;
        private int turn = 0;
        private int amountOfPlayers;
        public void Add_Players(string name) //Lägger till spelare
        {
            Players newPlayer = new Players(name);
            Players_List.Add(newPlayer);
        }
        public void PlayGame()
        {
            Console.WriteLine("Welcome to the Darts game!");
            Console.WriteLine("You can write here how many player gonna play with this game! Use only whole numbers!!!!");
            amountOfPlayers = int.Parse(Console.ReadLine()); // Spelare limit
            for (int i = 0; i < amountOfPlayers; i++)
            {
                Console.WriteLine("Please input the name of the player! Use only letters!!!");
                string player = Console.ReadLine();
                Add_Players(player);  //skickar string värden till metoden.
                Console.WriteLine("");
            }
            Console.WriteLine("The console clears now, get ready for the game!");
            Thread.Sleep(2000);
            Console.Clear();
            while (b == false)
            {
                turn++;
                foreach (var rounds in Players_List)
                {
                    int sum;
                    Console.WriteLine("=================================");
                    Console.WriteLine("\nGame Rules:\nYou can throw between 1 - 20, in one round u have 3 chances\nIf u want to score a randomly press: 21\nWinner needs to throw exatly 301 point, if u get too high points your last round will be removed\nIf u want to throw 0 point press 0\n");
                    Console.WriteLine("\n=================================");
                    Console.WriteLine("\n{0} is aimin now! Total points just now: {1}", rounds, rounds.CalcPoints()); //Spelaren vet hela tiden hur mycket poäng har hen.
                    Console.WriteLine("\nFirst arrow in this round!");
                    attempt = int.Parse(Console.ReadLine());
                    chanceOne = rounds.ThrowCalc(attempt); // anropar metoden + skickar värdet.
                    Console.WriteLine("\nScored: {0}", chanceOne);
                    Console.WriteLine("\nSecond Try!");
                    attempt = int.Parse(Console.ReadLine());
                    chanceTwo = rounds.ThrowCalc(attempt);
                    Console.WriteLine("\nScored: {0}", chanceTwo);
                    Console.WriteLine("\nLast chance in this round!");
                    attempt = int.Parse(Console.ReadLine());
                    chanceThree = rounds.ThrowCalc(attempt);
                    Console.WriteLine("\nScored: {0}", chanceThree);
                    sum = chanceOne + chanceTwo + chanceThree;
                    if (rounds.CalcPoints() < 301)
                    {
                        rounds.Add_Turns(chanceOne, chanceTwo, chanceThree);
                        Console.WriteLine("\n=================================");
                        rounds.OneRound();
                        Console.WriteLine("=================================");
                        Console.WriteLine("\nScore in this round: {0}\n", sum); //Round poäng
                        Console.WriteLine("=================================");
                        Console.WriteLine("\nTotal score: {0}\n", rounds.CalcPoints()); //Total poäng
                        Console.WriteLine("=================================");
                        Console.WriteLine("\nIf you ready press any key to continue.\n");
                        Console.ReadKey();
                    }
                    if (rounds.CalcPoints() > 301) // om spelaren har för mycket poäng, sista rounden tas bort.
                    {
                        Console.WriteLine("You got too high points, your latest round will be removed and you can try again!");
                        rounds.RemoveTurns();
                        Console.WriteLine("You have this much point right now: {0}\n", rounds.CalcPoints());
                    }
                    if (rounds.CalcPoints() == 301)
                    {
                        Console.WriteLine("\n************************************************\n");
                        Console.WriteLine("The winner is {0}!!", rounds); // Skriver ut vinnaren
                        Console.WriteLine("Loading stats...");
                        Console.WriteLine("\n************************************************");
                        Thread.Sleep(6500);
                        b = true;
                        Console.Clear();
                        break; // Jag fattade inte värför, men loopen blev sant och därför borde ha stoppat, men utan break det körs bara vidare tills de andra spelar färdigt.
                    }
                    if (turn == 3) //Consolen kan vara trångt efter 5 round, så den bara rensar
                    {
                        Console.WriteLine("\nJust gonna clear the console now, i give you some time to look back your stats.\n");
                        Thread.Sleep(4000);
                        Console.Clear();
                        turn = 0;
                    }
                }
            }
            Console.WriteLine("Every stat:\n");
            foreach (var k in Players_List) // loopar genom hela listan och skriver ut allt.
            {
                sw.WriteLine(k.Name + " Total score: {0}\n", k.CalcPoints());
                sw.Close();
                k.OneRound();
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
