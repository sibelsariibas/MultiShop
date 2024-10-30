using MediatR;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handler.OrderingHandlers
{
	public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommands>
	{
		private readonly IRepository<Ordering> _repository;

		public CreateOrderingCommandHandler(IRepository<Ordering> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateOrderingCommands request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsycn(new Ordering
			{
				OrderDate = request.OrderDate,
				TotalPrice = request.TotalPrice,
				UserId = request.UserId
			});
		}
	}
}
