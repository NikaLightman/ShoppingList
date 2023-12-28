namespace ShoppingList.WebAPI.Settings
{
    public class ShoppingListSettings
    {
        public string ShoppingListDbContextConnectionString { get; set; }
        public Uri ServiceUri { get; set; }
        public string IdentityServerUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}