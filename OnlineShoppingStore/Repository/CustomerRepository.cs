using Microsoft.EntityFrameworkCore;
using OnlineShoppingStore.Data;

namespace OnlineShoppingStore.Repository;

public class CustomerRepository: ICustomerRepository
{
    private readonly ApplicationDbContext _Context;

    public CustomerRepository(ApplicationDbContext context)
    {
        this._Context = context;
        _Context = context;
    }
    public List<Customer> GetAll()
    {
        return _Context.Customers.ToList();
    }

    public Customer GetById(int id)
    {
        return _Context.Customers.FirstOrDefault(p => p.CustomerId == id);
    }
    public void Add(Customer customer)
    {
        _Context.Customers.Add(customer);
    }
    public void Update(Customer customer)
    {
        _Context.Customers.Update(customer);
    }
    public void SaveChanges() => _Context.SaveChanges();



    public List<Customer> GetAllCustomers()
    {
        return _Context.Customers.ToList();
    }
}
