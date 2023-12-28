namespace ShoppingList.DataAccess.Entities
{
    public class SellerEntity : BaseEntity 
    {
        public required string ContactEmail { get; set; }
        public required string DocumentsDescription { get; set; }
        public string? CompanyName { get; set; }

        public int UserId { get; set; }
        public required UserEntity User { get; set; }

        public virtual ICollection<ProductEntity>? Products { get; set; }
    }
}