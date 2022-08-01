using BankApp.Core.Models;
using BankApp.Core.Utilities;
using BankApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.EntityImplementation.TRANSACTIONS
{
    /// <summary>
    /// Takes in Deposit Transaction Method
    /// </summary>

    #region Deposit
    public class Deposit : Central
    {
        //Takes the deposit operation
        public static void MyDeposit(CustomerModel customersModel)
        {
            Console.Clear();
            var AcctNumb = DisplayAccount.AccountGen(customersModel, ListOfAccount);
            string Message = "";

            foreach (var account in ListOfAccount)
            {
                if (account.MyAccount.AccountNumber == AcctNumb)
                {
                    if (customersModel != null)
                    {
                        Console.Write("Kindly Input a Deposit Amount: ");

                        decimal DepositAmount = ErrorHandling.AmountError(Convert.ToDecimal(Console.ReadLine()));

                        if (DepositAmount > 500000 && account.MyAccount.AccountType == "SAVINGS ACCOUNT")
                        {
                            Message = "Deposit Amount is above the accepted amount for your account. Kindly upgrade your account to deposit above #500,000";
                        }
                        else
                        {
                            account.CreditDeposit(DepositAmount);
                            account.AddTransactionData($"Your Account has been credited with a sum of #{DepositAmount}", Convert.ToDecimal(DepositAmount));
                            Message = $"Dear Customer, a Deposit transaction into your account was successful, you've been credited with a sum of #{DepositAmount}";
                        }
                    }
                }
            }
            ErrorHandling.SuccessMessage(Message);
            ErrorHandling.BackHome(customersModel);
        }
    }
    #endregion
}
