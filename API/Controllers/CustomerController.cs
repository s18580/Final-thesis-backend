using Application.Functions.Customer.Commands.CreateCompanyCustomerCommand;
using Application.Functions.Customer.Commands.CreatePersonCustomerCommand;
using Application.Functions.Customer.Commands.DeleteCustomerCommand;
using Application.Functions.Customer.Commands.UpdateCompanyCustomerCommand;
using Application.Functions.Customer.Commands.UpdatePersonCustomerCommand;
using Application.Functions.Customer.Queries.GetCustomerListQuery;
using Application.Functions.Customer.Queries.GetCustomerQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _mediator.Send(new GetCustomerListQuery());
            return Ok(customers);
        }

        [HttpGet]
        [Route("getCustomer")]
        public async Task<IActionResult> GetCustomer([FromQuery] int id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery { IdCustomer = id });
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        [Route("createCompanyCustomer")]
        public async Task<IActionResult> CreateCompanyCustomer([FromBody] CreateCompanyCustomerCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok();
            }
            else if (response.Status == ResponseStatus.ValidationError)
            {
                return UnprocessableEntity(response.Message);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("createPersonCustomer")]
        public async Task<IActionResult> CreatePersonCustomer([FromBody] CreatePersonCustomerCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok();
            }
            else if (response.Status == ResponseStatus.ValidationError)
            {
                return UnprocessableEntity(response.Message);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("updateCompanyCustomer")]
        public async Task<IActionResult> UpdateCompanyCustomer([FromBody] UpdateCompanyCustomerCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok();
            }
            else if (response.Status == ResponseStatus.ValidationError && response.Message.Contains("does not exist"))
            {
                return NotFound(response.Message);
            }
            else if (response.Status == ResponseStatus.ValidationError)
            {
                return UnprocessableEntity(response.Message);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("updatePersonCustomer")]
        public async Task<IActionResult> UpdatePersonCustomer([FromBody] UpdatePersonCustomerCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok();
            }
            else if (response.Status == ResponseStatus.ValidationError && response.Message.Contains("does not exist"))
            {
                return NotFound(response.Message);
            }
            else if (response.Status == ResponseStatus.ValidationError)
            {
                return UnprocessableEntity(response.Message);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deleteCustomer")]
        public async Task<IActionResult> DeleteCustomer([FromBody] DeleteCustomerCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok();
            }
            else if (response.Status == ResponseStatus.ValidationError && response.Message.Contains("does not exist"))
            {
                return NotFound(response.Message);
            }
            else if (response.Status == ResponseStatus.ValidationError)
            {
                return UnprocessableEntity(response.Message);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
