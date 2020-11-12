using System;

namespace ConsoleApp1
{
    class Darts
    {
        private int[] theArray = { 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5 }; 
        private Random rnd = new Random();
        private int accuracy;
        public Darts(int _accuracy) // gets attempts värde, jag hade kunnat ta bort hela cotr, och ge parameter till GetAim och den skulle kunna ta emot  en värde
        {
            accuracy = _accuracy; // Game(attempt)-->Players.ThrowCalc(attempt) = Darts accuracy
        }
        public int GetAim() //Jag vet att hela metoden är jätte hårdkodad, förklarning finns i Novo.
        {
            int x;
            int score = 0;
            int aim = rnd.Next(100);
            for (int i = 0; i < theArray.Length; i++) // baserad på aim justerar jag index värden
            {
                x = theArray[i];
                if (accuracy == x && aim <= 60 && aim >= 0)
                {
                    score = x;
                }
                else if (accuracy == x && aim <= 75 && aim > 60)
                {
                    if (accuracy == 20)
                    {
                        x = theArray[i + 2];
                        score = x;
                    }
                    else
                    {
                        x = theArray[i - 1];
                        score = x;
                    }
                }
                else if (accuracy == x && aim <= 90 && aim > 75)
                {
                    if (accuracy == 5)
                    {
                        x = theArray[i - 2];
                        score = x;
                    }
                    else
                    {
                        x = theArray[i + 1];
                        score = x;
                    }
                }
                else if (accuracy == x && aim <= 95 && aim > 90)
                {
                    score = rnd.Next(20);
                }
                else if (accuracy == x && aim <= 100 && aim > 95)
                {
                    score = 0;
                }
                else
                {
                    if (accuracy == 21)
                    {
                        score = rnd.Next(20);
                    }
                    else if (accuracy == 0)
                    {
                        score = 0;
                    }
                    else if (accuracy == aim)
                    {
                        Console.WriteLine("Critical hit!!!!");
                        score = accuracy;
                    }
                }
            }
            return score;
        }
    }
}
