using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking_Application.Entites
{
    public class Customer 
    {
        public string  CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Account> Account { get; set; }
        public override string ToString() => $"CustomerId: {CustomerId},\nCustomerName: {CustomerName},\nPhoneNumber: {PhoneNumber},\nEmail: {Email},\n\nAccount Details:\n";
    }  

}
