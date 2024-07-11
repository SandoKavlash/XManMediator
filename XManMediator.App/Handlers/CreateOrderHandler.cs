using XManMediator.Abstractions.Handlers;
using XManMediator.App.Requests;
using XManMediator.App.Responses;

namespace XManMediator.App.Handlers
{
    public class CreateOrderHandler : RequestHandler<CreateOrder, CreateOrderResponse>
    {
        public CreateOrderHandler()
        {
            Console.WriteLine("CreateOrderHandler created");
        }
        public override CreateOrderResponse Handle(CreateOrder request)
        {
            Console.WriteLine(request.Message);
            return new CreateOrderResponse() { Message = request.Message + " Response" };
        }
    }
}
