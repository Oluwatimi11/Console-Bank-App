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
    public class SignUp
    {
        static readonly List<CustomerModel> Bank_Customers = new();

        /// <summary>
        /// Registeration Interface
        /// </summary>
        #region Registration Interface
        public static void RegisterInterface()
        {
            Console.Clear();
            CompanyHeader.MyCompanyHeader();

            //Customers first entry, Introduces the Customer to either Register or LogIn into a his dashboard

            BackgroundColors.colourYellow("What will you like to do on our platform today?: ");
            Console.WriteLine("1> Register/SignUp");
            Console.WriteLine("2> Login");
            Console.WriteLine("3> Exit.");
            Console.Write("Kindly Enter a Reply here: ");
            string Choice = Console.ReadLine();


            //Checks for a wrong option choice by the customer
            while (Choice != "1" && Choice != "2" && Choice != "3")
                {
                ErrorHandling.TryAgain("WARNING: Invalid Response. Try Again with a valid Response.");
                Choice = Console.ReadLine();
            }

            switch (Choice)
            {
                //Introduces the Customer to the UI to either register or signup as a banking customer
                case "1":
                    string FirstName;
                    string LastName;
                    string EmailAddress;
                    string Password;

                    while(true)
                    {
                        Console.Write("FirstName: ");
                        FirstName = Console.ReadLine();
                    if (UserValidation.ValidateName(FirstName))
                        {
                            break;
                        }
                        BackgroundColors.colorRed("Input a correct First Name format!");
                    }
                    while(true)
                    {

                        Console.Write("LastName: ");
                        LastName = Console.ReadLine();
                        if (UserValidation.ValidateName(LastName))
                        {
                            break;
                        }
                        BackgroundColors.colorRed("Input a correct Last Name format!");
                    }
                    while (true)
                    {

                        Console.Write("Email Address: ");
                        EmailAddress = Console.ReadLine();
                        if (UserValidation.ValidateEmail(EmailAddress))
                        {
                            break;
                        }
                        BackgroundColors.colorRed("Input a correct Email Address format!");
                    }
                    while (true)
                    {

                        Console.Write("Password: ");
                        Password = Console.ReadLine();
                        if (UserValidation.ValidatePassword(Password))
                        {
                            break;
                        }
                        BackgroundColors.colorRed("Input a correct Password format!");
                    }

                    try
                    {
                        CustomerModel NewCustomers = new()
                        {
                            Firstname = FirstName,
                            Lastname = LastName,
                            Email = EmailAddress,
                            Password = Password
                        };
                        Bank_Customers.Add(NewCustomers);
                        ErrorHandling.SuccessMessage("Registration Successful.");
                        ErrorHandling.SuccessMessage("Thank you for joining our One time Banking Platform.");
                    }
                    catch (Exception)
                    {
                        ErrorHandling.TryAgain("Try Again!");
                    }
                    ErrorHandling.GetBack();
                    break;
                case "2":
                    //Gives an option of the Customer continue to Login if he/she already have an account.
                    string MyEmailAddress;
                    string MyPassword;

                    while (true)
                    {

                        Console.Write("Email Address: ");
                        MyEmailAddress = Console.ReadLine();
                        if (UserValidation.ValidateEmail(MyEmailAddress))
                        {
                            break;
                        }
                        BackgroundColors.colorRed("Input a correct Email Address format!");
                    }
                    while (true)
                    {

                        Console.Write("Password: ");
                        MyPassword = Console.ReadLine();
                        if (UserValidation.ValidatePassword(MyPassword))
                        {
                            break;
                        }
                        BackgroundColors.colorRed("Input a correct Password format!");
                    }

                    CustomerModel customerLogin = UsersLogin.UserSignIn(Bank_Customers, MyEmailAddress, MyPassword);
                    if (customerLogin != null)
                    {
                        CompanyHeader.MyCompanyHeader();
                        Central.CentralOperations(customerLogin);
                    }
                    else
                    {
                        while(true)
                        {
                            BackgroundColors.colorRed("Invalid Credentials!, Kindly input a valid credential.");
                            ErrorHandling.GetBack();
                            Console.ReadLine();
                        }
                    }
                    ErrorHandling.GetBack();
                    break;
                case "3":
                    //EXIT or breaks the code
                    break;
                default:
                    BackgroundColors.colorRed("Invalid Choice, Kindly Input a Valid Response");
                    break;
            }
        }
        #endregion
    }
}
