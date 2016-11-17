using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIsKing2
{
    class Program
    {
        static void Main(string[] args)
        {

            var result1 = shouldBeCreatedWithFirstAndLastName();

            if (result1)
            {
                Console.WriteLine("success");
            }
            else
            {
                Console.WriteLine("fail");
            }

            var result2 = shouldChangeLastName();

            if (result2)
            {
                Console.WriteLine("success");
            }
            else
            {
                Console.WriteLine("fail");

            }
        }

        private static bool shouldBeCreatedWithFirstAndLastName()
        {
            Person person = new Person("Erik", "Jansson");
            string expected = "Jansson, Erik";
            if (person.fullName == expected)
            {
                return true;
            }
            return false;
        }

        private static bool shouldChangeLastName()
        {
            Person person = new Person("Erik", "Jansson");
            string expected = "nyttNamn, Erik";

            person.changeLastName("nyttNamn");

            if (person.fullName == expected)
            {
                return true;
            }
            return false;
        }



    }
}
