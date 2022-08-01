using BankApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.EntityImplementation
{
    /// <summary>
    /// Login Request with Email Address and Password
    /// </summary>

    #region Customer Login
    public class UsersLogin
    {

        //Method LogIn the user using the initially stored Email Address and Password information upon account creation
        public static CustomerModel UserSignIn(List<CustomerModel> customerModels, string EmailAddress, string Password)
        {
          foreach(var user in customerModels)
            {
                if (user.Email == EmailAddress && user.Password == Password)
                {
                    return user;
                }
            }
            return null;
        }
    }
    #endregion
}
