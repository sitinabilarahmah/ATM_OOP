using System;
namespace ATM_OOP
{
    public class Account
    {
        public string Name { get; set; }
        public int AccountNumber { get; set; }
        public int CardNumber { get; set; }
        public int PIN { get; set; }
        public int Balance { get; set; }

        public Account()
        {
        }

        public Account(string name, int accountNumber, int cardNumber, int pin, int balance)
        {
            Name = name;
            AccountNumber = accountNumber;
            CardNumber = cardNumber;
            PIN = pin;
            Balance = balance;
        }

    }
}
