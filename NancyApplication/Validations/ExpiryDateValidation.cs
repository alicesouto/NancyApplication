using FluentValidation;

namespace NancyApplication.Validation
{
    public class ExpiryDateValidation : AbstractValidator<ExpiryDateStruct>
    {
        public ExpiryDateValidation()
        {
            RuleFor(request => request.Month).Length(2,2).WithMessage("");
            RuleFor(request => request.Year).Length(2,4).WithMessage("");
        }
    }
}