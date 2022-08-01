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
    /// Takes in Transfer Transaction Method
    /// </summary>

    #region Transfer
    public class Transfer : Central
    {
        //Takes the transfer operation
        public static void MyTransfer(CustomerModel customersModel)
        {
            Console.Clear();
            string SenderAcct = DisplayAccount.AccountGen(customersModel, ListOfAccount);
            Console.Write("Enter Recipient Bank Name: ");
            Console.ReadLine();
            Console.Write("Enter Recipient Account Name: ");
            Console.ReadLine();
            //Takes the receiving account number
            Console.Write("Enter Recipient Account Number: ");


            decimal TransferAmount;
            long ReceiverAcctNum;

            string ReceiverAcct = Console.ReadLine();
            //Checks if the receiving account number is of long datatype
            while (!long.TryParse(ReceiverAcct, out ReceiverAcctNum))
            {
                Console.WriteLine("Try Again with a Valid Account Number!");
                ReceiverAcct = Console.ReadLine();

            }

            //Checks if the receiving account number's length
            while (ReceiverAcct.Length is not 10 and not 11 and not 12 and not 13)
            {
                Console.WriteLine("Try Again with a Valid Account Number with range in between 10 to 13 digits!");
                ReceiverAcct = Console.ReadLine();

            }

            Console.WriteLine("Amount: ");
            TransferAmount = ErrorHandling.AmountError(Convert.ToDecimal(Console.ReadLine()));

            bool Check = false;

            foreach (var account in ListOfAccount)
            {
                if (account.MyAccount.AccountNumber == SenderAcct)
                {
                    Check = account.DebitWithdrawal(account.MyAccount.AccountType, TransferAmount);
                    if (Check)
                    {
                        account.AddTransactionData($"Debit Amount: {TransferAmount} from {account.MyAccount.AccountType}", TransferAmount);
                    }
                }
            }
            Console.WriteLine($"Transfer Successful, an amount of {TransferAmount} has been deducted from your Account");
            if (Check)
            {
                foreach (var account in ListOfAccount)
                {
                    if (account.MyAccount.AccountNumber == ReceiverAcct)
                    {
                        account.CreditDeposit(TransferAmount);
                        account.AddTransactionData($"Credit Amount {TransferAmount} into {account.MyAccount.AccountType}", TransferAmount);
                    }
                }
            }
            else
            {
                Console.WriteLine("Insufficient Funds!");
            }
            ErrorHandling.BackHome(customersModel);
        }
    }
    #endregion
}
