using Microsoft.EntityFrameworkCore;
using ShoppingList.DataAccess.Entities;

namespace ShoppingList.DataAccess
{
    public class ShoppingListDbContext : DbContext
    {
        public DbSet<AdminUserEntity> AdminUsers { get; set; }
        public DbSet<ItemsInShoppingListEntity> ItemsInShoppingList { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<SellerEntity> Sellers { get; set; }
        public DbSet<ShoppingListEntity> ShoppingLists { get; set; }
        public DbSet<UserEntity> Users { get; set; }


        public ShoppingListDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUserEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AdminUserEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<AdminUserEntity>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<AdminUserEntity>().HasIndex(x => x.PhoneNumber).IsUnique();

            modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<UserEntity>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<UserEntity>().HasIndex(x => x.PhoneNumber).IsUnique();

            modelBuilder.Entity<SellerEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<SellerEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<SellerEntity>().HasIndex(x => x.ContactEmail).IsUnique();
            modelBuilder.Entity<SellerEntity>().HasIndex(x => x.DocumentsDescription).IsUnique();
            modelBuilder.Entity<SellerEntity>().HasOne(x => x.User)
                                               .WithOne(x => x.Seller)
                                               .HasForeignKey<UserEntity>(x => x.SellerId);

            modelBuilder.Entity<ShoppingListEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ShoppingListEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<ShoppingListEntity>().HasOne(x => x.User)
                                                     .WithMany(x => x.ShoppingLists)
                                                     .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ProductEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ProductEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<ProductEntity>().HasOne(x => x.Seller)
                                                .WithMany(x => x.Products)
                                                .HasForeignKey(x => x.SellerId);

            modelBuilder.Entity<ItemsInShoppingListEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ItemsInShoppingListEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<ItemsInShoppingListEntity>().HasIndex(x => new { x.ProductId, x.ShoppingListId }).IsUnique();
            modelBuilder.Entity<ItemsInShoppingListEntity>().HasOne(x => x.ShoppingList)
                                                            .WithMany(x => x.ItemsInShoppingList)
                                                            .HasForeignKey(x => x.ShoppingListId)
                                                            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ItemsInShoppingListEntity>().HasOne(x => x.Product)
                                                            .WithMany(x => x.ItemsInShoppingList)
                                                            .HasForeignKey(x => x.ProductId)
                                                            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}