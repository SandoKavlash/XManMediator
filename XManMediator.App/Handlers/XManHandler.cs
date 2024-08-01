using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XManMediator.Abstractions.Handlers;
using XManMediator.App.XManModels;

namespace XManMediator.App.Handlers
{
    public class XManHandler : AsyncRequestHandler<XManRequest, XManResponse>
    {
        public override async Task<XManResponse> HandleAsync(XManRequest request)
        {
            await Task.Delay(100);
            return new XManResponse();
        }
    }
}
