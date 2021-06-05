using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace IntegrationTests.Web.Controllers
{
    [Collection("Sequential")]
    public class CitiesControllerCreate: IClassFixture<WebTestFixture>
    {
        public HttpClient Client { get; }
        public HttpClient UserClient { get; }
        public HttpClient AdminClient { get; }
        
        public CitiesControllerCreate(WebTestFixture factory)
        {
            Client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            
            var adminProvider = TestClaimsProvider.WithAdminClaims();
            AdminClient = factory.CreateClientWithTestAuth(adminProvider);
            
            var userProvider = TestClaimsProvider.WithUserClaims();
            UserClient = factory.CreateClientWithTestAuth(userProvider);
        }
        
        [Fact]
        public async Task ShowsCreateFormForAdminOnGetRequest()
        {
            var response = await AdminClient.GetAsync("/Cities/Create");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Додати", content);
        }
    }
}