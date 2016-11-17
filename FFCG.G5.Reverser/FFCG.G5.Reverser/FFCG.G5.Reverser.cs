namespace FFCG.G5.Reverser
{
    public class Reverser
    {
        private readonly StringArrayReverser _stringArrayReverser;

        public Reverser()
        {
            //var charArrayReverser = new CharArrayReverser();
            _stringArrayReverser = new StringArrayReverser();
            // _stringArrayReverser = new StringArrayReverser(charArrayReverser);
        }

        public string Reverse(string stringToReverse)
        {
            return _stringArrayReverser.Reverse(stringToReverse.Split(null));
        }
    }
}