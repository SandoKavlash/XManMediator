﻿using XManMediator.Abstractions.Handlers;
using XManMediator.App.Requests;
using XManMediator.App.Responses;

namespace XManMediator.App.Handlers
{
    public class CreateOrderHandler : RequestHandler<CreateOrder, CreateOrderResponse>
    {
        public override CreateOrderResponse Handle(CreateOrder request)
        {
            throw new NotImplementedException();
        }
    }
}
