using System.Linq;
using System.Text;

namespace FFCG.G5.Reverser
{
    internal class StringArrayReverser
    {
        // private readonly CharArrayReverser _charArrayReverser;

        /* public StringArrayReverser(CharArrayReverser charArrayReverser)
         {
             //_charArrayReverser = charArrayReverser;
         }*/

        internal string Reverse(string[] arrayOfSplitString)
        {
            // var reversedString = string.Empty;

            /*for (var i = 0; i < arrayOfSplitString.Length; i++)
            {
                var wordCharArray = arrayOfSplitString[i].ToCharArray();
                reversedString = reversedString + _charArrayReverser.Reverse(wordCharArray);

                if (arrayOfSplitString.Length > i + 1)
                    reversedString = reversedString + " ";
            }*/
            var result = new StringBuilder();

            foreach (var word in arrayOfSplitString)
            {
                var reversedWord = word.ToLower().Reverse().ToArray();
                var indexOfUppercaseChars = word.Where(char.IsUpper).Select(x => word.IndexOf(x)).ToList();
                indexOfUppercaseChars.ForEach(x => reversedWord[x] = char.ToUpper(reversedWord[x]));
                result.Append($"{string.Join(string.Empty, reversedWord)} ");
            }

            return result.ToString().TrimEnd();
        }
    }
}