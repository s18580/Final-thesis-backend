using Application.Functions.Supplier.Commands.CreateSupplierCommand;
using Application.Functions.Supplier.Commands.CreateSupplierWithDataCommand;
using Application.Functions.Supplier.Commands.DeleteSupplierCommand;
using Application.Functions.Supplier.Commands.UpdateSupplierCommand;
using Application.Functions.Supplier.Queries.GetSupplierListQuery;
using Application.Functions.Supplier.Queries.GetSupplierQuery;
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
    public class SupplierController : ControllerBase
    {
        private IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Authorize(Roles = "Basic")]
        [Route("getSuppliers")]
        public async Task<IActionResult> GetDeliveryTypes()
        {
            var suppliers = await _mediator.Send(new GetSupplierListQuery());
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

        [HttpPost, Authorize(Roles = "Basic")]
        [Route("createSupplier")]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierCommand command)
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
        [Route("createSupplierWithData")]
        public async Task<IActionResult> CreateSupplierWithData([FromBody] CreateSupplierWithDataCommand command)
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

        [HttpDelete, Authorize(Roles = "Basic")]
        [Route("deleteSupplier")]
        public async Task<IActionResult> DeleteSupplier([FromBody] DeleteSupplierCommand command)
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
