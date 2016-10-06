using Nancy;
using Nancy.ModelBinding;
using UmRioCheckoutNancy.Models;
using UmRioCheckoutNancy.Modules;

namespace NancyApplication.Modules
{
    public class PartnerModule : NancyModule
    {
        public PartnerModule()
        {
            Get["/create"] = _ =>
            {
                dynamic viewBag = new DynamicDictionary();
                var Plans = new DonationPlans();
                viewBag.DonationPlans = Plans.Amount;
                return View["create", viewBag];
            };

            Post["/create"] = _ =>
            {
                Partner partner = this.Bind<Partner>(); //model binding

                dynamic viewBag = new DynamicDictionary();
                var Plans = new DonationPlans();
                viewBag.DonationPlans = Plans.Amount;

                //if (!ModelState.IsValid) --> use FluentValidation
                {
                    return View["create"];
                }

                var partnerManager = new PartnerManager();

                var result = partnerManager.VerifyPartner(partner);

                if (result.Valid == false)
                {
                    ViewBag.ErrorMessage = result.Message;
                    return View["create"];
                }

                return RedirectToAction("Thank");

            };
        }
    }
}