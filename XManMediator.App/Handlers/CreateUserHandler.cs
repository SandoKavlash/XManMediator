using XManMediator.Abstractions.Handlers;
using XManMediator.App.Requests;
using XManMediator.App.Responses;

namespace XManMediator.App.Handlers
{
    public class CreateUserHandler : AsyncRequestHandler<CreateUser, CreateUserResponse>
    { 
        public override async Task<CreateUserResponse> HandleAsync(CreateUser request)
        {
            Console.WriteLine(request.Message);
            return new CreateUserResponse() { Message = request.Message + " Response" };
        }
    }
}
