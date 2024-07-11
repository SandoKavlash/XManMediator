using XManMediator.Abstractions.Handlers;
using XManMediator.App.JustTestServices.Abstractions;
using XManMediator.App.Requests;
using XManMediator.App.Responses;

namespace XManMediator.App.Handlers
{
    public class CreateOrderHandler : RequestHandler<CreateOrder, CreateOrderResponse>, IDisposable
    {
        private readonly ITestService _testService;
        public CreateOrderHandler(ITestService testService)
        {
            Console.WriteLine("CreateOrderHandler created");
            _testService = testService;
        }

        public void Dispose()
        {
            Console.WriteLine("CreateOrderHandler disposed");
        }

        public override CreateOrderResponse Handle(CreateOrder request)
        {
            Console.WriteLine(request.Message);
            return new CreateOrderResponse() { Message = request.Message + " Response" };
        }
    }
}
