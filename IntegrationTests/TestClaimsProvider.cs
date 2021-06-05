using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Constants;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IntegrationTests
{
    public class TestClaimsProvider
    {
        public IList<Claim> Claims { get; }
 
        public TestClaimsProvider(IList<Claim> claims)
        {
            Claims = claims;
        }
 
        public TestClaimsProvider()
        {
            Claims = new List<Claim>();
        }
 
        public static TestClaimsProvider WithAdminClaims()
        {
            var provider = new TestClaimsProvider();
            provider.Claims.Add(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()));
            provider.Claims.Add(new Claim(ClaimTypes.Name, "admin@airlines.com"));
            provider.Claims.Add(new Claim(ClaimTypes.Email, "admin@airlines.com"));
            provider.Claims.Add(new Claim(ClaimTypes.Role, Roles.ADMINISTRATORS));
 
            return provider;
        }
 
        public static TestClaimsProvider WithUserClaims()
        {
            var provider = new TestClaimsProvider();
            provider.Claims.Add(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()));
            provider.Claims.Add(new Claim(ClaimTypes.Name, "user1@airlines.com"));
            provider.Claims.Add(new Claim(ClaimTypes.Email, "user1@airlines.com"));
            provider.Claims.Add(new Claim(ClaimTypes.Role, Roles.USERS));
 
            return provider;
        }
    }
}