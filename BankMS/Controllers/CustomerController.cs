using BankMS.Models;
using BankMS.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankMS.Controllers;

public class CustomerController : Controller
{ 
    private readonly ICustomerRepository _customerRepository;
    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<IActionResult> Index()
    {
        var customers =await _customerRepository.GetAllCustomerAsync();
        return View(customers);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id)
    {
           if (id == 0)
        {
            return View(new Customer());
        }
        else
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer != null)
            {
                return View(customer);
               
            }
            return NotFound();
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Customer customer)
    {
            if (customer.Id == 0)
            {
                await _customerRepository.GetAddCustomerAsynce(customer);
              return RedirectToAction(nameof(Index));
             }
            else
            {
                await _customerRepository.GetUpdateCustomerAsync(customer);
               return RedirectToAction(nameof(Index));
            }  
    }
}
