using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
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
	public class GetOrderDetailByIdQueryHandler
	{
		private readonly IRepository<OrderDetails> _repository;

		public GetOrderDetailByIdQueryHandler(IRepository<OrderDetails> repository)
		{
			_repository = repository;
		}

		public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetOrderDetailByIdQueryResult
			{
				OrderDetailId = values.OrderDetailsId,
				ProductAmount= values.ProductAmount,
				ProductId= values.ProductId,
				ProductName= values.ProductName,
				ProductTotalPrice= values.ProductTotalPrice,
				ProductPrice= values.ProductPrice,
				OrderingId= values.OrderingId
			
			};
		}

	}
}
