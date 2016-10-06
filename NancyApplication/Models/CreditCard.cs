using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmRioCheckoutNancy.Modules
{
    public class CreditCard
    {
        public string Number { get; set; }

        public string ExpiryDate { get; set; }

        public string Cvv { get; set; }

        public string Name { get; set; }
    }
}