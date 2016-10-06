using FluentValidation;
using UmRioCheckoutNancy.Models;

namespace UmRioCheckoutNancy.Validation
{
    public class CreatePartnerValidation : AbstractValidator<Partner>
    {
        public CreatePartnerValidation()
        {

            RuleFor(request => request.Name).NotEmpty().WithMessage("");
            RuleFor(request => request.Email).NotEmpty().WithMessage("");
            RuleFor(request => request.Plan).NotEmpty().WithMessage("");
            RuleFor(request => request.CreditCard).NotEmpty().WithMessage("");

            RuleFor(request => request.CreditCard.Number).Length(10, 30).WithMessage("");
        }
    }
}
