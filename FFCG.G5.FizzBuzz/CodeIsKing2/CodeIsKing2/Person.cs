using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIsKing2
{
    public class Person
    {
        /*  public string firstName { get; set; }
          public string lastName { get; set; }
          */

        private string _firstName;
        private string _lastName;

        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string fullName
        {
            get
            {
                return _lastName + ", " + _firstName;

            }

        }

        public void changeLastName(string lastName)
        {
            if (!string.IsNullOrEmpty(lastName))
                _lastName = lastName;
        }


    }
}
