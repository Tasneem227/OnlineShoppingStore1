namespace OnlineShoppingStore.Repository
{
    public interface IOrderRepository
    {
        public List<Order> GetAllOrders();
        public void AddOrder(CartItem[] items, string? userid);
        public void UpdateStatus(Order order);
        public List<Order> SearchForOrder(int OrderId);
        public void SaveChanges();
        public List<Order> GetOrdersByCustomerId(string? userId);
    }

}
