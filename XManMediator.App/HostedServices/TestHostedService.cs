using Microsoft.Extensions.Hosting;
using XManMediator.Abstractions;
using XManMediator.App.JustTestServices.Abstractions;
using XManMediator.App.Requests;
using XManMediator.App.Responses;

namespace XManMediator.App.HostedServices
{
    public class TestHostedService : BackgroundService
    {
        private readonly IXManMediator _mediator;
        public TestHostedService(IXManMediator mediator)
        {
            _mediator = mediator;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int counter = 1;
            while (!stoppingToken.IsCancellationRequested)
            {
                if (counter % 2 == 1)
                {
                    CreateOrderResponse response = _mediator.Send(new CreateOrder() { Message = "Test order creation " + counter++ });
                    Console.WriteLine(response.Message);
                }
                else
                {
                    CreateUserResponse response = await _mediator.SendAsync(new CreateUser() { Message = "Test User Creeation [async] " + counter++ });
                    Console.WriteLine(response.Message);
                }
                await Task.Delay(1000);
            }
        }
    }
}
