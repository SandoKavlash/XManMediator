using MediatR;
using XManMediator.App.MediatorModels;
using XManMediator.App.XManModels;

namespace XManMediator.App.Handlers
{
    public class MediatorHandler : IRequestHandler<MediatorRequest, MediatorResponse>
    {
        public async Task<MediatorResponse> Handle(MediatorRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(100);
            return new MediatorResponse();
        }
    }
}
