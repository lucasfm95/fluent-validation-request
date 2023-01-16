﻿using FluentValidationRequest.Domain.Request;
using FluentValidationRequest.Domain.Validators;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationRequest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private static List<CustomerRequest> _customers = new List<CustomerRequest>();
        private static readonly  CustomerValidator _customerValidator = new();

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

            if (result.IsValid)
            {
                return Ok(customer);
            }

            return BadRequest(result.Errors
                .Select(p => p.ErrorMessage)
                .ToArray());
            //CreatedAtAction(nameof(GetById), new { Id: 1 }, customer);
        }
    }
}