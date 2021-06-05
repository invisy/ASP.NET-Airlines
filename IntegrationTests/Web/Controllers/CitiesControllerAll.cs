using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace IntegrationTests.Web.Controllers
{
    [Collection("Sequential")]
    public class CitiesControllerAll: IClassFixture<WebTestFixture>
    {
        public HttpClient Client { get; }
        public HttpClient UserClient { get; }
        public HttpClient AdminClient { get; }

        public CitiesControllerAll(WebTestFixture factory)
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
        public async Task RedirectsAnonymousUserToLoginPage()
        {
            var response = await Client.GetAsync("/Cities/All");

            var redirectLocation = response.Headers.Location.OriginalString;

            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Contains("/Account/Login", redirectLocation);
        }
        
        [Fact]
        public async Task RedirectsLoggedInUserToAccessDeniedPage()
        {
            var response = await UserClient.GetAsync("/Cities/All");

            var redirectLocation = response.Headers.Location.OriginalString;

            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Contains("/Account/AccessDenied", redirectLocation);
        }
        
        [Fact]
        public async Task ReturnsCitiesList()
        {
            var response = await AdminClient.GetAsync("/Cities/All");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Київ", content);
            Assert.Contains("Харків", content);
            Assert.Contains("Львів", content);
        }
    }
}