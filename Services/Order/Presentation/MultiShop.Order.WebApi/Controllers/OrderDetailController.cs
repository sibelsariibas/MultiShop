using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailController : ControllerBase
	{
		private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
		private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
		private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
		private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
		private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

		public OrderDetailController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeAddessCommandHandler)
		{
			_getOrderDetailQueryHandler = getOrderDetailQueryHandler;
			_getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
			_createOrderDetailCommandHandler = createOrderDetailCommandHandler;
			_removeOrderDetailCommandHandler = removeAddessCommandHandler;
			_updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> List()
		{
			var values = _getOrderDetailQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> ListById(int id)
		{
			var values = _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateOrderDetailCommand command)
		{
			await _createOrderDetailCommandHandler.Handle(command);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateOrderDetailCommand command)
		{
			await _updateOrderDetailCommandHandler.Handle(command);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
			return Ok();
		}
	}
}
