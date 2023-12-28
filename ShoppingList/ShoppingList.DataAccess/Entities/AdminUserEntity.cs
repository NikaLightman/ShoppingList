namespace ShoppingList.DataAccess.Entities
{
    public class AdminUserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
    }
}