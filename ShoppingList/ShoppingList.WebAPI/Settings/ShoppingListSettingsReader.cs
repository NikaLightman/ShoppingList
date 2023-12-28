namespace ShoppingList.WebAPI.Settings
{
    public class ShoppingListSettingsReader
    {
        public static ShoppingListSettings Read(IConfiguration configuration)
        {
            return new ShoppingListSettings()
            {
                ShoppingListDbContextConnectionString = configuration.GetValue<string>("ShoppingListDbContext"),
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            };
        }
    }
}