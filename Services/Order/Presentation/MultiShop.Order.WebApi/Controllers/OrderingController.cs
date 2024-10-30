using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderingController : ControllerBase
	{
		private readonly IMediator _mediator;
		public OrderingController (IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet] 
		public async Task<IActionResult> List()
		{
			var values = await _mediator.Send(new GetOrderingQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await  _mediator.Send(new GetOrderingByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Create( CreateOrderingCommands command)
		{
		  await _mediator.Send(command);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateOrderingCommands commands)
		{
			await _mediator.Send(commands);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			await _mediator.Send(new RemoveOrderingCommands(id));
			return Ok();
		}
	}
}
