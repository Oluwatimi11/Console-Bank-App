using BankApp.Core.EntityImplementation.TRANSACTIONS;
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
    public class OnlineTransactions : Central
    {

        /// <summary>
        /// Bank Transactions
        /// </summary>

        #region All Bank Transactions
        public static void Transactions(CustomerModel customersModel)
        {
            Console.Clear();
            CompanyHeader.MyCompanyHeader();

            //Contains all transactions and operations possible
            BackgroundColors.colourYellow("What Transaction will you like to have on our platform today?: ");
            Console.WriteLine("1> Deposit");
            Console.WriteLine("2> Withdraw");
            Console.WriteLine("3> Transfer");
            Console.WriteLine("4> Account Balance");
            Console.WriteLine("5> Account Details");
            Console.WriteLine("6> Account Statement");
            Console.WriteLine("7> LogOut");
            Console.WriteLine("");
            Console.Write("Kindly enter a transaction option: ");

            string Choice = Console.ReadLine();
            while (Choice != "1" && Choice != "2" && Choice != "3" && Choice != "4" && Choice != "5" && Choice != "6" && Choice != "7")
            {
                BackgroundColors.colorRed("WARNING! - Invalid Input, kindly select an option from the lists provided.");
                Choice = Console.ReadLine();
            }

            switch (Choice)
            {
                case "1":
                    //Leads to the Deposit method
                    Deposit.MyDeposit(customersModel);
                    break;
                case "2":
                    //Leads to the Withdraw method
                    Withdraw.MyWithdraw(customersModel);
                    break;
                case "3":
                    //Leads to the Transfer method
                    Transfer.MyTransfer(customersModel);
                    break;
                case "4":
                    //Leads to the Balance printing method
                    Balance.MyBalance(customersModel);
                    break;
                case "5":
                    //Leads to the Details printing method
                    Details.MyDetails(customersModel);
                    break;
                case "6":
                    //Leads to the Statement printing method
                    Statement.MyStatement(customersModel);
                    break;
                case "7":
                    //Leads to the Initial Welcome UI which is the Main Menu
                    Console.Clear();
                    SignUp.RegisterInterface();
                    ErrorHandling.BackHome(customersModel);
                    break;
                default:
                    BackgroundColors.colorRed("Invalid Choice, Input a valid Option.");
                    break;
            }
        }
        #endregion
    }
}
