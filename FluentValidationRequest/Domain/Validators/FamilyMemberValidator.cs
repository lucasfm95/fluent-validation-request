using FluentValidation;
using FluentValidationRequest.Domain.Request;

namespace FluentValidationRequest.Domain.Validators
{
    public class FamilyMemberValidator : AbstractValidator<FamilyMemberRequest>
    {
        public FamilyMemberValidator()
        {
            RuleFor(familyMember => familyMember.FirstName)
                .NotEmpty()
                .WithMessage("The FamilyMember.FirstName field is required")
                .NotNull()
                .WithMessage("The FamilyMember.FirstName field is required")
                .MinimumLength(3)
                .WithMessage("The FamilyMember.FirstName field minimum length is 3")
                .MaximumLength(100)
                .WithMessage("The FamilyMember.FirstName field maximum length is 100");
        }
    }
}
