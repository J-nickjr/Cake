using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int CakeId { get; set; }
        [ForeignKey("CakeId")]
        public virtual Cake? Cake { get; set; }

        [Range(1, 100, ErrorMessage = "數量必須介於 1 和 100 之間")]
        [Display(Name = "數量")]
        public int Quantity { get; set; }

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
    }
}
