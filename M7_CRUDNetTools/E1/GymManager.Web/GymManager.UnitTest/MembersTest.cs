using GymManager.Core.Members;
using GymManager.DataAccess.Repositories;
using GymManagerApplicationServices.Members;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace GymManager.UnitTest
{
    [TestFixture]
    public class MembersTest
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        protected TestServer server;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        [Test]
        public void GetAllMembersTest()
        {
            var repositor = server.Host.Services.GetService<IRepository<int, Member>>();
            var list = repositor.GetAll();
            Assert.Pass();
        }
    }
}