using UmRioCheckoutNancy.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmRioCheckoutNancy.Models
{
    public class Partner
    {
        public CreditCard CreditCard { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Plan { get; set; } //Amount in Cents
    }
}