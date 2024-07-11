using XManMediator.Abstractions.Requests;
using XManMediator.App.Responses;

namespace XManMediator.App.Requests
{
    public class CreateOrder : Request<CreateOrder, CreateOrderResponse>
    {
        public string Message { get; set; }
    }
}
