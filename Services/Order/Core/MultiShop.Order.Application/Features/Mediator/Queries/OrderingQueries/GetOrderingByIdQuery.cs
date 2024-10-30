﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
	public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
	{
		public GetOrderingByIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}
