using System;
namespace FluentValidationRequest.Domain.Request
{
	public class FamilyMemberRequest
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public AddressRequest? Address { get; set; }
		public bool? HasPhoneNumber { get; set; }
	}
}

