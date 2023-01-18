using System;
namespace FluentValidationRequest.Domain.Request
{
	public class AddressRequest
	{
		public string? Street { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
	}
}

