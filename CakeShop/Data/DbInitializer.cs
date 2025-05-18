using CakeShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;



namespace CakeShop.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cakes.Any())
            {
                return;
            }

            var cakes = new Cake[]
            {
                new Cake{Name="經典巧克力蛋糕", Description="濃郁滑順的黑巧克力甘納許", Price=550.00m, ImageUrl="/images/2.png"},
                new Cake{Name="水果鮮奶油蛋糕", Description="多種水果與鮮奶油的完美搭配", Price=550.00m, ImageUrl="/images/4.png"},
                new Cake{Name="起司蛋糕", Description="濃厚香醇的起司蛋糕", Price=550.00m, ImageUrl="/images/5.png"},
                new Cake{Name="草莓慕斯蛋糕", Description="酸甜草莓與柔滑慕斯的絕配", Price=550.00m, ImageUrl="/images/6.png"},
                new Cake{Name="抹茶紅豆蛋糕", Description="日式抹茶融合蜜紅豆", Price=550.00m, ImageUrl="/images/7.png"}
            };
             
            foreach (Cake c in cakes)
            {
                context.Cakes.Add(c);
            }
            context.SaveChanges();
        }
    }
}
