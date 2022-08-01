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
    /// Takes in Transaction Details Method
    /// </summary>

    #region Details
    public class Details : Central
    {
        //Takes the details printing operation
        public static void MyDetails(CustomerModel customersModel)
        {
            Console.Clear();
            var Table = new PrintTable("Account Number", "Account Name", "Account Type", "Account Balance");
            Console.WriteLine($"Account Details for {customersModel.Firstname} {customersModel.Lastname}");

            foreach (var account in ListOfAccount)
            {
                if (account.MyAccount.EmailAddress == customersModel.Email)
                {
                    Table.AddRow(account.MyAccount.AccountNumber, customersModel.Firstname, account.MyAccount.AccountType, account.MyAccount.AcctBalance);
                }
            }
            Table.Print();
            ErrorHandling.BackHome(customersModel);
        }
    }
    #endregion
}
