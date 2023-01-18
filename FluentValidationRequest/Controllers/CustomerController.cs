using FluentValidationRequest.Domain.Request;
using FluentValidationRequest.Domain.Validators;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationRequest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private static List<CustomerRequest> _customers = new();
        private static readonly CustomerValidator _customerValidator = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var customer = _customers.FirstOrDefault(customer => customer.Id == id);

            if (customer is null)
            {
                return NoContent();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerRequest customer)
        {
            var result = _customerValidator.Validate(customer);

            if (!result.IsValid) 
                return BadRequest(result.Errors.Select(p => p.ErrorMessage).ToList());

            var lastId = _customers.LastOrDefault()?.Id ?? 0;
            customer.Id = lastId + 1;

            _customers.Add(customer);

            return CreatedAtAction(nameof(GetById),  new { id = customer.Id }, customer);
        }
    }
}
