namespace ShoppingList.DataAccess.Entities
{
    public class ShoppingListEntity : BaseEntity
    {
        public DateTime DateOfList { get; set; }
        public bool Status { get; set; }
        public string? Description { get; set; }

        public int UserId { get; set; }
        public required UserEntity User { get; set; }

        public virtual ICollection<ItemsInShoppingListEntity>? ItemsInShoppingList { get; set; }
    }
}