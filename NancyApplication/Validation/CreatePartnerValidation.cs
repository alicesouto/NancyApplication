using FluentValidation;
using UmRioCheckoutNancy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmRioCheckoutNancy.Validation
{
    public class CreatePartnerValidation : AbstractValidator<Partner>
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage("");
        RuleFor(request => request.Email).NotEmpty().WithMessage("");
        RuleFor(request => request.Plan).NotEmpty().WithMessage("");
        RuleFor(request => request.CreditCard).NotEmpty().WithMessage("");

        RuleFor(request => request.CreditCard.Number).Length(10,30).WithMessage("");
    }
}