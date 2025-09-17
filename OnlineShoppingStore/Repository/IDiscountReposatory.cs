namespace OnlineShoppingStore.Repository
{
    public interface IDiscountRepository
    {

        public void ApplyDiscount(int Code);
        public void SaveChanges();
    }
}
