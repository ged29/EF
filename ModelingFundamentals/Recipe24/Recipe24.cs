using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingFundamentals.Recipe24
{
    static class Test
    {
        public static void Run()
        {
            using (var context = new Model24Context())
            {
                var order = new Order { OrderId = 1, OrderDate = new DateTime(2010, 1, 18) };
                var item = new Item { SKU = 1729, Description = "Backpack", Price = 29.97M };
                var oi = new OrderItem { Order = order, Item = item, Count = 1 };
                context.OrderItems.Add(oi);

                item = new Item { SKU = 2929, Description = "Water Filter", Price = 13.97M };
                oi = new OrderItem { Order = order, Item = item, Count = 3 };
                context.OrderItems.Add(oi);

                item = new Item { SKU = 1847, Description = "Camp Stove", Price = 43.99M };
                oi = new OrderItem { Order = order, Item = item, Count = 1 };
                context.OrderItems.Add(oi);
                context.SaveChanges();
            }

            using (var context = new Model24Context())
            {
                foreach (var order in context.Orders)
                {
                    Console.WriteLine("Order # {0}, ordered on {1}",
                    order.OrderId.ToString(),
                    order.OrderDate.ToShortDateString());
                    Console.WriteLine("SKU\tDescription\tQty\tPrice");
                    Console.WriteLine("---\t-----------\t---\t-----");
                    foreach (var oi in order.OrderItems)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", oi.Item.SKU,
                        oi.Item.Description, oi.Count.ToString(),
                        oi.Item.Price.ToString("C"));
                    }
                }
            }
        }
    }
}