namespace ConsoleApp1
{
    class Turns
    {
        private int roundOne;
        private int roundTwo;
        private int roundThree;
        public Turns(int _roundOne, int _roundTwo, int _roundThree) //cotr 
        {
            roundOne = _roundOne;
            roundTwo = _roundTwo;
            roundThree = _roundThree;

        }
        public int GetScore() //Räknare
        {
            int score = roundOne + roundTwo + roundThree;
            return score;
        }
        public override string ToString()
        {
            return string.Format("\nFirst arrow score: {0} \nSecond Arrow score: {1} \nThird Arrow score: {2}\n", roundOne, roundTwo, roundThree);
        }
    }
}
