using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Microsoft.Extensions.Configuration;

namespace IdentityServerAspNetIdentity;

public static class Config
{
    static ConfigurationBuilder builder = (ConfigurationBuilder)new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
    static IConfiguration config = builder.Build();

    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("api1", "MyAPI")
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            //// API
            //new Client
            //{
            //    ClientId = "client",
            //    ClientSecrets = { new Secret("secret".Sha256()) },

            //    AllowedGrantTypes = GrantTypes.ClientCredentials,
            //    // scopes that client has access to
            //    AllowedScopes = { "api1" }
            //},

            // Web
            new Client
            {
                ClientId = config.GetValue<string>("WebClient:Id"),
                ClientSecrets = { new Secret(config.GetValue<string>("WebClient:Secret").Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                // where to redirect to after login
                RedirectUris = { config.GetValue<string>("WebClient:RedirectUri") },

                // where to redirect to after logout
                PostLogoutRedirectUris = { config.GetValue<string>("WebClient:LogoutRedirectUri") },

                AllowOfflineAccess = true,

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "api1",
                }
            },

            // API Management
            new Client
            {
                ClientId = config.GetValue<string>("APIMClient:Id"),
                ClientSecrets = { new Secret(config.GetValue<string>("APIMClient:Secret").Sha256()) },

                AllowedGrantTypes = GrantTypes.Implicit,
                // where to redirect to after login
                RedirectUris = { config.GetValue<string>("APIMClient:RedirectUri") },

                // where to redirect to after logout
                PostLogoutRedirectUris = { config.GetValue<string>("APIMClient:LogoutRedirectUri") },

                AllowOfflineAccess = true,

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "api1",
                }
            },

        };
}