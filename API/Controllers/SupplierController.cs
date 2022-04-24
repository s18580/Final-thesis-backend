using Application.Functions.Supplier.Commands.CreateSupplierCommand;
using Application.Functions.Supplier.Commands.DeleteSupplierCommand;
using Application.Functions.Supplier.Commands.UpdateSupplierCommand;
using Application.Functions.Supplier.Queries.GetSupplierListQuery;
using Application.Functions.Supplier.Queries.GetSupplierQuery;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getSuppliers")]
        public async Task<IActionResult> GetDeliveryTypes()
        {
            var suppliers = await _mediator.Send(new GetSupplierListQuery());
            return Ok(suppliers);
        }

        [HttpGet]
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

        [HttpPost]
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

        [HttpPost]
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

        [HttpDelete]
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
