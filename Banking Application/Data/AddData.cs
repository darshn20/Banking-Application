using Banking_Application.Repositories;
using System;
using System.Collections.Generic;
using Banking_Application.Entites;

namespace BankingApplication.Repositories
{
    public  class AddData : ListRepository
    {
        public  void InitializeAlldata()
        {
            _ =  new Random();
            CustomerList.Add(new Customer()
            {
                CustomerId = Guid.NewGuid().ToString(),
                CustomerName = "Darshan Bhuva",
                PhoneNumber = 9876543210,
                Email = "darshan@gmail.com",
                Account = new List<Account>()
                {
                    new Account()
                    {
                        AccountNo = Guid.NewGuid().ToString().ToString(),
                        AccountType = "Saving",
                        Balance = 100000,
                        Pin = 7412,
                        WithdrawalLimitPerHour = 200000,
                        LastTransactionTime = DateTime.Now,
                        TransactionPerHour = 4,
                    },

                    new Account()
                    {
                        AccountNo = Guid.NewGuid().ToString(),
                        AccountType = "Current",
                        Balance = 564000,
                        Pin = 7834,
                        WithdrawalLimitPerHour = 200000,
                        LastTransactionTime = DateTime.Now,
                        TransactionPerHour = 4,
                    }

                }
            });

            CustomerList.Add(new Customer()
            {
                CustomerId = Guid.NewGuid().ToString(),
                CustomerName = "kandarp Patel",
                PhoneNumber = 6541320789,
                Email = "kandarp@gmail.com",
                Account = new List<Account>()
                {
                    new Account()
                    {
                        AccountNo = Guid.NewGuid().ToString(),
                        AccountType =  "Current",
                        Balance = 480000,
                        Pin = 1734,
                        WithdrawalLimitPerHour = 200000,
                        LastTransactionTime = DateTime.Now,
                        TransactionPerHour = 4,
                    },
                    new Account()
                    {
                        AccountNo = Guid.NewGuid().ToString(),
                        AccountType =  "Saving",
                        Balance = 90000,
                        Pin = 8520,
                        WithdrawalLimitPerHour = 200000,
                        LastTransactionTime = DateTime.Now,
                        TransactionPerHour = 4,
                    }
                }
            });

            CustomerList.Add(new Customer()
            {
                CustomerId = Guid.NewGuid().ToString(),
                CustomerName = "Paras Savaliya",
                PhoneNumber = 7896541230,
                Email = "paras@gmail.com",
                Account = new List<Account>()
                {
                    new Account()
                    {
                        AccountNo = Guid.NewGuid().ToString(),
                        AccountType =  "Current",
                        Balance = 170000,
                        Pin = 1234,
                        WithdrawalLimitPerHour = 200000,
                        LastTransactionTime = DateTime.Now,
                        TransactionPerHour = 4,
                    }
                }
            }); ;

            CustomerList.Add(new Customer()
            {
                CustomerId = Guid.NewGuid().ToString(),
                CustomerName = "Maitri Maniya",
                PhoneNumber = 7418529630,
                Email = "maitri@gmail.com",
                Account = new List<Account>()
                {
                    new Account()
                    {
                        AccountNo = Guid.NewGuid().ToString(),
                        AccountType =  "Saving",
                        Balance = 40000,
                        Pin = 4567,
                        WithdrawalLimitPerHour = 200000,
                        LastTransactionTime = DateTime.Now,
                        TransactionPerHour = 4,
                    }
                }
            });
        }
    }
}
