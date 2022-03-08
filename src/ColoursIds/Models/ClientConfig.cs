namespace ColoursIds.Models
{
    public class ClientConfig
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RedirectUri { get; set; }
        public string LogoutRedirectUri { get; set; }
        public string Secret { get; set; }
        public string[] AllowedGrantTypes { get; set; }
        public string[] AllowedScopes { get; set; }
        public bool AllowOfflineAccess { get; set; }
    }
}
