using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankApp.Core.Utilities
{
    public class UserValidation
    {
        /// <summary>
        /// Validates Email Address
        /// </summary>
        /// <returns></returns>

        #region Email Validation
        public static bool ValidateEmail(string email)
            {
                string strRegex = @"^[a-z]+[0-9a-zA-Z_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                return PerformRegExMethod(strRegex, email);
            }

        #endregion

        /// <summary>
        /// Validates First and Last Names respectively
        /// </summary>
        /// <returns></returns>

        #region Validate Names
        public static bool ValidateName(string name)
            {
                string strRegex = @"^[A-Z]";
                return PerformRegExMethod(strRegex, name);
            }

        #endregion

        /// <summary>
        ///Validates Password
        /// </summary>

        #region Validates Password

        public static bool ValidatePassword(string password)
            {
                string strRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$";
                return PerformRegExMethod(strRegex, password);
            }
            private static bool PerformRegExMethod(string pattern, string value)
            {
                Regex re = new Regex(pattern);
                if (re.IsMatch(value))
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
        #endregion

    }
}
