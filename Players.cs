using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Players
    {
        private List<Turns> Turns_List = new List<Turns>();
        public Players(string _name)
        {
            Name = _name;
        }
        public string Name { get; set; }
        public int ThrowCalc(int attempt) //tar emot en int värde från Game, skickar vidare till Darts
        {
            Darts calc = new Darts(attempt);
            int result = calc.GetAim();
            return result;
        }
        public void Add_Turns(int turnOne, int turnTwo, int turnThree) //Skickar var med värde till listan
        {
            Turns_List.Add(new Turns(turnOne, turnTwo, turnThree));
        }
        public void RemoveTurns() //Om totalpoints för hög tar ju bort sista rounden
        {
            Turns_List.RemoveAt(Turns_List.Count - 1);
        }
        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
        public void OneRound() //Itererar genom listan och skriver ut info
        {
            int i = 1;
            foreach (var y in Turns_List)
            {
                Console.WriteLine("\nTurn {0} score: {1}", i, y);
                i++;
            }
        }
        public int CalcPoints() //Total points räknare
        {
            int sum = 0;
            foreach (var rounds in Turns_List)
            {
                sum = sum + rounds.GetScore();
            }
            return sum;
        }
    }
}
