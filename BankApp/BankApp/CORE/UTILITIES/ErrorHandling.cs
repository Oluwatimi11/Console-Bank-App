using BankApp.Core.EntityImplementation;
using BankApp.Core.Models;
using BankApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Utilities
{

    /// <summary>
    /// Error Handling
    /// </summary>

    #region Error Handling
    public static class ErrorHandling
    {
        //Handles all possible error in the system
        public static void SuccessMessage(string message)
        {
            BackgroundColors.colorGreen(message);
        }

        public static decimal AmountError(decimal amount)
        {
            while(true)
            {
                if(amount < 0)
                {
                    BackgroundColors.colorRed("Invalid Amount!");
                    Console.Write("Enter a valid Amount: ");
                    amount = Convert.ToDecimal(amount);
                }
                return amount;
            }
        }

        public static void TryAgain(string message)
        {
            BackgroundColors.colorRed(message);
            Console.Write("Enter a Valid Response: ");
        }

        public static void BackHome(CustomerModel customers)
        {
            Console.Write("Enter 01 to go Back, and 00 to Main Menu: ");
            string Respond = Console.ReadLine();
            while(Respond != "01" && Respond != "00")
            {
                BackgroundColors.colorRed("Please Enter a Valid Response!");
                Respond = Console.ReadLine();
            }
            if (Respond == "01")
            {
                OnlineTransactions.Transactions(customers);
            }
            else
            {
                Central.CentralOperations(customers);
            }
        }

        public static void ComeBack(CustomerModel customers)
        {
            Console.Write("Enter 01 to go Back, and 00 to Main Menu: ");
            string Responds = Console.ReadLine();
            while (Responds != "01" && Responds != "00")
            {
                BackgroundColors.colorRed("Invalid Input!");
                Responds = Console.ReadLine();
            }
            if (Responds == "00")
            {
                SignUp.RegisterInterface();
            }
            else
            {
                Central.CentralOperations(customers);
            }
        }

        public static void GetBack()
        {
            Console.Write("Enter 00 to go Back: ");
            string Responde = Console.ReadLine();
            while (Responde != "00")
            {
                BackgroundColors.colorRed("Invalid Input!");
                Responde = Console.ReadLine();
            }
            if (Responde == "00")
            {
                SignUp.RegisterInterface();
            }
            else
            {
                ErrorHandling.TryAgain("Input a Valid Response.");
            }
        }
    }
    #endregion
}
