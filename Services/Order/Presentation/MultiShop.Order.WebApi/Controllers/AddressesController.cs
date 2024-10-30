using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase
	{
		private readonly GetAddressQueryHandler _getAddressQueryHandler;
		private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
		private readonly CreateAddressCommandHandler _createAddressCommandHandler;
		private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
		private readonly RemoveAddessCommandHandler _removeAddressCommandHandler;

		public AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler , UpdateAddressCommandHandler updateAddressCommandHandler , RemoveAddessCommandHandler removeAddessCommandHandler)
		{
			_getAddressQueryHandler = getAddressQueryHandler;
			_getAddressByIdQueryHandler = getAddressByIdQueryHandler;
			_createAddressCommandHandler = createAddressCommandHandler;
			_removeAddressCommandHandler = removeAddessCommandHandler;
			_updateAddressCommandHandler = updateAddressCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> List()
		{
			var values = await _getAddressQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> ListById(int id)
		{
			var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateAddressCommand command)
		{
			await _createAddressCommandHandler.Handle(command);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateAddressCommand command)
		{
			await _updateAddressCommandHandler.Handle(command);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
			return Ok();
		}
	}
}
