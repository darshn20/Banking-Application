using Banking_Application.Repositories;
using BankingApplication.Repositories;
using System;
namespace Banking_Application
{
    public class Bank
    {
        static void Main(string[] args)
        {
            var AddData = new AddData();
            var repo = new ListRepository();
            AddData.InitializeAlldata();
            repo.ShowAllDetails();
             
            ConsoleKeyInfo Operation;
            Console.WriteLine();
            Console.WriteLine("Welcome To Baanking  Application");
            do
            {
                Console.WriteLine("\nEnter  1  to  Credit/debit Money");
                Console.WriteLine("Enter  2  to  Display balance of Account");
                Console.WriteLine("Enter  3  to  Display balance for all the accounts");
                Console.WriteLine("Enter  4  to  Display account statement of Account");
                Console.WriteLine("Press the Escape (Esc) key to quit:");

                Operation = Console.ReadKey();
                Console.WriteLine();
                switch (Operation.KeyChar)
                {
                    case '1':
                        ConsoleKeyInfo TransactionOperation;
                        Console.WriteLine("\nCredit/debit Money");
                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine("Type 1 to Withdraw Money");
                            Console.WriteLine("Type 2 to Deposite Money");
                            Console.WriteLine("Press F1 to go back");
                            
                            TransactionOperation = Console.ReadKey();
                            Console.WriteLine();
                            switch (TransactionOperation.KeyChar)
                            {
                                case '1':
                                    repo.WithdrawMoney();
                                    break;

                                case '2':
                                    repo.DepositeMoney();
                                    break;

                                default:
                                    Console.WriteLine("Choose valid Option \n");
                                    break;
                            }
                        }
                        while (TransactionOperation.Key != ConsoleKey.F1);
                        Console.WriteLine();
                        break;

                    case '2':
                        Console.Write("\nEnter Account Number: ");
                        var AccountNumber = Console.ReadLine().ToString();
                        repo.DisplayBalanceUsingAccountNo(AccountNumber);
                        break;

                    case '3':
                        Console.Write("\nEnter Your CustomerId: ");
                        string CustomerId = Console.ReadLine().ToString();
                        repo.DisplayBalanceUingCustomerId(CustomerId);
                        break;

                    case '4':
                        Console.Write("\nEnter Account Number: ");
                        var AccountNo = Console.ReadLine().ToString();
                        repo.ShowAccountStatement(AccountNo);
                        break;

                    default:
                        Console.WriteLine("Wrong Choice please select again \n");
                        break;
                }

            }
            while (Operation.Key != ConsoleKey.Escape);

            Console.WriteLine("\nThank You!!! Visit Again");

        }
    }
}
