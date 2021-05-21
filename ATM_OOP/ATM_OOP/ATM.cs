using System;
using System.Globalization;
using System.Threading;

namespace ATM_OOP
{
    public class ATM
    {
        public static string cur = "Rp.";
        private static CultureInfo culture = new CultureInfo("id-ID");


        public static int ValidateInputInt(string input)
        {
            int myInt = 0;

            if (!String.IsNullOrWhiteSpace(input))
            {
                if (int.TryParse(input, out myInt))
                    return myInt;
                else
                    return -1;

            }
            else
                return -1;
        }
        public static void showMenu1()
        {
            Console.WriteLine("----------Welcome to ATM Service----------\n");
            Console.WriteLine("1. Insert card\n");
            Console.WriteLine("2. Exit\n");
            Console.WriteLine("Enter your choice: ");
        }
        public static void showMenu2()
        {
            Console.WriteLine("----------Welcome to ATM Service----------\n");
            Console.WriteLine("1. Check Balance\n");
            Console.WriteLine("2. Withdraw Cash\n");
            Console.WriteLine("3. Deposit Cash\n");
            Console.WriteLine("4. Quit\n");
            Console.WriteLine("-------------------------------------------\n\n");
            Console.WriteLine("Enter your choice: ");
        }

        public static string FormatAmount(int balance)
        {
            return String.Format(culture,"{0:C2}",balance);
        }
        public static void PrintMessage(string msg, bool success)
        {
            if (success)
                Console.ForegroundColor = ConsoleColor.Blue;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(msg);
            Console.ResetColor();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
