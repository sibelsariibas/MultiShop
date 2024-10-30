﻿using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class GetOrderDetailQueryHandler
	{
		private readonly IRepository<OrderDetails> _repository;

		public GetOrderDetailQueryHandler(IRepository<OrderDetails> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetOrderDetailQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetOrderDetailQueryResult
			{
				ProductAmount=x.ProductAmount, 
				ProductName=x.ProductName,
				OrderDetailId=x.OrderDetailsId,
				OrderingId=x.OrderingId,
				ProductId=x.ProductId,
				ProductPrice=x.ProductPrice,
				ProductTotalPrice=x.ProductTotalPrice
			}).ToList();

		}
	}
}