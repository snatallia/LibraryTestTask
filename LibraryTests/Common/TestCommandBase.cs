using Library.Persistence;
using System.Net.NetworkInformation;

namespace LibraryTests.Common
{
    public class TestCommandBase: IDisposable
    {
        private readonly LibraryDbContext context;

        public LibraryDbContext Context { get { return context; } }

        public TestCommandBase()
        {
            context = TestContextFactory.Create();
        }

        public void Dispose()
        {
            TestContextFactory.Destroy(Context);
        }
    }
}
