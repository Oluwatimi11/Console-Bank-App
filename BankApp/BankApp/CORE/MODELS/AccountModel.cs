using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Models
{
    public class AccountModel
    {
        //Takes all Model/Properties of the noun-Account
        public string AccountNumber { get; set; } = null!;
        public string AccountName { get; set; } = null!;
        public string AccountType { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public decimal AcctBalance { get; set; }
        public List<TransactionModel> TransactionList { get; set; } = new List<TransactionModel>();
    }
}
