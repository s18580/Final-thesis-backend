using Application.Functions.Customer.Commands.CreateCompanyCustomerCommand;
using Application.Functions.Customer.Commands.CreateCompanyCustomerWithDataCommand;
using Application.Functions.Customer.Commands.CreatePersonCustomerCommand;
using Application.Functions.Customer.Commands.CreatePersonCustomerWithDataCommand;
using Application.Functions.Customer.Commands.DeleteCustomerCommand;
using Application.Functions.Customer.Commands.UpdateCompanyCustomerCommand;
using Application.Functions.Customer.Commands.UpdatePersonCustomerCommand;
using Application.Functions.Customer.Queries.GetCustomerListQuery;
using Application.Functions.Customer.Queries.GetCustomerQuery;
using Application.Functions.Customer.Queries.GetSearchCustomerListQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _mediator.Send(new GetCustomerListQuery());
            return Ok(customers);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getSearchCustomers")]
        public async Task<IActionResult> GetSearchCustomers([FromQuery] string customerName, string customerPhone, string customerEmail, string nIP, string rEGON, string representativeName, string representativeLastName, string representativePhone, string representativeEmail, string workerLeader)
        {
            var customers = await _mediator.Send(new GetSearchCustomerListQuery() { CustomerName = customerName, CustomerPhone = customerPhone, CustomerEmail = customerEmail, NIP = nIP, REGON = rEGON, RepresentativeName = representativeName, RepresentativeLastName = representativeLastName, RepresentativeEmail = representativeEmail, RepresentativePhone = representativePhone, WorkerLeader = workerLeader });
            return Ok(customers);
        }

        [HttpGet, Authorize(Roles = "Basic")]
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

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createCompanyCustomer")]
        public async Task<IActionResult> CreateCompanyCustomer([FromBody] CreateCompanyCustomerCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(response.Id);
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

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createPersonCustomer")]
        public async Task<IActionResult> CreatePersonCustomer([FromBody] CreatePersonCustomerCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(response.Id);
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

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createCompanyCustomerWithData")]
        public async Task<IActionResult> CreateCompanyCustomerWithData([FromBody] CreateCompanyCustomerWithDataCommand command)
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

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createPersonCustomerWithData")]
        public async Task<IActionResult> CreatePersonCustomerWithData([FromBody] CreatePersonCustomerWithDataCommand command)
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

        [HttpPost, Authorize(Roles = "Basic")]
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

        [HttpPost, Authorize(Roles = "Basic")]
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

        [HttpDelete, Authorize(Roles = "Basic")]
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
