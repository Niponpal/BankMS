using BankMS.Data;
using BankMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BankMS.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;
    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Customer> GetAddCustomerAsynce(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
    {
        var customers = await _context.Customers.ToListAsync();
        return customers;
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            return customer;
        }
        return null!;
    }

    public async Task<Customer> GetDeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        return null!;
    }

    public async Task<Customer> GetUpdateCustomerAsync(Customer customer)
    {
        var existingCustomer = await _context.Customers.FindAsync(customer.Id);
        if (existingCustomer != null)
        {
            existingCustomer.NIDNumber = customer.NIDNumber;
            existingCustomer.Address = customer.Address;
            existingCustomer.DateOfBirth = customer.DateOfBirth;
            existingCustomer.KYCStatus = customer.KYCStatus;
            existingCustomer.Gender = customer.Gender;
            await _context.SaveChangesAsync();
            return existingCustomer;
        }
        return null!;
    }
}
