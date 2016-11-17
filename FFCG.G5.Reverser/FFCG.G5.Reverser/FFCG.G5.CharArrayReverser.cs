using System;
using System.Collections.Generic;

namespace FFCG.G5.Reverser
{
    internal class CharArrayReverser
    {
        internal string Reverse(char[] wordCharArray)
        {
            var upperLetters = GetPositionsOfUppercaseCharsInArray(wordCharArray);
            Array.Reverse(wordCharArray);
            SetArrayOfCharsToLowercase(wordCharArray);
            SetUppercaseLetters(wordCharArray, upperLetters);
            return new string(wordCharArray);
        }

        private List<int> GetPositionsOfUppercaseCharsInArray(char[] charArrayToCheck)
        {

            var upperLetters = new List<int>();

            for (var x = 0; x <= charArrayToCheck.Length - 1; x++)
            {
                if (char.IsUpper(charArrayToCheck[x]))
                    upperLetters.Add(x);
                charArrayToCheck[x] = char.ToLower(charArrayToCheck[x]);
            }
            return upperLetters;
        }

        private void SetArrayOfCharsToLowercase(char[] charArrayToChange)
        {
            for (var x = 0; x <= charArrayToChange.Length - 1; x++)
                charArrayToChange[x] = char.ToLower(charArrayToChange[x]);
        }

        private void SetUppercaseLetters(char[] lowercaseArray, List<int> uppercasePlaces)
        {
            foreach (var positionOfUppercase in uppercasePlaces)
                lowercaseArray[positionOfUppercase] = char.ToUpper(lowercaseArray[positionOfUppercase]);
        }
    }
}