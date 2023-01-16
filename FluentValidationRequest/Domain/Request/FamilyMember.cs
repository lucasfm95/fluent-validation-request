using System;
namespace FluentValidationRequest.Domain.Request
{
	public class FamilyMember
	{
		public string FistName { get; set; }
		public string LastName { get; set; }
		public Address Address { get; set; }
		public bool HasPhoneNumber { get; set; }
	}
}

