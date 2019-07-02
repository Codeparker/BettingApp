using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ODDESTODDS.Application.DtoModels.Game;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ODDESTODDS.UnitTest
{
    public class TestClientProvider
    {
        private TestServer server;
        public HttpClient Client { get; private set; }
        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>()
                .ConfigureTestServices(services =>
                {
                    services.AddDbContext<Persistence.Context.ApplicatioDBContext>(options =>
                             options.UseSqlite("Data Source=oddestodds.db"));
                }));
            Client = server.CreateClient();
        }

       

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }

    }
}
