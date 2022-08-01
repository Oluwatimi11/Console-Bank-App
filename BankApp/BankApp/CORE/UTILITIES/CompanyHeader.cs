using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Utilities
{

    /// <summary>
    /// Company Header
    /// </summary>

    #region Company Header
    public class CompanyHeader
    {
        //Takes in the major organization's header for each UI
        public static void MyCompanyHeader()
        {
            BackgroundColors.colourBlue("BLUEHOOD MICROFINANCE BANK");
            BackgroundColors.colorMagenta("WELCOME TO OUR SAFE AND FAST BANKING SERVICES THAT KEEPS YOUR FINANCIAL THOUGHTS AT PEACE...");
            BackgroundColors.colourBlue("KINDLY CHOOSE A BANKING OPERATION TODAY.");
        }
    }
    #endregion

}
