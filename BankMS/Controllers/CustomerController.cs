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
}
