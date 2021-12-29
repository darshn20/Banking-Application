using System;
using System.Collections.Generic;

namespace Banking_Application.Entites
{
    public class Account : Customer
    {
        public Account()
        {
            TransactionHistory = new List<TransactionHistory>();
        }
        public string AccountNo { get; set; }
        public int Pin { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }
        public double WithdrawalLimitPerHour { get; set; }
        public DateTime LastTransactionTime { get; set; }
        public int TransactionPerHour { get; set; }

        public  List<TransactionHistory>? TransactionHistory { get; set; }
        public override string ToString() => $"\tAccountNo: {AccountNo},\n\tAccountType: {AccountType},\n\tBalance: {Balance},\n\tAccountPin: {Pin}";
    }
}
