using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class ShopItemModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ShopItemUnit Unit { get; set; }
        public ShopSection Section { get; set; }
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; } = 1;
    }
}
