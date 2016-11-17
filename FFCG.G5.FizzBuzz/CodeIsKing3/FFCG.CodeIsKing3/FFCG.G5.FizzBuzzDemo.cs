using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFCG.G5.FizzBuzzDemo
{
    public class FizzBuzzDemo
    {
        /*
        public List<string> GetSerieOf100Rounds()
        {
            var resultList = new List<string>();
            for (int numberToCheck = 1; numberToCheck <= 100; numberToCheck++)
            {
                if ((isDevisibleBy3(numberToCheck) || contains3(numberToCheck)) && (isDevisibleBy5(numberToCheck) || contains5(numberToCheck)))
                {
                    resultList.Add("FizzBuzz");
                }
                else if (isDevisibleBy3(numberToCheck) || contains3(numberToCheck))
                {
                    resultList.Add("Fizz");
                }
                else if (isDevisibleBy5(numberToCheck) || contains5(numberToCheck))
                {
                    resultList.Add("Buzz");
                }
                else
                {
                    resultList.Add(numberToCheck.ToString());
                }
            }
            return resultList;
        }
        */

        public List<string> GetSerieOf100RoundsVersion2()
        {
            var resultList = new List<string>();
            for (int numberToCheck = 1; numberToCheck <= 100; numberToCheck++)
            {
                resultList.Add((isDevisibleBy3(numberToCheck) || contains3(numberToCheck)) && (isDevisibleBy5(numberToCheck) || contains5(numberToCheck)) ? "FizzBuzz"
                    : isDevisibleBy3(numberToCheck) || contains3(numberToCheck) ? "Fizz"
                    : isDevisibleBy5(numberToCheck) || contains5(numberToCheck) ? "Buzz"
                    : numberToCheck.ToString());
            }
            return resultList;
        }

        private bool isDevisibleBy3(int numberToCheck)
        {
            return numberToCheck % 3 == 0;
        }

        private bool isDevisibleBy5(int numberToCheck)
        {
            return numberToCheck % 5 == 0;
        }

        private bool contains3(int numberToCheck)
        {
            return numberToCheck.ToString().Contains("3");
        }

        private bool contains5(int numberToCheck)
        {
            return numberToCheck.ToString().Contains("5");
        }
    }
}
