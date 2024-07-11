using XManMediator.App.JustTestServices.Abstractions;

namespace XManMediator.App.JustTestServices.Implementations
{
    public class TestService : ITestService, IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("TestService Disposed");
        }
    }
}
