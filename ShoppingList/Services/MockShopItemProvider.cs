using System.Collections.Generic;
using ShoppingList.Models;

namespace ShoppingList.Services
{
    public class MockShopItemProvider : IProvider<ShopItemModel>
    {
        public IEnumerable<ShopItemModel> Provide() => new ShopItemModel[]
        {
            new ShopItemModel
            {
                Id = 1,
                Name = "Shop item 1",
                Quantity = 5,
                Section = ShopSection.Produce,
                Unit = ShopItemUnit.Kilogram
            },
            new ShopItemModel
            {
                Id = 2,
                Name = "Shop item 2",
                Quantity = 2,
                Section = ShopSection.Preserves,
                Unit = ShopItemUnit.Bag
            },
            new ShopItemModel
            {
                Id = 3,
                Name = "Shop item 3",
                Quantity = 1,
                Section = ShopSection.Frozen,
                Unit = ShopItemUnit.Bag
            },
            new ShopItemModel
            {
                Id = 4,
                Name = "Shop item 4",
                Quantity = 100,
                Section = ShopSection.Dairy,
                Unit = ShopItemUnit.Bottle
            },
        };
    }
}
