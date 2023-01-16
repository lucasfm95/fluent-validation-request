namespace FluentValidationRequest.Domain.Request
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? DocumentNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public bool HasPhoneNumber { get; set; }
        public bool HasEmail { get; set; }
        public List<FamilyMember> FamilyMembers { get; set; }
    }
}
