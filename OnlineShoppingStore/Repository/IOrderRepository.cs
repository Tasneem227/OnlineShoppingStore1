namespace OnlineShoppingStore.Repository
{
    public interface IOrderRepository
    {
        public OrderCustomerViewModel GetAllOrders();
        public void AddOrder(CartItem[] items,string? userid);
        public void SaveChanges();
    }
}
