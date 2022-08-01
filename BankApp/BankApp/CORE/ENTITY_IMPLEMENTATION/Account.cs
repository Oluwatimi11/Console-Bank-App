using BankApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.EntityImplementation
{
    public class Account
    {

        //Creates a new account and puts the account in a readonly list
        public readonly AccountModel MyAccount = new AccountModel();

        public Account(string AccountType, string UserID, string emailAddress)
        {
            MyAccount.EmailAddress = emailAddress;
            MyAccount.AccountNumber = GenAccountNumber(8);
            MyAccount.AccountType = AccountType == "1" ? "SAVINGS ACCOUNT" : AccountType == "2" ? "CURRENT ACCOUNT" : "null";
            MyAccount.CustomerId = UserID;
            MyAccount.TransactionList = new List<TransactionModel>();
        }

        /// <summary>
        ///deposit method used  in the deposit operation
        /// </summary>
        /// <returns></returns>
        #region Credit Deposit
        public decimal CreditDeposit(decimal Amount)
        {
            //decimal newAmount = MyAccount.AcctBalance + Amount;
            //return newAmount;
            return MyAccount.AcctBalance += Amount;
        }
        #endregion

        /// <summary>
        /// withdrawal method used  in the withdrawal operation 
        /// </summary>
        /// <returns></returns>
        #region Debit Withdrawal


        public bool DebitWithdrawal(string AccountType, decimal Amount)
        {
            decimal minAmount = MyAccount.AccountType == "Savings Account" ? 1000 : 0;
            if(Amount <= MyAccount.AcctBalance - minAmount)
            {
                MyAccount.AcctBalance -= Amount;
            }
            else if (Amount > MyAccount.AcctBalance - minAmount)
            {
                return false;
            }
            return true;
        }

        #endregion

        /// <summary>
        /// Account balance print method used  in the print operation
        /// </summary>
        /// <returns></returns>
        #region Account Balance
        public decimal myAcctBalance()
        {
            return MyAccount.AcctBalance;
        }
        #endregion

        /// <summary>
        /// Account Number Generator
        /// </summary>
        /// <returns></returns>
        #region Generate Account Number
        private static string GenAccountNumber (int Length)
        {
            Random random = new Random();
            string str = string.Empty;

            for(int i = 0; i < Length; i++)
            {
                str = String.Concat(str, random.Next(Length).ToString());
            }
            return "021" + str;
        }
        #endregion


        /// <summary>
        /// Transaction Data store method used  in the storing each oparation data
        /// </summary>
        /// <returns></returns>
        #region Transaction Data
        public bool AddTransactionData(string Description, decimal Amount)
        {
            var transactionModel = new TransactionModel()
            {
            AccountNumber = MyAccount.AccountNumber,
            Balance = MyAccount.AcctBalance,
            Description = Description,
            Amount = Amount,
            Date = DateTime.Now,
            };
            if (transactionModel != null)
            {
                MyAccount.TransactionList.Add(transactionModel);
                return true;
            }
            return false;
        }
        #endregion

    }
}
