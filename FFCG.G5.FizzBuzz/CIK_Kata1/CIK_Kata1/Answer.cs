using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK_Kata1
{
    public abstract class AnswerFactory
    {
        public Answer currentAnswer;
        public abstract Answer getAnswer(int insertedNumber);
    }

    public class ConcreteAnswerFactory : AnswerFactory
    {
        public override Answer getAnswer(int insertedNumber)
        {

            if ((isMultipleOfThree(insertedNumber) && isMultipleOfFive(insertedNumber)) ||
                ((isMultipleOfThree(insertedNumber) || containsThree(insertedNumber)) && containsFive(insertedNumber)))
            {
                currentAnswer = new FizzBuzz();
            }
            else if (isMultipleOfThree(insertedNumber) || containsThree(insertedNumber))
            {
                currentAnswer = new Fizz();
            }
            else if (isMultipleOfFive(insertedNumber) || containsFive(insertedNumber))
            {
                currentAnswer = new Buzz();
            }
            else
            {
                currentAnswer = new Number(insertedNumber);
            }
            return currentAnswer;
        }
        private Boolean isMultipleOfThree(int numberToCheck)
        {
            return numberToCheck % 3 == 0;
        }

        private Boolean isMultipleOfFive(int numberToCheck)
        {
            return numberToCheck % 5 == 0;
        }

        private Boolean containsThree(int numberToCheck)
        {
            return numberToCheck.ToString().Contains(3.ToString());
        }

        private Boolean containsFive(int numberToCheck)
        {
            return numberToCheck.ToString().Contains(5.ToString());
        }
    }


    public abstract class Answer
    {
        protected string answer;

        public void speak()
        {
            Console.WriteLine(answer);
        }
    }

    public class Fizz : Answer
    {
        public Fizz()
        {
            answer = "Fizz";
        }
    }

    public class Buzz : Answer
    {
        public Buzz()
        {
            answer = "Buzz";
        }

    }

    public class Number : Answer
    {
        public Number(int insertedNumber)
        {
            answer = insertedNumber.ToString();
        }

    }

    public class FizzBuzz : Answer
    {
        public FizzBuzz()
        {
            answer = "FizzBuzz";
        }
    }
}
