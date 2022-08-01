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
    /// Takes in Withdrawal Transaction Method
    /// </summary>

    #region Withdraw
    public class Withdraw : Central
    {

        //Takes the transfer operation
        public static void MyWithdraw(CustomerModel customersModel)
        {
            Console.Clear();
            var AccountNumb = DisplayAccount.AccountGen(customersModel, ListOfAccount);
            string WithMessage = "";

            foreach (var account in ListOfAccount)
            {
                if (account.MyAccount.AccountNumber == AccountNumb)
                {
                    if (customersModel != null)
                    {
                        Console.WriteLine("Kindly Input a Withdrawal Amount.");

                        decimal WithdrawalAmount = ErrorHandling.AmountError(Convert.ToDecimal(Console.ReadLine()));
                        var WithdrawOp = account.DebitWithdrawal(account.MyAccount.AccountType, WithdrawalAmount);
                        if (WithdrawOp == true)
                        {
                            account.AddTransactionData($"Your Account has been debited with a sum of #{WithdrawalAmount}", Convert.ToDecimal(WithdrawalAmount));
                            WithMessage = $"Your Account has been debited with a sum of #{WithdrawalAmount},\n if this operation was carried out by you, ignore otherwise, reach out to our nearest branch to block your account.";
                        }
                        else
                        {
                            WithMessage = "Insufficient Balance";
                        }
                    }
                }
            }
            Console.WriteLine(WithMessage);
            ErrorHandling.BackHome(customersModel);
        }
    }
    #endregion
}
