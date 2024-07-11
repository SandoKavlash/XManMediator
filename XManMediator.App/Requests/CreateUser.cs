using XManMediator.Abstractions.Handlers;
using XManMediator.Abstractions.Requests;
using XManMediator.App.Responses;

namespace XManMediator.App.Requests
{
    public class CreateUser : AsyncRequest<CreateUser,CreateUserResponse>
    {
        public string Message { get; set; }
    }
}
