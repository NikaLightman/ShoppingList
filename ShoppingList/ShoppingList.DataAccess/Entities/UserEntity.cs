using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.DataAccess.Entities
{
    [Table("UsersTable")]
    public class UserEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string PhoneNumber { get; set; }

        public int SellerId { get; set; }
        public SellerEntity? Seller { get; set; }

        public virtual ICollection<ShoppingListEntity>? ShoppingLists { get; set; }
    }
}