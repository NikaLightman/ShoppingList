using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ShoppingList.DataAccess.Entities
{
    [Table("UsersTable")]
    public class UserEntity : IdentityUser<int>, IBaseEntity
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public DateTime ModificationTime { get; set; }
        public DateTime CreationTime { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }

        public int SellerId { get; set; }
        public SellerEntity? Seller { get; set; }

        public virtual ICollection<ShoppingListEntity>? ShoppingLists { get; set; }
    }

    public class UserRoleEntity : IdentityRole<int>
    {
    }
}