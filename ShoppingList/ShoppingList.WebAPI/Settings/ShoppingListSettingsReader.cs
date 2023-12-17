namespace ShoppingList.WebAPI.Settings
{
    public class ShoppingListSettingsReader
    {
        public static ShoppingListSettings Read(IConfiguration configuration)
        {
            return new ShoppingListSettings();
        }
    }
}