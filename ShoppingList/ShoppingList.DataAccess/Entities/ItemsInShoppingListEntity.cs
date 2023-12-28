namespace ShoppingList.DataAccess.Entities
{
    public class ItemsInShoppingListEntity : BaseEntity
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public required ProductEntity Product { get; set; }

        public int ShoppingListId { get; set; }
        public required ShoppingListEntity ShoppingList { get; set; }
    }
}