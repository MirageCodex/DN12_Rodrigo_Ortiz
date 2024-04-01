using DataAccess.Example.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.UnitTest
{
    [TestFixture]
    public class ColorsTest
    {
        protected TestServer server;

        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            server.Dispose();
        }
        [Test]

        public void Test1()
        {
            var repository = server.Host.Services.GetService<IVehiclesDataManager>();
            var list = repository.GetAll();
            Assert.Pass();
        }
    }
}