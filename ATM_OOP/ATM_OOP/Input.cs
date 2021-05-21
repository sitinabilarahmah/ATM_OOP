using System;
using System.Collections.Generic;

namespace ATM_OOP
{
    public class Input : Balance, Deposit, WithDraw
    {
        int withdraw_amt = 0;
        int deposit_amt = 0;
        int amount = 0;
        private static Account inputAccount;
        private static IEnumerable<Account> acc;
        private static Account selectedAccount;
        private static List<Account> accountList;

        public void Main()
        {
            InputAccount();
            ATM.showMenu1();

            while(true)
            {
                switch (ATM.ValidateInputInt(Console.ReadLine()))
                {
                    case 1:
                        PINCheck();
                        
                        while(true)
                        {
                            ATM.showMenu2();
                            switch (ATM.ValidateInputInt(Console.ReadLine()))
                            {
                                case 1:
                                    CheckBalance(selectedAccount);
                                    break;
                                case 2:
                                    Withdraw(selectedAccount);
                                    break;
                                case 3:
                                    DepositAmt(selectedAccount);
                                    break;
                                case 4:
                                    Console.WriteLine("You have succesfull Logout");
                                    Main();
                                    break;
                                default:
                                    Console.WriteLine("Invalid Option");
                                    break;
                            }
                        }
                    case 2:
                        Console.WriteLine("Please collect your card");
                        Console.WriteLine("Thankyou for using ATM");
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }

        public void InputAccount()
        {
            accountList = new List<Account>
            {
                new Account() { Name = "Nabila", AccountNumber = 123456, CardNumber = 789, PIN = 9898, Balance = 10000000 },
                new Account() { Name = "Ladisa", AccountNumber = 123789, CardNumber = 456, PIN = 0011, Balance = 13000000 },
                new Account() { Name = "Aga", AccountNumber = 456789, CardNumber = 123, PIN = 3366, Balance = 9000000 }
            };
        }

        public void PINCheck ()
        {

            bool pass = false;
            while (!pass)
            {
                inputAccount = new Account();

                Console.WriteLine("Enter Card Number: ");
                inputAccount.CardNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter PIN Number: ");
                inputAccount.PIN = Convert.ToInt32(Console.ReadLine());

                System.Console.Write("\nChecking card number and PIN");
                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();

                foreach (Account account in accountList)
                {
                    if (inputAccount.CardNumber == account.CardNumber)
                    {
                        selectedAccount = account;
                        if (inputAccount.PIN == account.PIN)
                        {
                            pass = true;
                        }
                        else
                        {
                            pass = false;
                            ATM.PrintMessage("Invalid Card Number or PIN", false);
                        }
                    }
                }
            }
        }

        public void CheckBalance(Account account)
        {
            ATM.PrintMessage($"\n YOUR BALANCE IS :{ATM.FormatAmount(account.Balance)}", true);
            Console.WriteLine();
        }
        public void Withdraw(Account account)
        {
            Console.WriteLine(ATM.cur + "\n ENTER THE AMOUNT TO WITHDRAW: ");

            withdraw_amt = ATM.ValidateInputInt(Console.ReadLine());

            if (withdraw_amt % 100 != 0)
            {
                ATM.PrintMessage($"\n PLEASE ENTER THE AMOUNT IN MULTIPLES OF 100 {ATM.FormatAmount(withdraw_amt)}", false);
            }
            else if (withdraw_amt > (amount - 1))
            {
                ATM.PrintMessage($"\n INSUFFICENT BALANCE {ATM.FormatAmount(withdraw_amt)}", false);
            }
            else
            {
                amount = amount - withdraw_amt;
                ATM.PrintMessage($"\n\n PLEASE COLLECT CASH {ATM.FormatAmount(withdraw_amt)}", true);
            }
        }

        public void DepositAmt(Account account)
        {
            Console.WriteLine(ATM.cur + "\n ENTER THE AMOUNT TO WITHDRAW: ");

            deposit_amt = ATM.ValidateInputInt(Console.ReadLine());
            if (deposit_amt % 100 != 0)
            {
                ATM.PrintMessage($"\n PLEASE ENTER THE AMOUNT IN MULTIPLES OF 100 {ATM.FormatAmount(deposit_amt)}", false);
            }
            else
                amount = amount + deposit_amt;
            ATM.PrintMessage($"\n\n YOU HAVE SUCCESFULL DEPOSITED {ATM.FormatAmount(deposit_amt)}", true);
        }

    }
        
}
