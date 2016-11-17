namespace FFCG.G5.DiceGame
{
    public class Dice
    {
        // private readonly int _maxValue;
        private readonly IRandom _randomizer;

        //private readonly Random _rnd;

        public Dice(IRandom randomizer)
        {
            _randomizer = randomizer;
            //_rnd = new Random();
            //_maxValue = 6; //Default value
        }


        internal int NewDiceValue { get; set; }
        internal int OldDiceValue { get; set; }


        public int RollDice()
        {
            OldDiceValue = NewDiceValue;
            return NewDiceValue = _randomizer.GetRandomNumber();
        }

        /* public int RollDice(int newValue) //Cheat method
         {
             OldDiceValue = NewDiceValue;
             return NewDiceValue = newValue;
         }*/
    }
}