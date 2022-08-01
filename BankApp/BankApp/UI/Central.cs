using BankApp.Core.EntityImplementation;
using BankApp.Core.Models;
using BankApp.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.UI
{
    public class Central
    {
        public static readonly List<Account> ListOfAccount = new List<Account>();

        /// <summary>
        /// Major Operations
        /// </summary>
        #region Central Operations
        public static void CentralOperations(CustomerModel myCustomers)
        {
            Console.Clear();
            CompanyHeader.MyCompanyHeader();

            //This is the Customer's profile interface from the initial option 2 in the Welcome UI
            Console.WriteLine("What will you like to do on your dashboard.. ");
            Console.WriteLine("1> Create Account");
            Console.WriteLine("2> Online Transactions");
            Console.WriteLine("3> LogOut");
            Console.Write("Enter a Reply here: ");
            string Choice = Console.ReadLine();

            while (Choice != "1" && Choice != "2" && Choice != "3")
            {
                Console.Write("Enter a Valid Response...");
                Choice = Console.ReadLine();
            }

            switch (Choice)
            {
                //Provides the Customer an option to create an account either a current/Savings Account
                case "1":
                    Console.Clear();
                    string AccountChoice;
                        
                    
                        BackgroundColors.colourYellow("Dear Valued Customer. What type of Account will you like to create?, SAVINGS/CURRENT...");
                        Console.WriteLine("1> SAVINGS ACCOUNT");
                        Console.WriteLine("2> CURRENT ACCOUNT");
                        Console.Write("Enter your reply here: ");
                        AccountChoice = Console.ReadLine();

                        while (AccountChoice != "1" && AccountChoice != "2")
                        {
                            BackgroundColors.colorRed("ERROR - INVALID ACCOUNT TYPE!");
                            Console.Write("Kindly input a valid type, choose 1 for a Savings Account or 2 for a Current Account");
                            AccountChoice = Console.ReadLine();
                        }
                    
                        //Saves the new account and gives an email address accessibility
                    var newAccount = new Account(AccountChoice, myCustomers.Id, myCustomers.Email);
                    ListOfAccount.Add(newAccount);

                    ErrorHandling.SuccessMessage($"Congratulations!!! Dear {myCustomers.Lastname} {myCustomers.Firstname}.");
                    ErrorHandling.SuccessMessage($"You have successfully created a {newAccount.MyAccount.AccountType}.");
                    ErrorHandling.SuccessMessage($"Account Number: {newAccount.MyAccount.AccountNumber}");
                    ErrorHandling.SuccessMessage($"Thank You for Choosing Bluehood!");
                    ErrorHandling.ComeBack(myCustomers);
                    break;
                case "2":
                    //Option leads to the next Transaction interface, were all customers transactions occur and get saved
                    Console.Clear();
                    OnlineTransactions.Transactions(myCustomers);
                    break;
                case "3":
                    //Automatically takes the customer back to the initial Welcome UI
                    Console.Clear();
                    SignUp.RegisterInterface();
                    break;
                default:
                    BackgroundColors.colorRed("Invalid Choice, Kindly Input a valid Response.");
                    break;
            }
        }
        #endregion
    }
}
