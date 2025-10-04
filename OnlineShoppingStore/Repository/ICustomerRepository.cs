using Microsoft.EntityFrameworkCore;

namespace OnlineShoppingStore.Repository;

public interface ICustomerRepository
{
    public List<Customer> GetAll();

    public Customer GetById(int id);
    public void Add(Customer customer);
    public void Update(Customer customer);
    public void SaveChanges();
    public List<Customer> GetAllCustomers();

}
