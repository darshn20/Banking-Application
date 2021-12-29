using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application.Entites
{
    public class TransactionHistory : Account
    {
        public Guid TransactionId { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionTime { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
    }
}
