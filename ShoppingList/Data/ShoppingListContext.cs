using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;
using ShoppingList.Services;

namespace ShoppingList.Data
{
    public class ShoppingListContext : DbContext
    {
        private readonly IProvider<ShopItemModel> _shopItemProvider;
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options, IProvider<ShopItemModel> shopItemProvider)
            : base(options)
        {
            _shopItemProvider = shopItemProvider;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var items = _shopItemProvider.Provide();
            modelBuilder
                .Entity<ShopItemModel>()
                .HasData(items);
        }

        public DbSet<ShopItemModel> ShopItemModel { get; set; }
    }
}
