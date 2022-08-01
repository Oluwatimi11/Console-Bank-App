using BankApp.Core.Models;
using BankApp.Core.Utilities;
using BankApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.EntityImplementation
{
    public class DisplayAccount
    {
        /// <summary>
        ///This Method displays all created account for all transaction processes
        /// </summary>
        /// <returns></returns>

        #region Account Generator
        public static string AccountGen(CustomerModel customerModel, List<Account> newAccount)
        {
            CompanyHeader.MyCompanyHeader();
            int i = 1;

            List<String> OwnerAccounts = new List<String>();
            foreach(var account in newAccount)
            {
                if (account.MyAccount.EmailAddress == customerModel.Email)
                {
                    Console.WriteLine($"{i} Account Type: {account.MyAccount.AccountType}\t Account Number: {account.MyAccount.AccountNumber}");
                    OwnerAccounts.Add(account.MyAccount.AccountNumber); 
                    i++;
                }
            }

            Console.WriteLine("SELECT ACCOUNT TO ACCESS");
            if (OwnerAccounts.Count==0)
            {
                BackgroundColors.colorRed("You do not have any account with us please create an account");
                ErrorHandling.ComeBack(customerModel);
            }
            Console.Write("Please Enter an Account from the list provided: ");
            string AccountChoice = Console.ReadLine();

            int wrongChoice;

            while (!int.TryParse(AccountChoice, out wrongChoice))
            {
                Console.Write("INPUT A VALID DIGIT FROM THE LIST PROVIDED: ");
                AccountChoice = Console.ReadLine();
            }

            int Counts = wrongChoice - 1;


            return OwnerAccounts[Counts];
        }

        #endregion
    }
}
