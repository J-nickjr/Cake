using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Models
{
    public enum OrderStatus
    {
        [Display(Name = "處理中")]
        Pending,
        [Display(Name = "已確認")]
        Confirmed,
        [Display(Name = "已出貨")]
        Shipped,
        [Display(Name = "已完成")]
        Completed,
        [Display(Name = "已取消")]
        Cancelled
    }
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        [Required]
        [Display(Name = "訂購日期")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "訂單總額")]
        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "收貨地址")]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "收貨人姓名")]
        public string RecipientName { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        [Display(Name = "聯絡電話")]
        public string RecipientPhone { get; set; } = string.Empty;

        [Required]
        [Display(Name = "訂單狀態")]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
