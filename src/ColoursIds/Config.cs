using ColoursIds.Models;
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

    public static IEnumerable<Client> Clients(IEnumerable<ClientConfig> config)
    {
        return config.Select(x => new Client()
        {
            ClientId = x.Id,
            ClientSecrets = { new Secret(x.Secret.Sha256()) } ,
            AllowedGrantTypes = x.AllowedGrantTypes,
            RedirectUris = { x.RedirectUri },
            PostLogoutRedirectUris = { x.LogoutRedirectUri },
            AllowOfflineAccess = x.AllowOfflineAccess,
            AllowedScopes = x.AllowedScopes
        });
    }
}