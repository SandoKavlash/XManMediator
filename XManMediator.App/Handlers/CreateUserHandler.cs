using XManMediator.Abstractions.Handlers;
using XManMediator.App.Requests;
using XManMediator.App.Responses;

namespace XManMediator.App.Handlers
{
    public class CreateUserHandler : RequestHandler<CreateUser, CreateUserResponse>
    {
        public override CreateUserResponse Handle(CreateUser request)
        {
            throw new NotImplementedException();
        }
    }
}
