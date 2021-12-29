using Banking_Application.Entites;
using System.Collections.Generic;
using System;
using System.Linq;
using BankingApplication.Data;

namespace Banking_Application.Repositories
{
    public class ListRepository : IOperation
    {
        string AccountNo = "", customerId = "";
        long amount = 0;
        int pin = 0,AccountPin=0;

        protected static List<Customer> CustomerList = new();

        public void ShowAllDetails()
        {
            foreach (var customer in CustomerList)
            {
                Console.WriteLine(customer.ToString()); 
                
                foreach (var account in customer.Account)
                {
                    Console.WriteLine(account.ToString()+"\n");
                }
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void DepositeMoney()
        {
            try
            {
                
                Console.Write("Enter CustomerId : ");
                customerId = Console.ReadLine();
                Console.Write("Enter AccountNo : ");
                AccountNo = Console.ReadLine().ToString();
                CustomerList.First(x => x.CustomerId.ToString().Equals(customerId)).Account.First(y => y.AccountNo.Equals(AccountNo));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid CustomerId or Account Number");
                return;
            }

            Console.Write("Enter Pin: ");
            try
            {
                pin = Convert.ToInt32(Console.ReadLine());
                AccountPin = CustomerList.First(x => x.CustomerId.ToString().Equals(customerId)).Account.First(y => y.AccountNo.Equals(AccountNo)).Pin;
                if (pin != AccountPin)
                {
                    Console.WriteLine("Invalid Pin");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Pin");
                return;
            }

            Console.Write("Enter amount to be Deposited: ");
            try
            {
                amount = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Please Enter valid Amount");
                return;
            }
            
            if (amount % 100 == 0)
            {
                var AccountDetails = CustomerList.First(x => x.CustomerId.ToString().Equals(customerId)).Account.First(y => y.AccountNo == AccountNo);
                
                if (DateTime.Now > AccountDetails.LastTransactionTime.AddHours(1))
                {
                    AccountDetails.WithdrawalLimitPerHour = ConstantValueData.WithdrawalLimitPerHour;
                    AccountDetails.TransactionPerHour = ConstantValueData.NumberOfTransactionPerHour;
                }
                
                if (AccountDetails.TransactionPerHour > 0)
                {
                    AccountDetails.TransactionHistory.Add(new TransactionHistory()
                    {
                        TransactionId = Guid.NewGuid(),
                        AccountNo = AccountNo,
                        Amount = amount,
                        TransactionType = "Credit",
                        TransactionTime = DateTime.Now
                    });
                    AccountDetails.Balance += amount;
                    AccountDetails.TransactionPerHour--;
                    AccountDetails.LastTransactionTime = DateTime.Now;
                    Console.WriteLine($"{amount} Successfully Credited To Account {AccountDetails.AccountNo}");
                    Console.WriteLine($"Current Balance: {AccountDetails.Balance}");
                }
                else
                {
                    Console.WriteLine("Max Transaction limit in a hour is 4");
                }
            }
            else
            {
                Console.WriteLine("Please enter the amount to withdraw in the multiples of 100");
            }
        }

        public void WithdrawMoney()
        {
            try
            {
                Console.Write("Enter CustomerId : ");
                customerId = Console.ReadLine().ToString();

                Console.Write("Enter AccountNo : ");
                AccountNo = Console.ReadLine().ToString();
                CustomerList.First(x => x.CustomerId.ToString().Equals(customerId)).Account.First(y => y.AccountNo.Equals(AccountNo) );
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid CustomerId or Account Number");
                return;
            }

            Console.Write("Enter Pin: ");
            try
            {
                pin = Convert.ToInt32(Console.ReadLine());
                AccountPin = CustomerList.First(x => x.CustomerId.ToString().Equals(customerId)).Account.First(y => y.AccountNo.Equals(AccountNo)).Pin;
                if (pin != AccountPin)
                {
                    Console.WriteLine("Invalid Pin");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Pin");
                return;
            }

            Console.Write("Enter amount to be Withdraw: ");
            try
            {
                amount = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Please Enter valid Amount");
                return;
            }
            var AccountDetails = CustomerList.First(x => x.CustomerId.ToString().Equals(customerId)).Account.First(y => y.AccountNo.Equals(AccountNo));
            
            
            if(amount <= AccountDetails.Balance)
            {
                if (amount % 100 == 0)
                {
                    if (amount <= 50000)
                    {
                        if (DateTime.Now > AccountDetails.LastTransactionTime.AddHours(1))
                        {
                            AccountDetails.WithdrawalLimitPerHour = ConstantValueData.WithdrawalLimitPerHour;
                            AccountDetails.TransactionPerHour = ConstantValueData.NumberOfTransactionPerHour;
                        }

                        if (AccountDetails.TransactionPerHour > 0)
                        {
                            if(AccountDetails.WithdrawalLimitPerHour > 0)
                            {
                                if (amount > ConstantValueData.WithdrawalLimit)
                                {
                                    Console.WriteLine($"\nExtra charge of {ConstantValueData.WithdrawalCharge} is Deducted");
                                    AccountDetails.Balance -= (amount + 30);
                                }
                                else
                                {
                                    AccountDetails.Balance -= amount;
                                }
                                AccountDetails.TransactionHistory.Add(new TransactionHistory()
                                {
                                    TransactionId = Guid.NewGuid(),
                                    AccountNo = AccountNo,
                                    Amount = amount,
                                    TransactionType = "Debit",
                                    TransactionTime = DateTime.Now
                                });
                                AccountDetails.WithdrawalLimitPerHour -= amount;
                                AccountDetails.TransactionPerHour--;
                                AccountDetails.LastTransactionTime = DateTime.Now;
                                Console.WriteLine($"{amount:#,#} Successfully Debited From Account {AccountDetails.AccountNo}");
                                Console.WriteLine($"Current Balance: {AccountDetails.Balance:#,#}");
                            }
                            else
                                Console.WriteLine("Max withdrawal limit in a hour is 200,000");
                        }
                        else
                            Console.WriteLine("Max Transaction limit in a hour is 4");
                    }
                    else
                        Console.WriteLine("Max withdrawal limit in a single transaction is 50,000");
                }
                else
                    Console.WriteLine("Please enter the amount to withdraw in the multiples of 100");
            }
            else
                Console.WriteLine("Your account does not have sufficient balance");
        }

        public void DisplayBalanceUingCustomerId(string CustomerId)
        {
            try
            {
                var AllAccountDetails = CustomerList.First(x => x.CustomerId.Equals(CustomerId)).Account;
                if (AllAccountDetails != null)
                {
                    foreach (var item in AllAccountDetails)
                        Console.WriteLine($"Account Number :{item.AccountNo}  Balance :{item.Balance:#,#}");

                }
                else
                    Console.WriteLine("NO Details Found!!");
            }
            catch (Exception)
            {
                
                Console.WriteLine("Invalid CustomerId, Please try again!");
            }
            
            
        }

        public void DisplayBalanceUsingAccountNo(string AccountNo)
        {
            try
            {
                var accountDetail = CustomerList.Select
                (x => x.Account.FirstOrDefault(y => y.AccountNo.Equals(AccountNo)));
                if (accountDetail != null)
                {
                    foreach (var item in accountDetail)
                    {
                        if (item != null)
                            Console.WriteLine($"Balance :{item.Balance:#,#}");
                    }
                }
                else
                    Console.WriteLine("NO Details Found!!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid Account Number, Please try again!");
            }
            
            
        }

        public void ShowAccountStatement(string AccountNo)
        {
            var accountDetail = CustomerList.Select
                (x => x.Account.FirstOrDefault(y => y.AccountNo.Equals(AccountNo)));
            if (accountDetail != null)
            {
                foreach (var account in accountDetail)
                {
                    if (account != null)
                    {
                        Console.WriteLine($"\nCurrent Balance : {account.Balance:#,#}");  
                        Console.WriteLine($"TransactionId                             Transaction Type\tTransaction Amount\tTransaction Time");
                        foreach (var item in account.TransactionHistory)
                        {                                                                                                             
                           // Console.WriteLine($"{item.TransactionId}\t  {item.TransactionType}\t                {item.Amount:#,#}                  \t{item.TransactionTime}");
                            if (item.TransactionType.Equals("Credit"))
                            {
                                Console.WriteLine($"{item.TransactionId}\t  {item.TransactionType}                {item.Amount:#,#}                  \t{item.TransactionTime}");
                            }else
                                Console.WriteLine($"{item.TransactionId}\t  {item.TransactionType}\t                {item.Amount:#,#}                  \t{item.TransactionTime}");
                        }
                    }
                    
                }
            }
            else
                Console.WriteLine("No Transaction History Found");
        }

    }
}
