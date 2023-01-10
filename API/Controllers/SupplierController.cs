using Application.Functions.Supplier.Commands.CreateSupplierWithDataCommand;
using Application.Functions.Supplier.Commands.UpdateSupplierCommand;
using Application.Functions.Supplier.Queries.GetSearchSupplierQuery;
using Application.Functions.Supplier.Queries.GetSupplierListQuery;
using Application.Functions.Supplier.Queries.GetSupplierQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getSuppliers")]
        public async Task<IActionResult> getSuppliers()
        {
            var suppliers = await _mediator.Send(new GetSupplierListQuery());
            return Ok(suppliers);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getSearchSuppliers")]
        public async Task<IActionResult> GetSearchSuppliers(string supplierName, string phoneNumber, string emailAddress, string addressName, string street, string city, string description, string representativeName, string representativeLastName)
        {
            var suppliers = await _mediator.Send(new GetSearchSupplierQuery() { SupplierName = supplierName, PhoneNumber = phoneNumber, EmailAddress = emailAddress, AddressName = addressName, Street = street, City = city, Description = description, RepresentativeName = representativeName, RepresentativeLastName = representativeLastName });
            return Ok(suppliers);
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getSupplier")]
        public async Task<IActionResult> GetSupplier([FromQuery] int id)
        {
            var supplier = await _mediator.Send(new GetSupplierQuery { IdSupplier = id });
            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        [HttpPost, Authorize(Roles = "Office")]
        [Route("createSupplierWithData")]
        public async Task<IActionResult> CreateSupplierWithData([FromBody] CreateSupplierWithDataCommand command)
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

        [HttpPost, Authorize(Roles = "Office")]
        [Route("updateSupplier")]
        public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierCommand command)
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
