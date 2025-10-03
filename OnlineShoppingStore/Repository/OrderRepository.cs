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

        public List<Order> GetAllOrders()
        {
            return _Context.Orders.Include(c=>c.Customer).ToList();
            
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
                order.Status = OrderStatus.Processing;
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

        public List<Order> GetOrdersByCustomerId(string? userId)
        {
            var user = _Context.Customers.Include(u=>u.Orders).FirstOrDefault(e => e.UserId == userId);
            if (user == null|| user.Orders==null) {
                return new List<Order>();
        }
                return _Context.Orders
                    .Where(o => o.CustomerId == user.CustomerId)
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                    .OrderByDescending(o => o.OrderDate)
                    .ToList();
            
        }
        public void UpdateStatus(Order order)
        {
            _Context.Orders.Update(order);
        }
        public List<Order> SearchForOrder(int OrderId)
        {
            return _Context.Orders.Include(c=>c.Customer).Where(o => o.OrderId == OrderId).ToList();

        }

        public void SaveChanges() => _Context.SaveChanges();

    }
}
