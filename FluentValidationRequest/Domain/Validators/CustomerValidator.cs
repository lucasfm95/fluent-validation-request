using FluentValidation;
using FluentValidationRequest.Domain.Request;

namespace FluentValidationRequest.Domain.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerRequest>
    {
        public CustomerValidator()
        {
            RuleFor((customer) => customer.DocumentNumber)
                .NotEmpty()
                .WithMessage("DocumentNumber field is required")
                .MinimumLength(11)
                .WithMessage("The DocumentNumber field minimum length is 11")
                .MaximumLength(14)
                .WithMessage("The DocumentNumber field maximum length is 14");
        }
    }
}
