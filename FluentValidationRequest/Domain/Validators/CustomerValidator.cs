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
                .NotNull()
                .WithMessage("The DocumentNumber field is required")
                .MinimumLength(11)
                .WithMessage("The DocumentNumber field minimum length is 11")
                .MaximumLength(14)
                .WithMessage("The DocumentNumber field maximum length is 14");

            RuleFor(customer => customer.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("The FirstName field is required")
                .MinimumLength(3)
                .WithMessage("The FirstName field minimum length is 3")
                .MaximumLength(100)
                .WithMessage("The FirstName field maximum length is 100");

            RuleFor(customer => customer.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("The LastName field is required")
                .MinimumLength(3)
                .WithMessage("The LastName field minimum length is 3")
                .MaximumLength(100)
                .WithMessage("The LastName field maximum length is 100");

            RuleFor(customer => customer.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("The Email field is required")
                .MinimumLength(5)
                .WithMessage("The Email field minimum length is 5")
                .MaximumLength(100)
                .WithMessage("The Email field maximum length is 100");

            When(customer => customer?.FamilyMembers?.Any() ?? false, () =>
            {
                RuleForEach(customer => customer.FamilyMembers)
                    .SetValidator(new FamilyMemberValidator());
            });
        }
    }
}
