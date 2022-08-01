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
    /// Display Balance Method
    /// </summary>

    #region Balance
    public class Balance : Central
    {
        //Takes the balance printing operation
        public static void MyBalance(CustomerModel customersModel)
        {
            Console.Clear();
            var MyAccountNumb = DisplayAccount.AccountGen(customersModel, ListOfAccount);
            string BalMessage = "";

            foreach (var account in ListOfAccount)
            {
                if (account.MyAccount.AccountNumber == MyAccountNumb)
                {
                    BalMessage = $"Account Number: {account.MyAccount.AccountNumber} \n Account Balance: {account.MyAccount.AcctBalance}";
                }
            }
            ErrorHandling.SuccessMessage(BalMessage);
            ErrorHandling.BackHome(customersModel);
        }
    }
    #endregion
}
