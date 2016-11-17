using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CIK_Kata1
{
    public static class TestClass
    {
        public static bool AreEqual(string expected, string actual, string errorMessage)
        {
            StackTrace stackTrace = new StackTrace();
            string originatingMethod = stackTrace.GetFrame(1).GetMethod().Name;

            if (expected.Equals(actual))
            {
                printSuccessMessage(originatingMethod);
                return true;
            }
            printErrorMessage(errorMessage, originatingMethod);
            return false;
        }

        public static bool AreEqual(bool expected, bool actual, string errorMessage)
        {
            StackTrace stackTrace = new StackTrace();
            string originatingMethod = stackTrace.GetFrame(1).GetMethod().Name;

            if (expected.Equals(actual))
            {
                printSuccessMessage(originatingMethod);
                return true;
            }
            printErrorMessage(errorMessage, originatingMethod);
            return false;
        }

        public static bool AreEqual(int expected, int actual, string errorMessage)
        {
            StackTrace stackTrace = new StackTrace();
            string originatingMethod = stackTrace.GetFrame(1).GetMethod().Name;

            if (expected.Equals(actual))
            {
                printSuccessMessage(originatingMethod);
                return true;
            }
            printErrorMessage(errorMessage, originatingMethod);
            return false;
        }

        public static bool AreEqual(object expected, object actual, string errorMessage)
        {
            StackTrace stackTrace = new StackTrace();
            string originatingMethod = stackTrace.GetFrame(1).GetMethod().Name;

            if (expected.GetType() == actual.GetType())
            {
                printSuccessMessage(originatingMethod);
                return true;
            }
            printErrorMessage(errorMessage, originatingMethod);
            return false;
        }

        public static bool AreNotEqual(string expected, string actual, string errorMessage)
        {
            StackTrace stackTrace = new StackTrace();
            string originatingMethod = stackTrace.GetFrame(1).GetMethod().Name;

            if (!expected.Equals(actual))
            {
                printSuccessMessage(originatingMethod);
                return true;
            }
            printErrorMessage(errorMessage, originatingMethod);
            return false;
        }
        public static bool AreNotEqual(bool expected, bool actual, string errorMessage)
        {
            StackTrace stackTrace = new StackTrace();
            string originatingMethod = stackTrace.GetFrame(1).GetMethod().Name;

            if (!expected.Equals(actual))
            {
                printSuccessMessage(originatingMethod);
                return true;
            }
            printErrorMessage(errorMessage, originatingMethod);
            return false;
        }

        public static bool AreNotEqual(int expected, int actual, string errorMessage)
        {
            StackTrace stackTrace = new StackTrace();
            string originatingMethod = stackTrace.GetFrame(1).GetMethod().Name;

            if (!expected.Equals(actual))
            {
                printSuccessMessage(originatingMethod);
                return true;
            }
            printErrorMessage(errorMessage, originatingMethod);
            return false;
        }

        public static bool AreNotEqual(object expected, object actual, string errorMessage)
        {
            StackTrace stackTrace = new StackTrace();
            string originatingMethod = stackTrace.GetFrame(1).GetMethod().Name;

            if (expected.GetType() != actual.GetType())
            {
                printSuccessMessage(originatingMethod);
                return true;
            }
            printErrorMessage(errorMessage, originatingMethod);
            return false;
        }

        public static bool AreTrue(bool boolToCheck, string errorMessage)
        {
            StackTrace stackTrace = new StackTrace();
            string originatingMethod = stackTrace.GetFrame(1).GetMethod().Name;

            if (boolToCheck == true)
            {
                printSuccessMessage(originatingMethod);
                return true;
            }
            printErrorMessage(errorMessage, originatingMethod);
            return false;
        }

        public static bool AreFalse(bool boolToCheck, string errorMessage)
        {
            StackTrace stackTrace = new StackTrace();
            string originatingMethod = stackTrace.GetFrame(1).GetMethod().Name;

            if (boolToCheck != true)
            {
                printSuccessMessage(originatingMethod);
                return true;
            }
            printErrorMessage(errorMessage, originatingMethod);
            return false;
        }

        private static void printErrorMessage(string errorMessage, string errorCausingMethod)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage + " in method " + errorCausingMethod);
            Console.ResetColor();
        }

        private static void printSuccessMessage(string passedMethod)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(passedMethod + " passed");
            Console.ResetColor();
        }

    }
}
