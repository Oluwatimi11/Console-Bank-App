using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Models
{
    public class CustomerModel
    {
        //Takes all Model/Properties of the noun-Customer
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
