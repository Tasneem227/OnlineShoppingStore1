using Microsoft.AspNetCore.Identity;
using OnlineShoppingStore.Data;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        ApplicationDbContext _Context;
        private readonly UserManager<ApplicationUser> _UserManager;

        public OrderRepository(ApplicationDbContext context)
        {
            this._Context = context;
        }

        public OrderCustomerViewModel GetAllOrders()
        {
            OrderCustomerViewModel result = new OrderCustomerViewModel();
            var list = _Context.Orders.ToList();
            result.orderlist= list;
            foreach (var item in list) { 
            
                result.FirstName = _Context.Customers.FirstOrDefault(e=>e.CustomerId==item.CustomerId).FirstName;
                result.LastName = _Context.Customers.FirstOrDefault(e => e.CustomerId == item.CustomerId).LastName;
            }
            return result ;
        }
        public void AddOrder(CartItem[] items, string? userid)
        {
            Order order = new Order();


            var totalamount = 0;
            for (int i = 0; i < items.Length; i++)
            {
                totalamount += items[i].Quantity;
            }

                order.OrderDate = DateTime.Now;
                order.Status = "";
                order.TotalAmount = totalamount;
                int customerId = _Context.Customers.FirstOrDefault(e => e.UserId == userid).CustomerId;
            order.CustomerId = customerId;
            
             _Context.Orders.Add(order);
            foreach(var item in items)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.OrderId = order.OrderId;
                orderItem.ProductId = item.ProductId;
                orderItem.Quantity = item.Quantity;
                _Context.OrdersItems.Add(orderItem);
                _Context.CartsItems.Remove(item);
                order.OrderItems.Add(orderItem);
                _Context.SaveChanges();
            }

        }
        public void SaveChanges() => _Context.SaveChanges();

    }
}
