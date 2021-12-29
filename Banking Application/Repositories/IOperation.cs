using System;

namespace Banking_Application.Repositories
{
    public interface IOperation 
    {
        void DepositeMoney();
        void WithdrawMoney();
        void DisplayBalanceUingCustomerId(string CustomerId);
        void DisplayBalanceUsingAccountNo(string AccountNo);
        void ShowAccountStatement(string AccountNo);
    }
}
