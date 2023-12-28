namespace ShoppingList.DataAccess.Entities
{
    public class ProductEntity : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public int SellerId { get; set; }
        public required SellerEntity Seller { get; set; }

        public virtual ICollection<ItemsInShoppingListEntity>? ItemsInShoppingList { get; set; }
    }
}