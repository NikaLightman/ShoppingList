namespace ShoppingList.DataAccess.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public DateTime ModificationTime { get; set; }
        public DateTime CreationTime { get; set; }

        public bool IsNew()
        {
            return ExternalId == Guid.Empty;
        }

        public void Init()
        {
            ExternalId = Guid.NewGuid();
            ModificationTime = DateTime.Now;
            CreationTime = DateTime.Now;
        }
    }
}