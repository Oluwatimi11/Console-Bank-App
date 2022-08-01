using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Models
{
    public class TransactionModel
    {
        //Takes all Model/Properties of the noun-Transaction
        public string AccountNumber { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

    }
}
