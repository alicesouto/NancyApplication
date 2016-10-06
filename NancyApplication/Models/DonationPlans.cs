using System.Collections.Generic;

namespace UmRioCheckoutNancy.Modules
{
    public class DonationPlans
    {
        public DonationPlans()
        {
            Amount = new List<double>();
            Amount.Add(10.00);
            Amount.Add(30.00);
        }

        public List<double> Amount { get; set; }
    }
}