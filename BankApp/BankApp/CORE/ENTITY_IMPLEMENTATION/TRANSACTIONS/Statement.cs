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
    /// Takes in Account Statement Method
    /// </summary>

    #region Account Statement
    public class Statement : Central
    {

        //Takes the statement printng operation
        public static void MyStatement(CustomerModel customersModel)
        {
            Console.Clear();
            var accountNumb = DisplayAccount.AccountGen(customersModel, ListOfAccount);
            Console.WriteLine($"Account Details for {accountNumb}");
            var newTable = new PrintTable("Date", "Description", "Amount", "Balance");

            foreach (var account in ListOfAccount)
            {
                if (account.MyAccount.EmailAddress == customersModel.Email)
                {
                  
                    var list = account.MyAccount.TransactionList;

                    foreach (var item in list)
                    {
                        if (item.AccountNumber == accountNumb)
                        {
                            newTable.AddRow(item.Date, item.Description, item.Amount, item.Balance);
                        }
                    }
                }
            }
            newTable.Print();
            ErrorHandling.BackHome(customersModel);
        }
    }
    #endregion
}
