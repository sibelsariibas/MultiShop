﻿using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class RemoveOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetails> _repository;

		public RemoveOrderDetailCommandHandler(IRepository<OrderDetails> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveOrderDetailCommand command)
		{
			var values = await _repository.GetByIdAsync(command.Id);
			await _repository.DeleteAsycnAsync(values);


		}
	}
}
