using BankMS.Models;

namespace BankMS.Repository;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllCustomerAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<Customer> GetAddCustomerAsynce(Customer customer);
    Task<Customer> GetUpdateCustomerAsync(Customer customer);
    Task<Customer> GetDeleteCustomerAsync(int id);
}
